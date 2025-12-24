// using GurventVantilator.Domain.Interfaces.Repositories;
// using GurventVantilator.Domain.Entities;
// using GurventVantilator.Infrastructure.Data;
// using Microsoft.EntityFrameworkCore;

// namespace GurventVantilator.Infrastructure.Repositories
// {
//     public class ProductCategoryRepository : IProductCategoryRepository
//     {
//         private readonly AppDbContext _context;

//         public ProductCategoryRepository(AppDbContext context)
//         {
//             _context = context;
//         }

//         public async Task<IEnumerable<ProductCategory>> GetAllAsync(bool asNoTracing = false)
//         {
//             if (asNoTracing)
//             {
//                 return await _context.ProductCategories.AsNoTracking().ToListAsync();
//             }

//             return await _context.ProductCategories.ToListAsync();
//         }

//         public async Task<ProductCategory?> GetByIdAsync(int id)
//         {
//             return await _context.ProductCategories.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
//         }


//         public async Task AddAsync(ProductCategory productCategory)
//         {
//             await _context.ProductCategories.AddAsync(productCategory);
//             await _context.SaveChangesAsync();
//         }


//         public async Task UpdateAsync(ProductCategory productCategory)
//         {
//             _context.ProductCategories.Update(productCategory);
//             await _context.SaveChangesAsync();
//         }

//         public async Task DeleteAsync(ProductCategory productCategory)
//         {
//             _context.ProductCategories.Remove(productCategory);
//             await _context.SaveChangesAsync();
//         }
//     }
// }
