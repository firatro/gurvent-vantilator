using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GurventVantilator.Infrastructure.Data.Repositories
{
    public class ProductModelRepository : IProductModelRepository
    {
        private readonly AppDbContext _context;

        public ProductModelRepository(AppDbContext context)
        {
            _context = context;
        }

        // ===========================================================
        // 🔹 GET ALL
        // ===========================================================
        public async Task<List<ProductModel>> GetAllAsync()
        {
            return await _context.ProductModels
                .Include(m => m.ProductSeries)
                .Include(m => m.UsageTypes)
                .Include(m => m.WorkingConditions)
                .Include(m => m.ContentFeatures)
                .Include(m => m.ModelFeatures)     // 🔥 EKLENDİ
                .AsNoTracking()
                .ToListAsync();
        }

        // ===========================================================
        // 🔹 GET BY ID (AsNoTracking)
        // ===========================================================
        public async Task<ProductModel?> GetByIdAsync(int id)
        {
            return await _context.ProductModels
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        // ===========================================================
        // 🔹 GET BY ID WITH INCLUDES (Tracked)
        // ===========================================================
        public async Task<ProductModel?> GetByIdWithIncludesAsync(int id)
        {
            return await _context.ProductModels
                .Include(m => m.Documents)
                .Include(m => m.ProductSeries)
                .Include(m => m.Products)
                .Include(m => m.UsageTypes)
                .Include(m => m.WorkingConditions)
                .Include(m => m.ContentFeatures)
                .Include(m => m.ModelFeatures)          // 🔥 ModelFeatures ekli
                .Include(m => m.TestData)
                .FirstOrDefaultAsync(m => m.Id == id);  // tracked (gerekli)
        }

        // ===========================================================
        // 🔹 GET BY SERIES ID
        // ===========================================================
        public async Task<List<ProductModel>> GetBySeriesIdAsync(int seriesId)
        {
            return await _context.ProductModels
                .Include(m => m.ProductSeries)
                .Include(m => m.Products)
                .Include(m => m.UsageTypes)
                .Include(m => m.WorkingConditions)
                .Include(m => m.ContentFeatures)
                .Include(m => m.ModelFeatures)   // 🔥 EKLENDİ
                .Where(m => m.ProductSeriesId == seriesId)
                .OrderBy(m => m.Order)
                .AsNoTracking()
                .ToListAsync();
        }

        // ===========================================================
        // 🔹 ADD
        // ===========================================================
        public async Task AddAsync(ProductModel entity)
        {
            await _context.ProductModels.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        // ===========================================================
        // 🔹 UPDATE (Doğru Yöntem)
        // ===========================================================
        public async Task UpdateAsync(ProductModel entity)
        {
            // ❗ Burası YALNIZCA SaveChanges yapar.
            // Service zaten tracked entity üzerinde değişiklik yapmıştır.
            await _context.SaveChangesAsync();
        }

        // ===========================================================
        // 🔹 DELETE
        // ===========================================================
        public async Task DeleteAsync(ProductModel entity)
        {
            _context.ProductModels.Remove(entity);
            await _context.SaveChangesAsync();
        }

        // ===========================================================
        // 🔹 PAGED
        // ===========================================================
        public async Task<(List<ProductModel> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = _context.ProductModels
                .Include(m => m.ProductSeries)
                .Include(m => m.Products)
                .Include(m => m.UsageTypes)
                .Include(m => m.WorkingConditions)
                .AsNoTracking()
                .OrderByDescending(m => m.CreatedAt);

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }
    }
}
