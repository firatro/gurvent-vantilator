using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface IFaqService
    {
        Task<Result<IEnumerable<FaqDto>>> GetAllAsync();
        Task<Result<FaqDto>> GetByIdAsync(int id);
        Task<Result<FaqDto>> AddAsync(FaqDto dto);
        Task<Result<FaqDto>> UpdateAsync(FaqDto dto);
        Task<Result<bool>> DeleteAsync(int id);
    }
}
