using GurventVantilator.Domain.Entities;

namespace GurventVantilator.Domain.Interfaces.Repositories
{
    public interface IBeforeAfterRepository
    {
        Task<List<BeforeAfter>> GetAllAsync();
        Task<BeforeAfter?> GetByIdAsync(int beforeAfterId);
        Task AddAsync(BeforeAfter beforeAfter);
        Task UpdateAsync(BeforeAfter beforeAfter);
        Task DeleteAsync(BeforeAfter beforeAfter);
    }
}