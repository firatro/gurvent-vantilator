using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface IProductUsageTypeService
    {
        Task<Result<IEnumerable<ProductUsageTypeDto>>> GetAllAsync();
        Task<Result<ProductUsageTypeDto>> GetByIdAsync(int id);
        Task<Result<ProductUsageTypeDto>> AddAsync(ProductUsageTypeDto dto);
        Task<Result<ProductUsageTypeDto>> UpdateAsync(ProductUsageTypeDto dto);
        Task<Result<bool>> DeleteAsync(int id);
    }
}
