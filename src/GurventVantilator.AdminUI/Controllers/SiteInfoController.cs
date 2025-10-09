using GurventVantilator.AdminUI.Mappings;
using GurventVantilator.AdminUI.Models.SiteInfo;
using GurventVantilator.Application.Enums;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.AdminUI.Controllers
{
    public class SiteInfoController : Controller
    {
        private readonly ISiteInfoService _siteInfoService;
        private readonly IFileService _fileService;

        public SiteInfoController(ISiteInfoService siteInfoService, IFileService fileService)
        {
            _siteInfoService = siteInfoService;
            _fileService = fileService;
        }

        public async Task<IActionResult> Edit()
        {
            var result = await _siteInfoService.GetAsync();
            if (!result.Success || result.Data == null)
            {
                ViewBag.ErrorMessage = result.ErrorMessage ?? "Site bilgisi yüklenemedi.";
                return View(new SiteInfoEditViewModel()); // Boş model ile dön
            }

            var vm = result.Data.ToEditViewModel();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SiteInfoEditViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var existingResult = await _siteInfoService.GetAsync();
            if (!existingResult.Success || existingResult.Data == null)
                return NotFound();

            var existing = existingResult.Data;

            var logoPath = vm.LogoFile != null
                ? await _fileService.SaveFileAsync(vm.LogoFile, "uploads/images/site-info", FileType.Image)
                : existing.LogoPath;

            var dto = vm.ToDto(logoPath);

            var updateResult = await _siteInfoService.UpdateAsync(dto);

            if (!updateResult.Success)
            {
                ModelState.AddModelError("", updateResult.ErrorMessage ?? "Site bilgisi güncellenemedi.");
                return View(vm);
            }

            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde başarıyla güncellendi.";
            return RedirectToAction(nameof(Edit));
        }
    }

}
