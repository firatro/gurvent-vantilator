using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface IVisionMissionService
    {
        Task<Result<VisionMissionDto>> GetAsync();
        Task<Result<bool>> UpdateAsync(VisionMissionDto dto);
    }
}
