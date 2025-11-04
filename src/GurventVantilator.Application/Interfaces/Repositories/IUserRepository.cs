using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Common;

namespace GurventVantilator.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto?> GetByIdAsync(int id);
        Task<Result<UserDto>> CreateAsync(CreateUserDto dto);
        Task<Result> UpdateStatusAsync(UpdateUserDto dto);
        Task<Result> ResetPasswordAsync(ResetPasswordDto dto);
        Task<UserDto?> GetCurrentUserAsync(string userName);
        Task<Result> UpdateProfileAsync(UpdateProfileDto dto);
        Task<Result> DeleteAsync(int id);
    }
}
