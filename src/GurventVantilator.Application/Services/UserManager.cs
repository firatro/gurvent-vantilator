using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Repositories;
using GurventVantilator.Application.Interfaces.Services;

namespace GurventVantilator.Application.Services
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<IEnumerable<UserDto>>> GetAllAsync()
        {
            try
            {
                var users = await _userRepository.GetAllAsync();
                return Result<IEnumerable<UserDto>>.Ok(users);
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<UserDto>>.Fail($"Kullanıcı listesi alınamadı: {ex.Message}");
            }
        }

        public async Task<Result<UserDto>> CreateAsync(CreateUserDto dto)
        {
            try
            {
                return await _userRepository.CreateAsync(dto);
            }
            catch (Exception ex)
            {
                return Result<UserDto>.Fail($"Kullanıcı oluşturulamadı: {ex.Message}");
            }
        }

        public async Task<Result> UpdateStatusAsync(UpdateUserDto dto)
        {
            try
            {
                return await _userRepository.UpdateStatusAsync(dto);
            }
            catch (Exception ex)
            {
                return Result.Fail($"Durum güncellenemedi: {ex.Message}");
            }
        }

        public async Task<Result> ResetPasswordAsync(ResetPasswordDto dto)
        {
            try
            {
                return await _userRepository.ResetPasswordAsync(dto);
            }
            catch (Exception ex)
            {
                return Result.Fail($"Şifre sıfırlanamadı: {ex.Message}");
            }
        }

        public async Task<Result<UserDto>> GetCurrentUserAsync(string userName)
        {
            try
            {
                var user = await _userRepository.GetCurrentUserAsync(userName);
                if (user == null)
                    return Result<UserDto>.Fail("Kullanıcı bulunamadı.");

                return Result<UserDto>.Ok(user);
            }
            catch (Exception ex)
            {
                return Result<UserDto>.Fail($"Profil yüklenemedi: {ex.Message}");
            }
        }

        public async Task<Result> UpdateProfileAsync(UpdateProfileDto dto)
        {
            try
            {
                return await _userRepository.UpdateProfileAsync(dto);
            }
            catch (Exception ex)
            {
                return Result.Fail($"Profil güncellenemedi: {ex.Message}");
            }
        }

        public async Task<Result> DeleteAsync(int id)
        {
            try
            {
                return await _userRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return Result.Fail($"Kullanıcı silinirken hata oluştu: {ex.Message}");
            }
        }

    }
}
