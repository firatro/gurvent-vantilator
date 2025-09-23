using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _categoryService.GetAllAsync();

        if (!result.Success || result.Data == null)
        {
            ViewBag.ErrorMessage = result.ErrorMessage ?? "Kategoriler listelenemedi.";
            return View(new List<CategoryDto>());
        }

        return View(result.Data);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CategoryDto category)
    {
        if (!ModelState.IsValid) return View(category);

        var result = await _categoryService.AddAsync(category);

        if (!result.Success)
        {
            ModelState.AddModelError("", result.ErrorMessage ?? "Kategori eklenemedi.");
            return View(category);
        }

        TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde eklendi.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int categoryId)
    {
        var result = await _categoryService.GetByIdAsync(categoryId);

        if (!result.Success || result.Data == null)
            return NotFound();

        return View(result.Data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(CategoryDto category)
    {
        if (!ModelState.IsValid) return View(category);

        var result = await _categoryService.UpdateAsync(category);

        if (!result.Success)
        {
            ModelState.AddModelError("", result.ErrorMessage ?? "Kategori güncellenemedi.");
            return View(category);
        }

        TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde güncellendi.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int categoryId)
    {
        var result = await _categoryService.DeleteAsync(categoryId);

        if (!result.Success)
            TempData["Error"] = result.ErrorMessage ?? "Kategori silinemedi.";

       TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde silindi.";
        return RedirectToAction(nameof(Index));
    }
}
