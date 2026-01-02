using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.AdminUI.Areas.Admin.Controllers
{
    public class ProductWorkingConditionController : Controller
    {
        private readonly IProductWorkingConditionService _workingConditionService;
        private readonly ILogger<ProductWorkingConditionController> _logger;

        public ProductWorkingConditionController(
            IProductWorkingConditionService workingConditionService,
            ILogger<ProductWorkingConditionController> logger)
        {
            _workingConditionService = workingConditionService;
            _logger = logger;
        }

        // ======================================================
        // 📋 Listeleme
        // ======================================================
        public async Task<IActionResult> Index()
        {
            var result = await _workingConditionService.GetAllAsync();
            if (!result.Success)
            {
                TempData["Error"] = result.ErrorMessage;
                return View(new List<ProductWorkingConditionDto>());
            }

            return View(result.Data);
        }

        // ======================================================
        // ➕ Yeni Ekle
        // ======================================================
        [HttpGet]
        public IActionResult Create()
        {
            return View(new ProductWorkingConditionDto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductWorkingConditionDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _workingConditionService.AddAsync(dto);
            if (result.Success)
            {
                TempData["Success"] = "Çalışma koşulu başarıyla eklendi.";
                return RedirectToAction(nameof(Index));
            }

            TempData["Error"] = result.ErrorMessage;
            return View(dto);
        }

        // ======================================================
        // ✏️ Güncelle
        // ======================================================
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _workingConditionService.GetByIdAsync(id);
            if (!result.Success || result.Data == null)
            {
                TempData["Error"] = "Çalışma koşulu bulunamadı.";
                return RedirectToAction(nameof(Index));
            }

            return View(result.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductWorkingConditionDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _workingConditionService.UpdateAsync(dto);
            if (result.Success)
            {
                TempData["Success"] = "Çalışma koşulu başarıyla güncellendi.";
                return RedirectToAction(nameof(Index));
            }

            TempData["Error"] = result.ErrorMessage;
            return View(dto);
        }

        // ======================================================
        // 🗑️ Sil
        // ======================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _workingConditionService.DeleteAsync(id);
            if (result.Success)
            {
                TempData["Success"] = "Çalışma koşulu başarıyla silindi.";
            }
            else
            {
                TempData["Error"] = result.ErrorMessage;
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
