using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface ISiteInfoService
    {
        Task<Result<SiteInfoDto>> GetAsync();
        Task<Result<bool>> UpdateAsync(SiteInfoDto dto);
    }
}
