using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GurventVantilator.Infrastructure.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        // ===========================================================
        // 🔹 GET ALL
        // ===========================================================
        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products
                .Include(p => p.ProductModel)
                .Include(p => p.ProductSeries)
                .Include(p => p.UsageTypes)
                .Include(p => p.WorkingConditions)
                .Include(p => p.ContentFeatures)
                .Include(p => p.TestData)
                .OrderBy(p => p.Order)
                .ThenBy(p => p.Name)
                .AsNoTracking()
                .ToListAsync();
        }

        // ===========================================================
        // 🔹 GET BY ID (Basit)
        // ===========================================================
        public async Task<Product?> GetByIdAsync(int productId)
        {
            return await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == productId);
        }

        // ===========================================================
        // 🔹 GET BY ID (Include’larla)
        // ===========================================================
        public async Task<Product?> GetByIdWithIncludesAsync(int productId)
        {
            return await _context.Products
                .Include(p => p.ProductModel)
                .Include(p => p.ProductSeries)
                .Include(p => p.UsageTypes)
                .Include(p => p.WorkingConditions)
                .Include(p => p.ContentFeatures)
                .Include(p => p.TestData)
                .Include(x => x.Accessories)
                .FirstOrDefaultAsync(p => p.Id == productId);
        }

        public async Task<List<Product>> GetByModelIdAsync(int modelId)
        {
            return await _context.Products
                .Include(p => p.ProductModel)
                .Include(p => p.ProductSeries)
                .Include(p => p.UsageTypes)
                .Include(p => p.WorkingConditions)
                .Include(p => p.ContentFeatures)
                .Where(p => p.ProductModelId == modelId)
                .ToListAsync();
        }


        // ===========================================================
        // 🔹 ADD
        // ===========================================================
        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        // ===========================================================
        // 🔹 UPDATE
        // ===========================================================
        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        // ===========================================================
        // 🔹 DELETE
        // ===========================================================
        public async Task DeleteAsync(Product product)
        {
            await _context.Products.Where(p => p.Id == product.Id).ExecuteDeleteAsync();

        }

        // ===========================================================
        // 🔹 PAGED (Sayfalama)
        // ===========================================================
        public async Task<(List<Product> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = _context.Products
                .Include(p => p.ProductModel)
                .Include(p => p.ProductSeries)
                .Include(p => p.UsageTypes)
                .Include(p => p.WorkingConditions)
                .AsNoTracking()
                .OrderByDescending(p => p.CreatedAt);

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public async Task<List<Product>> GetByIdsAsync(List<int> productIds)
        {
            return await _context.Products
                .Where(p => productIds.Contains(p.Id))
                .ToListAsync();
        }

        public async Task<List<Product>> GetByIdsWithModelAndUsageAsync(
    List<int> productIds,
    int? usageId)
        {
            var query = _context.Products
                .Include(p => p.ProductModel)
                    .ThenInclude(m => m.UsageTypes)
                .Where(p => productIds.Contains(p.Id));

            // 🟢 Usage seçilmişse filtrele
            if (usageId.HasValue)
            {
                query = query.Where(p =>
                    p.ProductModel != null &&
                    p.ProductModel.UsageTypes.Any(u => u.Id == usageId.Value));
            }

            return await query.ToListAsync();
        }

        public async Task<List<Product>> GetByIdsWithModelFiltersAsync(
    List<int> productIds,
    int? usageId,
    int? workingId)
        {
            var query = _context.Products
                .Include(p => p.ProductModel)
                    .ThenInclude(m => m.UsageTypes)
                .Include(p => p.ProductModel)
                    .ThenInclude(m => m.WorkingConditions)
                .Where(p => productIds.Contains(p.Id));

            // 🟢 Usage filtresi
            if (usageId.HasValue)
            {
                query = query.Where(p =>
                    p.ProductModel != null &&
                    p.ProductModel.UsageTypes.Any(u => u.Id == usageId.Value));
            }

            // 🔵 WorkingCondition filtresi
            if (workingId.HasValue)
            {
                query = query.Where(p =>
                    p.ProductModel != null &&
                    p.ProductModel.WorkingConditions.Any(w => w.Id == workingId.Value));
            }

            return await query.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
