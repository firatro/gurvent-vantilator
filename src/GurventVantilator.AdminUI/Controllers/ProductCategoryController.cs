using GurventVantilator.AdminUI.Mappings;
using GurventVantilator.AdminUI.Models.ProductCategory;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

public class ProductCategoryController : Controller
{
    private readonly IProductCategoryService _productCategoryService;
    private readonly IFileService _fileService;

    public ProductCategoryController(IProductCategoryService productCategoryService, IFileService fileService)
    {
        _productCategoryService = productCategoryService;
        _fileService = fileService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _productCategoryService.GetAllAsync();

        if (!result.Success || result.Data == null)
        {
            ViewBag.ErrorMessage = result.ErrorMessage ?? "Kategoriler listelenemedi.";
            return View(new List<ProductCategoryDto>());
        }

        return View(result.Data);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductCategoryCreateViewModel vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var imagePath = vm.ImageFile != null
               ? await _fileService.SaveFileAsync(vm.ImageFile, "uploads/images/product-category")
               : null;

        var dto = vm.ToDto(imagePath);

        var result = await _productCategoryService.AddAsync(dto);
        if (!result.Success)
        {
            ModelState.AddModelError("", result.ErrorMessage ?? "Kategori eklenemedi.");
            return View(vm);
        }

        TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde eklendi.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int productCategoryId)
    {
        var result = await _productCategoryService.GetByIdAsync(productCategoryId);
        if (!result.Success || result.Data == null)
            return NotFound();

        var vm = result.Data.ToEditViewModel();
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ProductCategoryEditViewModel vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var existingResult = await _productCategoryService.GetByIdAsync(vm.Id);
        if (!existingResult.Success || existingResult.Data == null)
            return NotFound();

        var existing = existingResult.Data;

        var imagePath = vm.ImageFile != null
            ? await _fileService.SaveFileAsync(vm.ImageFile, "uploads/images/product-category")
            : existing.ImagePath;

        var dto = vm.ToDto(imagePath);

        var result = await _productCategoryService.UpdateAsync(dto);
        if (!result.Success)
        {
            ModelState.AddModelError("", result.ErrorMessage ?? "Kategori güncellenemedi.");
            return View(vm);
        }

        TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde güncellendi.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int productCategoryId)
    {
        var result = await _productCategoryService.DeleteAsync(productCategoryId);
        if (!result.Success)
        {
            TempData["Error"] = result.ErrorMessage;
            return RedirectToAction(nameof(Index));
        }

        // Silinen productun görsellerini de temizle
        if (result.Success)
        {
            var productCategory = await _productCategoryService.GetByIdAsync(productCategoryId);
            if (productCategory.Success && productCategory.Data != null)
            {
                _fileService.DeleteFile(productCategory.Data.ImagePath, "uploads/images/product-category");
            }
        }

        TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde silindi.";
        return RedirectToAction(nameof(Index));
    }
}
