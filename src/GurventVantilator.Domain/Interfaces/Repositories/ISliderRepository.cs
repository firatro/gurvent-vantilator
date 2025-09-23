using GurventVantilator.Domain.Entities;

namespace GurventVantilator.Domain.Interfaces.Repositories
{
    public interface ISliderRepository
    {
        Task<List<Slider>> GetAllAsync();
        Task<Slider?> GetByIdAsync(int sliderId);
        Task AddAsync(Slider slider);
        Task UpdateAsync(Slider slider);
        Task DeleteAsync(Slider slider);
    }
}
