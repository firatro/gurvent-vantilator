using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface ITagService
    {
        Task<Result<IEnumerable<TagDto>>> GetAllAsync();
        Task<Result<TagDto>> GetByIdAsync(int id);
        Task<Result<TagDto>> AddAsync(TagDto dto);
        Task<Result<bool>> UpdateAsync(TagDto dto);
        Task<Result<bool>> DeleteAsync(int id);
    }
}
