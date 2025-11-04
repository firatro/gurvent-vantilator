using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.AdminUI.Controllers
{
    [Authorize]
    public class ProfileController : BaseController
    {
        private readonly IUserService _userService;

        public ProfileController(
            IUserService userService,
            IFileService fileService
        ) : base(fileService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userName = User.Identity?.Name;
            if (string.IsNullOrEmpty(userName))
            {
                SetErrorMessage("Kullanıcı oturumu bulunamadı. Lütfen giriş yapınız.");
                return RedirectToAction("Login", "Account");
            }

            var result = await _userService.GetCurrentUserAsync(userName);
            if (!result.Success || result.Data == null)
            {
                SetErrorMessage(result.ErrorMessage ?? "Kullanıcı bilgileri alınamadı.");
                return RedirectToAction("Login", "Account");
            }

            var dto = new UpdateProfileDto
            {
                Id = result.Data.Id,
                FirstName = result.Data.FirstName,
                LastName = result.Data.LastName,
                Email = result.Data.Email
            };

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(UpdateProfileDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _userService.UpdateProfileAsync(dto);

            if (!result.Success)
            {
                SetErrorMessage(result.ErrorMessage ?? "Profil güncelleme başarısız.");
                return View(dto);
            }

            SetSuccessMessage("Profil başarıyla güncellendi. Değişikliklerin yansıması için oturumu kapatıp yeniden giriş yapınız.");
            return RedirectToAction(nameof(Index));
        }
    }
}
