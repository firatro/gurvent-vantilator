using GurventVantilator.AdminUI.Models.ProductAccessory;
using GurventVantilator.AdminUI.Mappings;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Enums;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.AdminUI.Controllers
{
    public class ProductAccessoryController : Controller
    {
        private readonly IProductAccessoryService _accessoryService;
        private readonly IFileService _fileService;

        public ProductAccessoryController(
            IProductAccessoryService accessoryService,
            IFileService fileService)
        {
            _accessoryService = accessoryService;
            _fileService = fileService;
        }

        // ===========================================================
        // 🔹 LIST (ÜRÜNE GÖRE)
        // ===========================================================
        public async Task<IActionResult> Index(int productId)
        {
            var result = await _accessoryService.GetByProductIdAsync(productId);

            if (!result.Success || result.Data == null)
            {
                ViewBag.ErrorMessage = result.ErrorMessage ?? "Aksesuarlar yüklenemedi.";
                ViewBag.ProductId = productId;
                return View(new List<ProductAccessoryDto>());
            }

            ViewBag.ProductId = productId;
            return View(result.Data);
        }

        // ===========================================================
        // 🔹 CREATE GET
        // ===========================================================
        public IActionResult Create(int productId)
        {
            return View(new ProductAccessoryCreateViewModel
            {
                ProductId = productId
            });
        }

        // ===========================================================
        // 🔹 CREATE POST
        // ===========================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductAccessoryCreateViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var imagePath = vm.ImageFile != null
                ? await _fileService.SaveFileAsync(
                    vm.ImageFile,
                    "uploads/images/product-accessory",
                    FileType.Image)
                : null;

            var dto = vm.ToDto(imagePath);

            var result = await _accessoryService.AddAsync(dto);

            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Aksesuar eklenemedi.");
                return View(vm);
            }

            TempData["SuccessMessage"] = "Aksesuar başarıyla eklendi.";
            return RedirectToAction(nameof(Index), new { productId = vm.ProductId });
        }

        // ===========================================================
        // 🔹 EDIT GET
        // ===========================================================
        public async Task<IActionResult> Edit(int productAccessoryId)
        {
            var result = await _accessoryService.GetByIdAsync(productAccessoryId);

            if (!result.Success || result.Data == null)
                return NotFound();

            var vm = result.Data.ToEditViewModel();
            return View(vm);
        }

        // ===========================================================
        // 🔹 EDIT POST
        // ===========================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductAccessoryEditViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var existingResult = await _accessoryService.GetByIdAsync(vm.Id);
            if (!existingResult.Success || existingResult.Data == null)
                return NotFound();

            var existing = existingResult.Data;

            var imagePath = vm.ImageFile != null
                ? await _fileService.SaveFileAsync(
                    vm.ImageFile,
                    "uploads/images/product-accessory",
                    FileType.Image)
                : existing.ImagePath;

            var dto = vm.ToDto(imagePath);

            var result = await _accessoryService.UpdateAsync(dto);

            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Aksesuar güncellenemedi.");
                return View(vm);
            }

            TempData["SuccessMessage"] = "Aksesuar başarıyla güncellendi.";
            return RedirectToAction(nameof(Index), new { productId = vm.ProductId });
        }

        // ===========================================================
        // 🔹 DELETE
        // ===========================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int productAccessoryId, int productId)
        {
            var result = await _accessoryService.GetByIdAsync(productAccessoryId);

            if (result.Success && result.Data != null)
            {
                _fileService.DeleteFile(
                    result.Data.ImagePath,
                    "uploads/images/product-accessory");

                var deleteResult = await _accessoryService.DeleteAsync(productAccessoryId);

                if (!deleteResult.Success)
                    TempData["Error"] = deleteResult.ErrorMessage ?? "Aksesuar silinemedi.";
            }
            else
            {
                TempData["Error"] = result.ErrorMessage ?? "Silinecek aksesuar bulunamadı.";
            }

            TempData["SuccessMessage"] = "Aksesuar başarıyla silindi.";
            return RedirectToAction(nameof(Index), new { productId });
        }
    }
}
