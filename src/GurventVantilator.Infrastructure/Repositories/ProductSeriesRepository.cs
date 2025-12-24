using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GurventVantilator.Infrastructure.Data.Repositories
{
    public class ProductSeriesRepository : IProductSeriesRepository
    {
        private readonly AppDbContext _context;

        public ProductSeriesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductSeries>> GetAllAsync()
        {
            return await _context.ProductSeries
                .Include(s => s.Models)
                .ThenInclude(m => m.Products)
                .ToListAsync();
        }

        public async Task<ProductSeries?> GetByIdAsync(int id)
        {
            return await _context.ProductSeries
                .Include(s => s.Models)
                .ThenInclude(m => m.Products)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddAsync(ProductSeries entity)
        {
            await _context.ProductSeries.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductSeries entity)
        {
            _context.ProductSeries.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ProductSeries entity)
        {
            _context.ProductSeries.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductSeries>> GetByUsageOrWorkingAsync(int? usageTypeId, int? workingConditionId)
        {
            var query = _context.ProductModels
                .Include(p => p.ProductSeries)
                .Include(p => p.UsageTypes)
                .Include(p => p.WorkingConditions)
                .AsQueryable();

            if (usageTypeId.HasValue)
                query = query.Where(p => p.UsageTypes.Any(u => u.Id == usageTypeId.Value));

            if (workingConditionId.HasValue)
                query = query.Where(p => p.WorkingConditions.Any(w => w.Id == workingConditionId.Value));

            // Ürünlere göre eşleşen serileri al ve grupla
            return await query
                .Select(p => p.ProductSeries)
                .Distinct()
                .ToListAsync();
        }


    }
}
