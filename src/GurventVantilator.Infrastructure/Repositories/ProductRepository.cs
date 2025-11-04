using GurventVantilator.Domain.Interfaces.Repositories;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GurventVantilator.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
                .Include(p => p.ProductCategory)
                .Include(p => p.Applications)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.ProductCategory)
                .Include(p => p.Applications)
                .Include(p => p.ContentFeatures)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Product product)
        {
            if (product.Applications != null && product.Applications.Any())
            {
                foreach (var app in product.Applications)
                {
                    _context.Attach(app);
                }
            }

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(Product product)
        {
            var existing = await _context.Products
                .Include(p => p.Applications)
                .Include(p => p.ProductCategory)
                .FirstOrDefaultAsync(p => p.Id == product.Id);

            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(product);

                existing.Applications.Clear();

                if (product.Applications != null && product.Applications.Any())
                {
                    foreach (var app in product.Applications)
                    {
                        _context.Attach(app);
                        existing.Applications.Add(app);
                    }
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<(IEnumerable<Product> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = _context.Products
                .Include(p => p.ProductCategory)
                .Include(p => p.Applications)
                .OrderByDescending(p => p.CreatedAt);

            var totalCount = await query.CountAsync();
            var items = await query.Skip((pageNumber - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToListAsync();

            return (items, totalCount);
        }
    }
}
