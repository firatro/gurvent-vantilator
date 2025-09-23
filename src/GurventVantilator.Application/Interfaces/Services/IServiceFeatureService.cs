using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface IServiceFeatureService
    {
        Task<Result<ServiceFeatureDto>> GetByIdAsync(int id);
        Task<Result<List<ServiceFeatureDto>>> GetAllByIdAsync(int serviceId);
        Task<Result<ServiceFeatureDto>> AddAsync(ServiceFeatureDto dto, int serviceId);
        Task<Result<bool>> UpdateAsync(ServiceFeatureDto dto);
        Task<Result<bool>> DeleteAsync(int id);
    }
}
