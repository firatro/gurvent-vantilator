using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GurventVantilator.Infrastructure.Data.Repositories
{
    public class ProductWorkingConditionRepository : IProductWorkingConditionRepository
    {
        private readonly AppDbContext _context;

        public ProductWorkingConditionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductWorkingCondition>> GetAllAsync()
        {
            return await _context.ProductWorkingConditions
                .Include(w => w.Products)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ProductWorkingCondition?> GetByIdAsync(int id)
        {
            return await _context.ProductWorkingConditions
                .Include(w => w.Products)
                .FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<List<ProductWorkingCondition>> GetByIdsAsync(IEnumerable<int> ids)
        {
            return await _context.ProductWorkingConditions
                .Where(w => ids.Contains(w.Id))
                .ToListAsync();
        }

        public async Task AddAsync(ProductWorkingCondition entity)
        {
            await _context.ProductWorkingConditions.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductWorkingCondition entity)
        {
            _context.ProductWorkingConditions.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ProductWorkingCondition entity)
        {
            _context.ProductWorkingConditions.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
