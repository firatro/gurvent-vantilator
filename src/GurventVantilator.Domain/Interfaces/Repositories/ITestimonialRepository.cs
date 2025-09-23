using GurventVantilator.Domain.Entities;

namespace GurventVantilator.Domain.Interfaces.Repositories
{
    public interface ITestimonialRepository
    {
        Task<List<Testimonial>> GetAllAsync();
        Task<Testimonial?> GetByIdAsync(int testimonialId);
        Task AddAsync(Testimonial testimonial);
        Task UpdateAsync(Testimonial testimonial);
        Task DeleteAsync(Testimonial testimonial);
    }
}
