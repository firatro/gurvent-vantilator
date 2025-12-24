using GurventVantilator.AdminUI.Controllers;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Enums;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.AdminUI.Areas.Admin.Controllers
{
    public class ProductSeriesController : BaseController
    {
        private readonly IProductSeriesService _seriesService;
        private readonly ILogger<ProductSeriesController> _logger;

        public ProductSeriesController(
            IProductSeriesService seriesService,
            ILogger<ProductSeriesController> logger,
            IFileService fileService) : base(fileService)
        {
            _seriesService = seriesService;
            _logger = logger;
        }
        // ======================================================
        // 📋 Listeleme
        // ======================================================
        public async Task<IActionResult> Index()
        {
            var result = await _seriesService.GetAllAsync();
            if (!result.Success)
            {
                TempData["Error"] = result.ErrorMessage;
                return View(new List<ProductSeriesDto>());
            }

            return View(result.Data.OrderBy(s => s.Order));
        }

        // ======================================================
        // ➕ Yeni Seri Ekle
        // ======================================================
        [HttpGet]
        public IActionResult Create()
        {
            return View(new ProductSeriesDto());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductSeriesDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            // 📌 Resim yükleme
            dto.ImagePath = await SaveImageAsync(dto.ImageFile, "series", FileType.Image);

            var result = await _seriesService.AddAsync(dto);

            if (result.Success)
            {
                SetSuccessMessage("Yeni seri başarıyla eklendi.");
                return RedirectToAction(nameof(Index));
            }

            SetErrorMessage(result.ErrorMessage);
            return View(dto);
        }


        // ======================================================
        // ✏️ Seri Güncelle
        // ======================================================
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _seriesService.GetByIdAsync(id);
            if (!result.Success || result.Data == null)
            {
                TempData["Error"] = "Seri bulunamadı.";
                return RedirectToAction(nameof(Index));
            }

            return View(result.Data);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductSeriesDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            // Önce eski resmi çekelim (DB’den)
            var existing = await _seriesService.GetByIdAsync(dto.Id);
            if (!existing.Success || existing.Data == null)
            {
                SetErrorMessage("Seri bulunamadı.");
                return RedirectToAction(nameof(Index));
            }

            // 📌 Yeni resim geldiyse eski resmi sil
            if (dto.ImageFile != null)
            {
                DeleteFileIfExists(existing.Data.ImagePath, "series");

                dto.ImagePath = await SaveImageAsync(dto.ImageFile, "series", FileType.Image);
            }
            else
            {
                // Yeni resim yok → eski resim aynen kalsın
                dto.ImagePath = existing.Data.ImagePath;
            }

            var result = await _seriesService.UpdateAsync(dto);

            if (result.Success)
            {
                SetSuccessMessage("Seri başarıyla güncellendi.");
                return RedirectToAction(nameof(Index));
            }

            SetErrorMessage(result.ErrorMessage);
            return View(dto);
        }


        // ======================================================
        // 🗑️ Seri Sil
        // ======================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _seriesService.DeleteAsync(id);
            if (result.Success)
            {
                TempData["Success"] = "Seri başarıyla silindi.";
            }
            else
            {
                TempData["Error"] = result.ErrorMessage;
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ToggleStatus(int id)
        {
            var result = await _seriesService.ToggleStatusAsync(id);

            return Json(new
            {
                success = result.Success,
                message = result.ErrorMessage,
                isActive = result.Data // Yeni aktif/pasif durumu
            });
        }

        [HttpPost]
        public async Task<IActionResult> Clone(int id)
        {
            var result = await _seriesService.CloneAsync(id);

            return Json(new
            {
                success = result.Success,
                message = result.ErrorMessage
            });
        }


    }
}
