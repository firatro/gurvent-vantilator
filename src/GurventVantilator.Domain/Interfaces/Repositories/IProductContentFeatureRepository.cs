using GurventVantilator.Domain.Entities;

namespace GurventVantilator.Domain.Interfaces.Repositories
{
    public interface IProductContentFeatureRepository
    {
        Task<IEnumerable<ProductContentFeature>> GetAllAsync(bool asNoTracking = false);
        Task<ProductContentFeature?> GetByIdAsync(int id);
        Task<IEnumerable<ProductContentFeature>> GetByProductIdAsync(int productId, bool asNoTracking = false);
        Task AddAsync(ProductContentFeature feature);
        Task UpdateAsync(ProductContentFeature feature);
        Task DeleteAsync(ProductContentFeature feature);
    }
}
