// using GurventVantilator.Domain.Entities;
// using GurventVantilator.Domain.Interfaces.Repositories;
// using GurventVantilator.Infrastructure.Data;
// using Microsoft.EntityFrameworkCore;

// namespace GurventVantilator.Infrastructure.Repositories
// {
//     public class ProductApplicationRepository : IProductApplicationRepository
//     {
//         private readonly AppDbContext _context;

//         public ProductApplicationRepository(AppDbContext context)
//         {
//             _context = context;
//         }

//         public async Task<IEnumerable<ProductApplication>> GetAllAsync()
//         {
//             return await _context.ProductApplications
//                 .Include(a => a.Products)
//                 .ToListAsync();
//         }

//         public async Task<ProductApplication?> GetByIdAsync(int id)
//         {
//             return await _context.ProductApplications
//                 .Include(a => a.Products)
//                 .AsNoTracking()
//                 .FirstOrDefaultAsync(a => a.Id == id);
//         }

//         public async Task AddAsync(ProductApplication application)
//         {
//             await _context.ProductApplications.AddAsync(application);
//             await _context.SaveChangesAsync();
//         }

//         public async Task UpdateAsync(ProductApplication application)
//         {
//             var existing = await _context.ProductApplications
//                 .FirstOrDefaultAsync(a => a.Id == application.Id);

//             if (existing != null)
//             {
//                 _context.Entry(existing).CurrentValues.SetValues(application);
//             }

//             await _context.SaveChangesAsync();
//         }

//         public async Task DeleteAsync(ProductApplication application)
//         {
//             _context.ProductApplications.Remove(application);
//             await _context.SaveChangesAsync();
//         }

//         public async Task<(IEnumerable<ProductApplication> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize)
//         {
//             var query = _context.ProductApplications
//                 .OrderBy(a => a.Name);

//             var totalCount = await query.CountAsync();
//             var items = await query.Skip((pageNumber - 1) * pageSize)
//                                    .Take(pageSize)
//                                    .ToListAsync();

//             return (items, totalCount);
//         }
//     }
// }
