using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GurventVantilator.Infrastructure.Data.Repositories
{
    public class ProductUsageTypeRepository : IProductUsageTypeRepository
    {
        private readonly AppDbContext _context;

        public ProductUsageTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductUsageType>> GetAllAsync()
        {
            return await _context.ProductUsageTypes
                .Include(u => u.Products)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ProductUsageType?> GetByIdAsync(int id)
        {
            return await _context.ProductUsageTypes
                .Include(u => u.Products)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<ProductUsageType>> GetByIdsAsync(IEnumerable<int> ids)
        {
            return await _context.ProductUsageTypes
                .Where(u => ids.Contains(u.Id))
                .ToListAsync();
        }

        public async Task AddAsync(ProductUsageType entity)
        {
            await _context.ProductUsageTypes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductUsageType entity)
        {
            _context.ProductUsageTypes.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ProductUsageType entity)
        {
            _context.ProductUsageTypes.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
