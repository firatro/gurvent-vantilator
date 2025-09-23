using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface IServiceService
    {
        Task<Result<ServiceDto>> GetByIdAsync(int id);
        Task<Result<IEnumerable<ServiceDto>>> GetAllAsync();
        Task<Result<ServiceDto>> AddAsync(ServiceDto dto);
        Task<Result<ServiceDto>> UpdateAsync(ServiceDto dto);
        Task<Result<bool>> DeleteAsync(int id);
    }
}
