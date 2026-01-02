using GurventVantilator.Domain.Entities;

namespace GurventVantilator.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int productId);
        Task<Product?> GetByIdWithIncludesAsync(int productId);
        Task<List<Product>> GetByModelIdAsync(int modelId);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
        Task<(List<Product> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize);
        Task<List<Product>> GetByIdsAsync(List<int> productIds);
        Task<List<Product>> GetByIdsWithModelAndUsageAsync(
            List<int> productIds,
            int? usageId);

        Task<List<Product>> GetByIdsWithModelFiltersAsync(
   List<int> productIds,
   int? usageId,
   int? workingId);
        Task SaveChangesAsync();

    }
}
