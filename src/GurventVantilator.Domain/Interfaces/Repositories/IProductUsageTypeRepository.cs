using GurventVantilator.Domain.Entities;

namespace GurventVantilator.Domain.Interfaces.Repositories
{
    public interface IProductUsageTypeRepository
    {
        Task<List<ProductUsageType>> GetAllAsync();
        Task<ProductUsageType?> GetByIdAsync(int id);
        Task AddAsync(ProductUsageType entity);
        Task UpdateAsync(ProductUsageType entity);
        Task DeleteAsync(ProductUsageType entity);

        Task<List<ProductUsageType>> GetByIdsAsync(IEnumerable<int> ids);
    }
}
