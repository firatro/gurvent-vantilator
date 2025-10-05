using GurventVantilator.Domain.Entities;

namespace GurventVantilator.Domain.Interfaces.Repositories
{
    public interface IProductCategoryRepository
    {
        Task<IEnumerable<ProductCategory>> GetAllAsync();
        Task<ProductCategory?> GetByIdAsync(int ProductCategoryId);
        Task AddAsync(ProductCategory ProductCategory);
        Task UpdateAsync(ProductCategory ProductCategory);
        Task DeleteAsync(ProductCategory ProductCategory);
    }
}
