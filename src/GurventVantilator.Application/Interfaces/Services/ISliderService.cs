using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface ISliderService
    {
        Task<Result<SliderDto>> GetByIdAsync(int id);
        Task<Result<List<SliderDto>>> GetAllAsync();
        Task<Result<SliderDto>> AddAsync(SliderDto dto);
        Task<Result<bool>> UpdateAsync(SliderDto dto);
        Task<Result<bool>> DeleteAsync(int id);
    }
}
