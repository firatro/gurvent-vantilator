using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface ITestimonialService
    {
        Task<Result<TestimonialDto>> GetByIdAsync(int id);
        Task<Result<IReadOnlyList<TestimonialDto>>> GetAllAsync();
        Task<Result<TestimonialDto>> AddAsync(TestimonialDto dto);
        Task<Result<bool>> UpdateAsync(TestimonialDto dto);
        Task<Result<bool>> DeleteAsync(int id);
    }
}
