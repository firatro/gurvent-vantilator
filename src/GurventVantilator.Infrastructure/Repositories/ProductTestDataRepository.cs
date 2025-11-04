using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using GurventVantilator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GurventVantilator.Infrastructure.Persistence.Repositories;

public class ProductTestDataRepository : IProductTestDataRepository
{
    private readonly AppDbContext _context;
    public ProductTestDataRepository(AppDbContext ctx) => _context = ctx;

    public async Task AddRangeAsync(IEnumerable<ProductTestData> entities, CancellationToken ct = default)
    {
        await _context.Set<ProductTestData>().AddRangeAsync(entities, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task DeleteByProductIdAsync(int productId, CancellationToken ct = default)
    {
        await _context.Set<ProductTestData>()
            .Where(x => x.ProductId == productId)
            .ExecuteDeleteAsync(ct);
    }

    public async Task<ProductTestData?> GetByProductIdAsync(int productId)
    {
        return await _context.ProductTestDatas
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ProductId == productId);
    }


    public async Task<List<ProductTestData>> GetByProductIdsAsync(List<int> productIds)
    {
        return await _context.ProductTestDatas
            .Include(x => x.Product)
            .Where(x => productIds.Contains(x.ProductId))
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<ProductTestPointRow>> GetQ1Pt1ByProductIdsAsync(List<int> productIds)
    {
        return await _context.ProductTestDatas
            .Where(x => productIds.Contains(x.ProductId))
            .Select(x => new ProductTestPointRow
            {
                ProductId = x.ProductId,
                ProductName = x.Product.Name,
                Q1 = x.Q1,     // yalnızca Q1
                Pt1 = x.Pt1    // yalnızca Pt1
            })
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<ProductTestData>> GetAllByProductIdAsync(int productId)
    {
        return await _context.ProductTestDatas
            .Where(x => x.ProductId == productId)
            .AsNoTracking()
            .ToListAsync();
    }



}
