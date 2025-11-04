using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface IProductApplicationService
    {
        Task<Result<IEnumerable<ProductApplicationDto>>> GetAllAsync();
        Task<Result<ProductApplicationDto>> GetByIdAsync(int id);
        Task<Result<ProductApplicationDto>> AddAsync(ProductApplicationDto dto);
        Task<Result<ProductApplicationDto>> UpdateAsync(ProductApplicationDto dto);
        Task<Result<bool>> DeleteAsync(int id);
        Task<Result<PagedResult<ProductApplicationDto>>> GetPagedAsync(int pageNumber, int pageSize);
    }
}
