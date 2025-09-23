using GurventVantilator.Domain.Entities;

namespace GurventVantilator.Domain.Interfaces.Repositories
{
    public interface IServiceFeatureRepository
    {
        Task<ServiceFeature?> GetByIdAsync(int serviceFeature);
        Task<List<ServiceFeature>> GetAllByIdAsync(int serviceId);
        Task AddAsync(ServiceFeature serviceFeature);
        Task UpdateAsync(ServiceFeature serviceFeature);
        Task DeleteAsync(ServiceFeature serviceFeature);
    }
}
