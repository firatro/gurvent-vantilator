using GurventVantilator.Domain.Entities;

namespace GurventVantilator.Domain.Interfaces.Repositories;

public interface IProductTestDataRepository
{
    Task AddRangeAsync(IEnumerable<ProductTestData> entities, CancellationToken ct = default);
    Task DeleteByProductIdAsync(int productId, CancellationToken ct = default);
    Task<ProductTestData?> GetByProductIdAsync(int productId);
    Task<List<ProductTestData>> GetByProductIdsAsync(List<int> productIds);
    Task<List<ProductTestPointRow>> GetQ1Pt1ByProductIdsAsync(List<int> productIds);
    Task<List<ProductTestData>> GetAllByProductIdAsync(int productId);
}

public class ProductTestPointRow
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = "";
    public decimal? Q1 { get; set; }
    public decimal? Pt1 { get; set; }
}
