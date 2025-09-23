using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface IVersionInfoService
    {
        Task<Result<IReadOnlyList<VersionInfoDto>>> GetAllAsync();
        Task<Result<VersionInfoDto>> GetByIdAsync(int id);
        Task<Result<VersionInfoDto>> GetActiveAsync();
        Task<Result<VersionInfoDto>> AddAsync(VersionInfoDto dto);
        Task<Result<bool>> UpdateAsync(VersionInfoDto dto);
        Task<Result<bool>> DeleteAsync(int id);
        Task<Result<bool>> SetActiveAsync(int id);
    }
}
