using GurventVantilator.Domain.Entities;

namespace GurventVantilator.Domain.Interfaces.Repositories
{
    public interface IProductSeriesRepository
    {
        Task<List<ProductSeries>> GetAllAsync();
        Task<ProductSeries?> GetByIdAsync(int id);
        Task AddAsync(ProductSeries entity);
        Task UpdateAsync(ProductSeries entity);
        Task DeleteAsync(ProductSeries entity);
        Task<List<ProductSeries>> GetByUsageOrWorkingAsync(int? usageTypeId, int? workingConditionId);
    }
}
