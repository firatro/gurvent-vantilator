using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Repositories;
using GurventVantilator.Application.Interfaces.Services;

namespace GurventVantilator.Application.Services
{
    public class AuthManager : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthManager(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<Result<AuthUserDto>> LoginAsync(string userNameOrEmail, string password, bool rememberMe)
        {
            try
            {
                var user = await _authRepository.FindByUserNameOrEmailAsync(userNameOrEmail);
                if (user == null)
                    return Result<AuthUserDto>.Fail("Kullanıcı bulunamadı.");

                if (!user.IsActive)
                    return Result<AuthUserDto>.Fail("Kullanıcı pasif durumda.");

                var result = await _authRepository.SignInAsync(user, password, rememberMe);
                if (!result.Succeeded)
                    return Result<AuthUserDto>.Fail("Giriş başarısız. Bilgileri kontrol edin.");

                return Result<AuthUserDto>.Ok(user);
            }
            catch (Exception ex)
            {
                return Result<AuthUserDto>.Fail($"Giriş sırasında hata oluştu: {ex.Message}");
            }
        }

        public async Task<Result> LogoutAsync()
        {
            try
            {
                await _authRepository.SignOutAsync();
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail($"Çıkış sırasında hata oluştu: {ex.Message}");
            }
        }
    }
}
