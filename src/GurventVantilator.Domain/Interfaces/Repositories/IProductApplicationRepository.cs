using GurventVantilator.Domain.Entities;

namespace GurventVantilator.Domain.Interfaces.Repositories
{
    public interface IProductApplicationRepository
    {
        Task<IEnumerable<ProductApplication>> GetAllAsync();
        Task<ProductApplication?> GetByIdAsync(int id);
        Task AddAsync(ProductApplication application);
        Task UpdateAsync(ProductApplication application);
        Task DeleteAsync(ProductApplication application);
        Task<(IEnumerable<ProductApplication> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize);
    }
}
