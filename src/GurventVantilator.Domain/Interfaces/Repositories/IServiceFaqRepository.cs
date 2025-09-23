using GurventVantilator.Domain.Entities;

namespace GurventVantilator.Domain.Interfaces.Repositories
{
    public interface IServiceFaqRepository
    {
        Task<ServiceFaq?> GetByIdAsync(int serviceFaqId);
        Task<List<ServiceFaq>> GetAllByIdAsync(int serviceId);
        Task AddAsync(ServiceFaq serviceFaq);
        Task UpdateAsync(ServiceFaq serviceFaq);
        Task DeleteAsync(ServiceFaq serviceFaq);
    }
}
