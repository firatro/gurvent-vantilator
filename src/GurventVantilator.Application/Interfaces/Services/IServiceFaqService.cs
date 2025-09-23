using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface IServiceFaqService
    {
        Task<Result<ServiceFaqDto>> GetByIdAsync(int id);
        Task<Result<IReadOnlyList<ServiceFaqDto>>> GetAllByIdAsync(int serviceId);
        Task<Result<ServiceFaqDto>> AddAsync(ServiceFaqDto dto, int serviceId);
        Task<Result<bool>> UpdateAsync(ServiceFaqDto dto);
        Task<Result<bool>> DeleteAsync(int id);
    }
}
