using System.Security.Claims;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Repositories;
using GurventVantilator.Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GurventVantilator.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthRepository(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<AuthUserDto?> FindByUserNameOrEmailAsync(string userNameOrEmail)
        {
            var user = await _userManager.Users
                .FirstOrDefaultAsync(u => u.UserName == userNameOrEmail || u.Email == userNameOrEmail);

            if (user == null)
                return null;

            return new AuthUserDto
            {
                Id = user.Id,
                UserName = user.UserName!,
                Email = user.Email!,
                IsActive = user.IsActive
            };
        }

        public async Task<SignInResult> SignInAsync(AuthUserDto dto, string password, bool rememberMe)
        {
            var user = await _userManager.FindByIdAsync(dto.Id.ToString());
            if (user == null)
                return SignInResult.Failed;

            // 🔹 Normal Identity login işlemi
            var result = await _signInManager.PasswordSignInAsync(user, password, rememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                // 🔹 Claim setini oluştur
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName ?? string.Empty), // ✅ EKLENDİ
                    new Claim("FullName", $"{user.FirstName} {user.LastName}"),
                    new Claim("UserName", user.UserName ?? string.Empty),
                    new Claim("Email", user.Email ?? string.Empty)
                };

                var userRoles = await _userManager.GetRolesAsync(user);
                foreach (var role in userRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                // 🔹 Claims ile cookie oluştur
                var identity = new ClaimsIdentity(claims, "Identity.Application");
                var principal = new ClaimsPrincipal(identity);

                await _signInManager.Context.SignInAsync(
                    "Identity.Application",
                    principal,
                    new AuthenticationProperties { IsPersistent = rememberMe });
            }

            return result;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
