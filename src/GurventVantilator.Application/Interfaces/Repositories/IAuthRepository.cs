using GurventVantilator.Application.DTOs;
using Microsoft.AspNetCore.Identity;

namespace GurventVantilator.Application.Interfaces.Repositories
{
    public interface IAuthRepository
    {
        Task<AuthUserDto?> FindByUserNameOrEmailAsync(string userNameOrEmail);
        Task<SignInResult> SignInAsync(AuthUserDto user, string password, bool rememberMe);
        Task SignOutAsync();
    }
}
