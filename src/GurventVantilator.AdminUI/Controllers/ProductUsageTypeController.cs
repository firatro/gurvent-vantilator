using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.AdminUI.Areas.Admin.Controllers
{
    public class ProductUsageTypeController : Controller
    {
        private readonly IProductUsageTypeService _usageTypeService;
        private readonly ILogger<ProductUsageTypeController> _logger;

        public ProductUsageTypeController(
            IProductUsageTypeService usageTypeService,
            ILogger<ProductUsageTypeController> logger)
        {
            _usageTypeService = usageTypeService;
            _logger = logger;
        }

        // ======================================================
        // 📋 Listeleme
        // ======================================================
        public async Task<IActionResult> Index()
        {
            var result = await _usageTypeService.GetAllAsync();
            if (!result.Success)
            {
                TempData["Error"] = result.ErrorMessage;
                return View(new List<ProductUsageTypeDto>());
            }

            return View(result.Data.OrderBy(u => u.Order));
        }

        // ======================================================
        // ➕ Yeni Ekle
        // ======================================================
        [HttpGet]
        public IActionResult Create()
        {
            return View(new ProductUsageTypeDto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductUsageTypeDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _usageTypeService.AddAsync(dto);
            if (result.Success)
            {
                TempData["Success"] = "Kullanım tipi başarıyla eklendi.";
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
            var result = await _usageTypeService.GetByIdAsync(id);
            if (!result.Success || result.Data == null)
            {
                TempData["Error"] = "Kullanım tipi bulunamadı.";
                return RedirectToAction(nameof(Index));
            }

            return View(result.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductUsageTypeDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _usageTypeService.UpdateAsync(dto);
            if (result.Success)
            {
                TempData["Success"] = "Kullanım tipi başarıyla güncellendi.";
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
            var result = await _usageTypeService.DeleteAsync(id);
            if (result.Success)
            {
                TempData["Success"] = "Kullanım tipi başarıyla silindi.";
            }
            else
            {
                TempData["Error"] = result.ErrorMessage;
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
