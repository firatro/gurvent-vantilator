using GurventVantilator.AdminUI.Models.PageImage;
using GurventVantilator.AdminUI.Mappings;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

public class PageImageController : Controller
{
    private readonly IPageImageService _pageImageService;
    private readonly IFileService _fileService;

    public PageImageController(IPageImageService service, IFileService fileService)
    {
        _pageImageService = service;
        _fileService = fileService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _pageImageService.GetAllAsync();

        if (!result.Success || result.Data == null)
        {
            ViewBag.ErrorMessage = result.ErrorMessage ?? "Sayfa görselleri yüklenemedi.";
            return View(new List<PageImageDto>());
        }

        return View(result.Data);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(PageImageCreateViewModel vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var imagePath = vm.ImageFile != null
            ? await _fileService.SaveFileAsync(vm.ImageFile, "uploads/images/page-image")
            : null;

        var dto = vm.ToDto(imagePath);

        var result = await _pageImageService.AddAsync(dto);

        if (!result.Success)
        {
            ModelState.AddModelError("", result.ErrorMessage ?? "Sayfa görseli eklenemedi.");
            return View(vm);
        }

        TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde eklendi.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int pageImageId)
    {
        var result = await _pageImageService.GetByIdAsync(pageImageId);

        if (!result.Success || result.Data == null)
            return NotFound();

        var vm = result.Data.ToEditViewModel();
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(PageImageEditViewModel vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var existingResult = await _pageImageService.GetByIdAsync(vm.Id);
        if (!existingResult.Success || existingResult.Data == null)
            return NotFound();

        var existing = existingResult.Data;

        var imagePath = vm.ImageFile != null
            ? await _fileService.SaveFileAsync(vm.ImageFile, "uploads/images/page-image")
            : existing.ImagePath;

        var dto = vm.ToDto(imagePath);

        var result = await _pageImageService.UpdateAsync(dto);

        if (!result.Success)
        {
            ModelState.AddModelError("", result.ErrorMessage ?? "Sayfa görseli güncellenemedi.");
            return View(vm);
        }

        TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde güncellendi.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int pageImageId)
    {
        var result = await _pageImageService.GetByIdAsync(pageImageId);

        if (result.Success && result.Data != null)
        {
            _fileService.DeleteFile(result.Data.ImagePath, "uploads/images/page-image");

            var deleteResult = await _pageImageService.DeleteAsync(pageImageId);
            if (!deleteResult.Success)
                TempData["Error"] = deleteResult.ErrorMessage ?? "Sayfa görseli silinemedi.";
        }
        else
        {
            TempData["Error"] = result.ErrorMessage ?? "Silinecek sayfa görseli bulunamadı.";
        }

        TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde silindi.";
        return RedirectToAction(nameof(Index));
    }
}
