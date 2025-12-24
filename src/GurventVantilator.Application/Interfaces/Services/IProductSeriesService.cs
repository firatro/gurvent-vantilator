using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface IProductSeriesService
    {
        Task<Result<IEnumerable<ProductSeriesDto>>> GetAllAsync();
        Task<Result<ProductSeriesDto>> GetByIdAsync(int id);
        Task<Result<List<ProductSeriesDto>>> GetByFilterAsync(int? usageTypeId, int? workingConditionId);
        Task<Result<ProductSeriesDto>> AddAsync(ProductSeriesDto dto);
        Task<Result<ProductSeriesDto>> UpdateAsync(ProductSeriesDto dto);
        Task<Result<bool>> DeleteAsync(int id);
        Task<Result<bool>> ToggleStatusAsync(int id);
        Task<Result<bool>> CloneAsync(int id);

    }
}
