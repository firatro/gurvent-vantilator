using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Repositories;
using GurventVantilator.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GurventVantilator.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public UserRepository(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var list = new List<UserDto>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                list.Add(new UserDto
                {
                    Id = user.Id,
                    UserName = user.UserName ?? "",
                    Email = user.Email ?? "",
                    FirstName = user.FirstName ?? "",
                    LastName = user.LastName ?? "",
                    IsActive = user.IsActive,
                    Roles = roles.ToList()
                });
            }

            return list;
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) return null;

            var roles = await _userManager.GetRolesAsync(user);

            return new UserDto
            {
                Id = user.Id,
                UserName = user.UserName!,
                Email = user.Email!,
                FirstName = user.FirstName!,
                LastName = user.LastName!,
                IsActive = user.IsActive,
                Roles = roles.ToList()
            };
        }

        public async Task<Result<UserDto>> CreateAsync(CreateUserDto dto)
        {
            var user = new ApplicationUser
            {
                UserName = dto.UserName,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                IsActive = true,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
                return Result<UserDto>.Fail(string.Join(", ", result.Errors.Select(e => e.Description)));

            await _userManager.AddToRoleAsync(user, "Admin");

            return Result<UserDto>.Ok(new UserDto
            {
                Id = user.Id,
                UserName = user.UserName!,
                Email = user.Email!,
                FirstName = user.FirstName!,
                LastName = user.LastName!,
                IsActive = user.IsActive,
                Roles = new List<string> { "Admin" }
            });
        }

        public async Task<Result> UpdateStatusAsync(UpdateUserDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.Id.ToString());
            if (user == null)
                return Result.Fail("Kullanıcı bulunamadı.");

            user.IsActive = dto.IsActive;
            var result = await _userManager.UpdateAsync(user);

            return result.Succeeded ? Result.Ok() : Result.Fail("Durum güncellenemedi.");
        }

        public async Task<Result> ResetPasswordAsync(ResetPasswordDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.UserId.ToString());
            if (user == null)
                return Result.Fail("Kullanıcı bulunamadı.");

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetResult = await _userManager.ResetPasswordAsync(user, token, dto.NewPassword);

            return resetResult.Succeeded ? Result.Ok() : Result.Fail("Şifre sıfırlanamadı.");
        }

        public async Task<UserDto?> GetCurrentUserAsync(string userName)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == userName);
            if (user == null)
                return null;

            var roles = await _userManager.GetRolesAsync(user);
            return new UserDto
            {
                Id = user.Id,
                UserName = user.UserName!,
                Email = user.Email!,
                FirstName = user.FirstName!,
                LastName = user.LastName!,
                IsActive = user.IsActive,
                Roles = roles.ToList()
            };
        }

        public async Task<Result> UpdateProfileAsync(UpdateProfileDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.Id.ToString());
            if (user == null)
                return Result.Fail("Kullanıcı bulunamadı.");

            // 🔹 Yalnızca profil bilgilerini güncelle
            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Email = dto.Email;
            user.NormalizedEmail = dto.Email.ToUpperInvariant();

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
                return Result.Fail(string.Join(", ", updateResult.Errors.Select(e => e.Description)));

            // 🔹 Şifre değişikliği varsa
            if (!string.IsNullOrEmpty(dto.NewPassword))
            {
                if (string.IsNullOrEmpty(dto.CurrentPassword))
                    return Result.Fail("Mevcut şifre gerekli.");

                var passwordResult = await _userManager.ChangePasswordAsync(user, dto.CurrentPassword, dto.NewPassword);
                if (!passwordResult.Succeeded)
                    return Result.Fail(string.Join(", ", passwordResult.Errors.Select(e => e.Description)));
            }

            return Result.Ok();
        }

        public async Task<Result> DeleteAsync(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return Result.Fail("Kullanıcı bulunamadı.");

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                var error = string.Join(", ", result.Errors.Select(e => e.Description));
                return Result.Fail($"Kullanıcı silinemedi: {error}");
            }

            return Result.Ok();
        }


    }
}
