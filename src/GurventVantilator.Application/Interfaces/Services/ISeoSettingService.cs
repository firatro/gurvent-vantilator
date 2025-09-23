using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface ISeoSettingService
    {
        Task<Result<SeoSettingDto>> GetAsync();
        Task<Result<SeoSettingDto>> UpdateAsync(SeoSettingDto dto);
    }
}
