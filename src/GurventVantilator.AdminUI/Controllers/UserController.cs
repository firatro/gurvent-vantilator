using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.AdminUI.Controllers
{
    [Authorize(Roles = "DevAdmin")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(
            IUserService userService,
            IFileService fileService
        ) : base(fileService)
        {
            _userService = userService;
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

            return View(result.Data);
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

        // ✅ Kullanıcı Aktif/Pasif Durum Değiştirme
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
