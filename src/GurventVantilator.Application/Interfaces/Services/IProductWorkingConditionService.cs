using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface IProductWorkingConditionService
    {
        Task<Result<IEnumerable<ProductWorkingConditionDto>>> GetAllAsync();
        Task<Result<ProductWorkingConditionDto>> GetByIdAsync(int id);
        Task<Result<ProductWorkingConditionDto>> AddAsync(ProductWorkingConditionDto dto);
        Task<Result<ProductWorkingConditionDto>> UpdateAsync(ProductWorkingConditionDto dto);
        Task<Result<bool>> DeleteAsync(int id);
    }
}
