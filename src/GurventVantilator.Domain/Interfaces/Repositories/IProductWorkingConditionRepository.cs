using GurventVantilator.Domain.Entities;

namespace GurventVantilator.Domain.Interfaces.Repositories
{
    public interface IProductWorkingConditionRepository
    {
        Task<List<ProductWorkingCondition>> GetAllAsync();
        Task<ProductWorkingCondition?> GetByIdAsync(int id);
        Task AddAsync(ProductWorkingCondition entity);
        Task UpdateAsync(ProductWorkingCondition entity);
        Task DeleteAsync(ProductWorkingCondition entity);

        Task<List<ProductWorkingCondition>> GetByIdsAsync(IEnumerable<int> ids);
    }
}
