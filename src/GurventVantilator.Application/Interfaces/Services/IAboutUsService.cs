using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Interfaces
{
    public interface IAboutUsService
    {
        Task<Result<AboutUsDto>> GetAsync();
        Task<Result<AboutUsDto>> UpdateAsync(AboutUsDto dto);
    }
}
