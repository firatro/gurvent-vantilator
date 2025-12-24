using GurventVantilator.Domain.Entities;

public interface IProductTestDataRepository
{
    Task<ProductTestData?> GetActiveByProductIdAsync(int productId);
    Task<ProductTestData?> GetByIdAsync(int id);

    Task AddAsync(ProductTestData testData);
    Task UpdateAsync(ProductTestData testData);
    Task<List<ProductTestData>> GetListWithProductAsync();

}
