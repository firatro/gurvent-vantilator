using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface ISocialMediaInfoService
    {
        Task<Result<SocialMediaInfoDto>> GetAsync();
        Task<Result<bool>> UpdateAsync(SocialMediaInfoDto dto);
    }
}
