using GurventVantilator.Domain.Entities;

namespace GurventVantilator.Domain.Interfaces.Repositories
{
    public interface IAboutUsRepository
    {
        Task<AboutUs?> GetAsync();
        Task UpdateAsync(AboutUs aboutUs);
    }
}