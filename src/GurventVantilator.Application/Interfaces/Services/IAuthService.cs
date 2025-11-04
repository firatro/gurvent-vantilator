using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<Result<AuthUserDto>> LoginAsync(string userNameOrEmail, string password, bool rememberMe);
        Task<Result> LogoutAsync();
    }
}
