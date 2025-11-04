using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.AdminUI.Controllers
{
    [Authorize(Roles = "Admin,DevAdmin")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(
            IUserService userService,
            IFileService fileService,
            RoleManager<ApplicationRole> roleManager,
            UserManager<ApplicationUser> userManager
        ) : base(fileService)
        {
            _userService = userService;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // ✅ Kullanıcı Listesi
        public async Task<IActionResult> Index()
        {
            var result = await _userService.GetAllAsync();
            if (!result.Success || result.Data == null)
            {
                SetErrorMessage(result.ErrorMessage ?? "Kullanıcı listesi yüklenemedi.");
                return View(new List<UserDto>());
            }

            var users = result.Data;

            // 🔹 Admin, DevAdmin'i göremesin
            if (User.IsInRole("Admin") && !User.IsInRole("DevAdmin"))
            {
                users = users
                    .Where(u => !u.Roles.Any(r => r.Equals("DevAdmin", StringComparison.OrdinalIgnoreCase)))
                    .ToList();
            }

            var allRoles = _roleManager.Roles.ToList();
            ViewBag.AllRoles = allRoles;

            return View(users);
        }

        // ✅ Kullanıcıya Rol Ekle
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRole(int userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                SetErrorMessage("Kullanıcı bulunamadı.");
                return RedirectToAction(nameof(Index));
            }

            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                SetErrorMessage("Rol bulunamadı.");
                return RedirectToAction(nameof(Index));
            }

            var result = await _userManager.AddToRoleAsync(user, roleName);
            if (!result.Succeeded)
            {
                SetErrorMessage("Rol atanırken bir hata oluştu.");
                return RedirectToAction(nameof(Index));
            }

            SetSuccessMessage($"'{roleName}' rolü {user.FirstName} {user.LastName} kullanıcısına atandı.");
            return RedirectToAction(nameof(Index));
        }

        // ✅ Kullanıcıdan Rol Kaldır
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveRole(int userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                SetErrorMessage("Kullanıcı bulunamadı.");
                return RedirectToAction(nameof(Index));
            }

            var result = await _userManager.RemoveFromRoleAsync(user, roleName);
            if (!result.Succeeded)
            {
                SetErrorMessage("Rol kaldırılırken bir hata oluştu.");
                return RedirectToAction(nameof(Index));
            }

            SetSuccessMessage($"'{roleName}' rolü {user.FirstName} {user.LastName} kullanıcısından kaldırıldı.");
            return RedirectToAction(nameof(Index));
        }

        // ✅ Kullanıcı Oluşturma (GET)
        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateUserDto());
        }

        // ✅ Kullanıcı Oluşturma (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _userService.CreateAsync(dto);

            if (!result.Success)
            {
                SetErrorMessage(result.ErrorMessage ?? "Kullanıcı oluşturulamadı.");
                return View(dto);
            }

            SetSuccessMessage("Kullanıcı başarıyla oluşturuldu.");
            return RedirectToAction(nameof(Index));
        }

        // ✅ Kullanıcı Durumu Değiştirme
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleStatus(int id, bool isActive)
        {
            var result = await _userService.UpdateStatusAsync(new UpdateUserDto
            {
                Id = id,
                IsActive = isActive
            });

            if (!result.Success)
                return BadRequest(result.ErrorMessage);

            return Ok();
        }

        // ✅ Kullanıcı Silme
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int userId)
        {
            var result = await _userService.DeleteAsync(userId);

            if (!result.Success)
                SetErrorMessage(result.ErrorMessage ?? "Kullanıcı silinemedi.");
            else
                SetSuccessMessage("Kullanıcı başarıyla silindi.");

            return RedirectToAction(nameof(Index));
        }

        // ✅ Şifre Sıfırlama
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(int id, string newPassword)
        {
            var result = await _userService.ResetPasswordAsync(new ResetPasswordDto
            {
                UserId = id,
                NewPassword = newPassword
            });

            if (!result.Success)
                SetErrorMessage(result.ErrorMessage ?? "Şifre sıfırlanamadı.");
            else
                SetSuccessMessage($"Şifre '{newPassword}' olarak sıfırlandı.");

            return RedirectToAction(nameof(Index));
        }
    }
}
