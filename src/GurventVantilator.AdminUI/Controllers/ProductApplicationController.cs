using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.AdminUI.Controllers
{
    public class ProductApplicationController : Controller
    {
        private readonly IProductApplicationService _productApplicationService;
        private readonly ILogger<ProductApplicationController> _logger;

        public ProductApplicationController(IProductApplicationService productApplicationService, ILogger<ProductApplicationController> logger)
        {
            _productApplicationService = productApplicationService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _productApplicationService.GetAllAsync();
            if (!result.Success)
            {
                TempData["Error"] = result.ErrorMessage;
                return View(new List<ProductApplicationDto>());
            }

            return View(result.Data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductApplicationDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _productApplicationService.AddAsync(dto);
            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Uygulama alanı eklenemedi.");
                return View(dto);
            }

            TempData["SuccessMessage"] = "Uygulama alanı başarıyla eklendi.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int productApplicationId)
        {
            var result = await _productApplicationService.GetByIdAsync(productApplicationId);
            if (!result.Success || result.Data == null)
                return NotFound();

            return View(result.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductApplicationDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _productApplicationService.UpdateAsync(dto);
            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Uygulama alanı güncellenemedi.");
                return View(dto);
            }

            TempData["SuccessMessage"] = "Uygulama alanı başarıyla güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int productApplicationId)
        {
            var result = await _productApplicationService.DeleteAsync(productApplicationId);
            if (!result.Success)
            {
                TempData["Error"] = result.ErrorMessage ?? "Silme işlemi başarısız.";
            }
            else
            {
                TempData["SuccessMessage"] = "Uygulama alanı başarıyla silindi.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
