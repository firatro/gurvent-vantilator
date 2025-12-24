using GurventVantilator.Domain.Entities;
using GurventVantilator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GurventVantilator.Infrastructure.Persistence.Repositories;

public class ProductTestDataRepository : IProductTestDataRepository
{
    private readonly AppDbContext _context;

    public ProductTestDataRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ProductTestData?> GetActiveByProductIdAsync(int productId)
    {
        return await _context.ProductTestDatas
            .Include(x => x.Points)
            .FirstOrDefaultAsync(x =>
                x.ProductId == productId &&
                x.IsActive);
    }

    public async Task<ProductTestData?> GetByIdAsync(int id)
    {
        return await _context.ProductTestDatas
            .Include(x => x.Points)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(ProductTestData testData)
    {
        _context.ProductTestDatas.Add(testData);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ProductTestData testData)
    {
        _context.ProductTestDatas.Update(testData);
        await _context.SaveChangesAsync();
    }
    public async Task<List<ProductTestData>> GetListWithProductAsync()
    {
        return await _context.ProductTestDatas
            .AsNoTracking()
            .Include(x => x.Product)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();
    }

}
