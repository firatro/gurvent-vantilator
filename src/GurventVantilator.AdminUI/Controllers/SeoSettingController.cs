using GurventVantilator.AdminUI.Models.SeoSetting;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.AdminUI.Mappings;
using Microsoft.AspNetCore.Mvc;
using GurventVantilator.Application.Enums;

namespace GurventVantilator.AdminUI.Controllers
{
    public class SeoSettingController : Controller
    {
        private readonly ISeoSettingService _seoSettingService;
        private readonly IFileService _fileService;

        public SeoSettingController(ISeoSettingService seoSettingService, IFileService fileService)
        {
            _seoSettingService = seoSettingService;
            _fileService = fileService;
        }

        public async Task<IActionResult> Edit()
        {
            var result = await _seoSettingService.GetAsync();
            if (!result.Success || result.Data == null)
            {
                TempData["Error"] = result.ErrorMessage ?? "SEO ayarları yüklenemedi.";
                return RedirectToAction("Index", "Home"); // fallback route
            }

            var vm = result.Data.ToEditViewModel();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SeoSettingEditViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var existingResult = await _seoSettingService.GetAsync();
            if (!existingResult.Success || existingResult.Data == null)
                return NotFound();

            var existing = existingResult.Data;

            var imagePath = vm.DefaultOgImageFile != null
                ? await _fileService.SaveFileAsync(vm.DefaultOgImageFile, "uploads/images/seo-setting", FileType.Image)
                : existing.DefaultOgImagePath;

            var dto = vm.ToDto(imagePath);

            var updateResult = await _seoSettingService.UpdateAsync(dto);

            if (!updateResult.Success)
            {
                ModelState.AddModelError("", updateResult.ErrorMessage ?? "SEO ayarları güncellenemedi.");
                return View(vm);
            }

            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde güncellendi.";
            return RedirectToAction(nameof(Edit));
        }
    }

}
