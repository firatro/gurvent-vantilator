using GurventVantilator.Domain.Entities;

namespace GurventVantilator.Domain.Interfaces.Repositories
{
    public interface IFaqRepository
    {
        Task<List<Faq>> GetAllAsync();
        Task<Faq?> GetByIdAsync(int faqId);
        Task AddAsync(Faq faq);
        Task UpdateAsync(Faq faq);
        Task DeleteAsync(Faq faq);
    }
}
