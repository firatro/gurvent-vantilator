using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface IBeforeAfterService
    {
        Task<Result<IEnumerable<BeforeAfterDto>>> GetAllAsync();
        Task<Result<BeforeAfterDto>> GetByIdAsync(int id);
        Task<Result<BeforeAfterDto>> AddAsync(BeforeAfterDto dto);
        Task<Result<BeforeAfterDto>> UpdateAsync(BeforeAfterDto dto);
        Task<Result<bool>> DeleteAsync(int id);
    }
}
