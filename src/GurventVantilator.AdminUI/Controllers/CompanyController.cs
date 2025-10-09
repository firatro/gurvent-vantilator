using GurventVantilator.AdminUI.Models.Company;
using GurventVantilator.AdminUI.Mappings;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using GurventVantilator.Application.Enums;

public class CompanyController : Controller
{
    private readonly ICompanyService _companyService;
    private readonly IFileService _fileService;

    public CompanyController(ICompanyService companyService, IFileService fileService)
    {
        _companyService = companyService;
        _fileService = fileService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _companyService.GetAllAsync();

        if (!result.Success || result.Data == null)
        {
            ViewBag.ErrorMessage = result.ErrorMessage ?? "Firma listesi yüklenemedi.";
            return View(new List<CompanyDto>());
        }

        return View(result.Data);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CompanyCreateViewModel vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var logoPath = vm.LogoFile != null
            ? await _fileService.SaveFileAsync(vm.LogoFile, "uploads/images/company", FileType.Image)
            : null;

        var dto = vm.ToDto(logoPath);

        var result = await _companyService.AddAsync(dto);

        if (!result.Success)
        {
            ModelState.AddModelError("", result.ErrorMessage ?? "Firma eklenemedi.");
            return View(vm);
        }

        TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde eklendi.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int companyId)
    {
        var result = await _companyService.GetByIdAsync(companyId);

        if (!result.Success || result.Data == null)
            return NotFound();

        var vm = result.Data.ToEditViewModel();
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(CompanyEditViewModel vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var existingResult = await _companyService.GetByIdAsync(vm.Id);
        if (!existingResult.Success || existingResult.Data == null)
            return NotFound();

        var existing = existingResult.Data;

        var logoPath = vm.LogoFile != null
            ? await _fileService.SaveFileAsync(vm.LogoFile, "uploads/images/company", FileType.Image)
            : existing.LogoPath;

        var dto = vm.ToDto(logoPath);

        var result = await _companyService.UpdateAsync(dto);

        if (!result.Success)
        {
            ModelState.AddModelError("", result.ErrorMessage ?? "Firma güncellenemedi.");
            return View(vm);
        }

        TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde güncellendi.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int companyId)
    {
        var result = await _companyService.GetByIdAsync(companyId);
        if (result.Success && result.Data != null)
        {
            _fileService.DeleteFile(result.Data.LogoPath, "uploads/images/company");

            var deleteResult = await _companyService.DeleteAsync(companyId);
            if (!deleteResult.Success)
                TempData["Error"] = deleteResult.ErrorMessage ?? "Firma silinemedi.";
        }
        else
        {
            TempData["Error"] = result.ErrorMessage ?? "Silinecek firma bulunamadı.";
        }

        TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde silindi.";
        return RedirectToAction(nameof(Index));
    }
}
