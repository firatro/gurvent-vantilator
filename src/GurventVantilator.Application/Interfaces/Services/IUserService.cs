using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Common;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<Result<IEnumerable<UserDto>>> GetAllAsync();
        Task<Result<UserDto>> CreateAsync(CreateUserDto dto);
        Task<Result> UpdateStatusAsync(UpdateUserDto dto);
        Task<Result> ResetPasswordAsync(ResetPasswordDto dto);
        Task<Result<UserDto>> GetCurrentUserAsync(string userName);
        Task<Result> UpdateProfileAsync(UpdateProfileDto dto);
        Task<Result> DeleteAsync(int id);
    }
}
