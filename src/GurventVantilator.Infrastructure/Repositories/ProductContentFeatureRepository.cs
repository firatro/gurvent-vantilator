using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using GurventVantilator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GurventVantilator.Infrastructure.Repositories
{
    public class ProductContentFeatureRepository : IProductContentFeatureRepository
    {
        private readonly AppDbContext _context;

        public ProductContentFeatureRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductContentFeature>> GetAllAsync(bool asNoTracking = false)
        {
            var query = _context.ProductContentFeatures
                .Include(p => p.Product)
                .AsQueryable();

            if (asNoTracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task<ProductContentFeature?> GetByIdAsync(int id)
        {
            return await _context.ProductContentFeatures
                .Include(p => p.Product)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<ProductContentFeature>> GetByProductIdAsync(int productId, bool asNoTracking = false)
        {
            var query = _context.ProductContentFeatures
                .Where(x => x.ProductId == productId)
                .Include(p => p.Product)
                .OrderBy(x => x.Order)
                .AsQueryable();

            if (asNoTracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task AddAsync(ProductContentFeature feature)
        {
            await _context.ProductContentFeatures.AddAsync(feature);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductContentFeature feature)
        {
            _context.ProductContentFeatures.Update(feature);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ProductContentFeature feature)
        {
            _context.ProductContentFeatures.Remove(feature);
            await _context.SaveChangesAsync();
        }
    }
}
