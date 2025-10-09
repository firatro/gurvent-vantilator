using GurventVantilator.AdminUI.Models.AboutUs;
using GurventVantilator.AdminUI.Mappings;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using GurventVantilator.Application.Interfaces;
using GurventVantilator.Application.Enums;

public class AboutUsController : Controller
{
    private readonly IAboutUsService _aboutUsService;
    private readonly IFileService _fileService;

    public AboutUsController(IAboutUsService aboutUsService, IFileService fileService)
    {
        _aboutUsService = aboutUsService;
        _fileService = fileService;
    }

    public async Task<IActionResult> Edit()
    {
        var result = await _aboutUsService.GetAsync();

        if (!result.Success || result.Data == null)
        {
            ViewBag.ErrorMessage = result.ErrorMessage ?? "Hakkımızda bilgisi yüklenemedi.";
            return View(new AboutUsEditViewModel()); // boş model dön
        }

        var vm = result.Data.ToEditViewModel();
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(AboutUsEditViewModel vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var existingResult = await _aboutUsService.GetAsync();
        if (!existingResult.Success || existingResult.Data == null)
            return NotFound();

        var existing = existingResult.Data;

        var imagePath = vm.ImageFile != null
            ? await _fileService.SaveFileAsync(vm.ImageFile, "uploads/images/about-us", FileType.Image)
            : existing.ImagePath;

        var dto = vm.ToDto(imagePath);

        var updateResult = await _aboutUsService.UpdateAsync(dto);

        if (!updateResult.Success)
        {
            ModelState.AddModelError("", updateResult.ErrorMessage ?? "Hakkımızda bilgisi güncellenemedi.");
            return View(vm);
        }

        TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde güncellendi.";
        return RedirectToAction(nameof(Edit));
    }
}
