using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface IPageImageService
    {
        Task<Result<PageImageDto>> GetImageAsync(string pageKey, string imageType);
        Task<Result<IEnumerable<PageImageDto>>> GetAllAsync();
        Task<Result<PageImageDto>> GetByIdAsync(int id);
        Task<Result<PageImageDto>> AddAsync(PageImageDto dto);
        Task<Result<PageImageDto>> UpdateAsync(PageImageDto dto);
        Task<Result<bool>> DeleteAsync(int id);
    }
}
