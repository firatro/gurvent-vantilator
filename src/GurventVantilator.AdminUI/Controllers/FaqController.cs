using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

public class FaqController : Controller
{
    private readonly IFaqService _faqService;

    public FaqController(IFaqService faqService)
    {
        _faqService = faqService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _faqService.GetAllAsync();

        if (!result.Success || result.Data == null)
        {
            ViewBag.ErrorMessage = result.ErrorMessage ?? "SSS listesi yüklenemedi.";
            return View(new List<FaqDto>());
        }

        return View(result.Data);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(FaqDto faq)
    {
        if (!ModelState.IsValid) return View(faq);

        var result = await _faqService.AddAsync(faq);

        if (!result.Success)
        {
            ModelState.AddModelError("", result.ErrorMessage ?? "SSS eklenemedi.");
            return View(faq);
        }

        TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde eklendi.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int faqId)
    {
        var result = await _faqService.GetByIdAsync(faqId);

        if (!result.Success || result.Data == null)
            return NotFound();

        return View(result.Data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(FaqDto faq)
    {
        if (!ModelState.IsValid) return View(faq);

        var result = await _faqService.UpdateAsync(faq);

        if (!result.Success)
        {
            ModelState.AddModelError("", result.ErrorMessage ?? "SSS güncellenemedi.");
            return View(faq);
        }

        TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde güncellendi.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int faqId)
    {
        var result = await _faqService.DeleteAsync(faqId);

        if (!result.Success)
            TempData["Error"] = result.ErrorMessage ?? "SSS silinemedi.";

        TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde silindi.";
        return RedirectToAction(nameof(Index));
    }
}
