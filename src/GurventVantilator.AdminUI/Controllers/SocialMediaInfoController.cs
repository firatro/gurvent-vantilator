using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.AdminUI.Controllers
{
    public class SocialMediaInfoController : Controller
    {
        private readonly ISocialMediaInfoService _socialMediaInfoService;

        public SocialMediaInfoController(ISocialMediaInfoService socialMediaInfoService)
        {
            _socialMediaInfoService = socialMediaInfoService;
        }

        public async Task<IActionResult> Edit()
        {
            var result = await _socialMediaInfoService.GetAsync();

            if (!result.Success || result.Data == null)
            {
                return View(new SocialMediaInfoDto());
            }

            return View(result.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SocialMediaInfoDto socialMediaInfo)
        {
            if (!ModelState.IsValid)
                return View(socialMediaInfo);

            var updateResult = await _socialMediaInfoService.UpdateAsync(socialMediaInfo);

            if (!updateResult.Success)
            {
                ModelState.AddModelError("", updateResult.ErrorMessage ?? "Sosyal medya bilgisi güncellenemedi.");
                return View(socialMediaInfo);
            }

            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde güncellendi.";
            return RedirectToAction(nameof(Edit));
        }
    }

}
