using GurventVantilator.AdminUI.Mappings;
using GurventVantilator.AdminUI.Models.Service;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Enums;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.AdminUI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly IFileService _fileService;

        public ServiceController(IServiceService serviceService, IFileService fileService)
        {
            _serviceService = serviceService;
            _fileService = fileService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _serviceService.GetAllAsync();
            if (!result.Success || result.Data == null)
            {
                ViewBag.ErrorMessage = result.ErrorMessage ?? "Hizmetler listelenemedi.";
                return View(result);
            }

            return View(result.Data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceCreateViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var mainImagePath = vm.MainImageFile != null
                ? await _fileService.SaveFileAsync(vm.MainImageFile, "uploads/images/service", FileType.Image)
                : null;

            var contentImage1Path = vm.ContentImage1File != null
                ? await _fileService.SaveFileAsync(vm.ContentImage1File, "uploads/images/service", FileType.Image)
                : null;

            var contentImage2Path = vm.ContentImage2File != null
                ? await _fileService.SaveFileAsync(vm.ContentImage2File, "uploads/images/service", FileType.Image)
                : null;

            var logoPath = vm.LogoFile != null
                ? await _fileService.SaveFileAsync(vm.LogoFile, "uploads/images/service", FileType.Image)
                : null;

            var dto = vm.ToDto(mainImagePath, contentImage1Path, contentImage2Path, logoPath);

            var result = await _serviceService.AddAsync(dto);

            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Servis eklenemedi.");
                return View(vm);
            }

            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde eklendi.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int serviceId)
        {
            var result = await _serviceService.GetByIdAsync(serviceId);

            if (!result.Success || result.Data == null)
                return NotFound();

            var vm = result.Data.ToEditViewModel();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ServiceEditViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var existingResult = await _serviceService.GetByIdAsync(vm.Id);
            if (!existingResult.Success || existingResult.Data == null)
                return NotFound();

            var existing = existingResult.Data;

            var mainImagePath = vm.MainImageFile != null
                ? await _fileService.SaveFileAsync(vm.MainImageFile, "uploads/images/service", FileType.Image)
                : existing.MainImagePath;

            var contentImage1Path = vm.ContentImage1File != null
                ? await _fileService.SaveFileAsync(vm.ContentImage1File, "uploads/images/service", FileType.Image)
                : existing.ContentImage1Path;

            var contentImage2Path = vm.ContentImage2File != null
                ? await _fileService.SaveFileAsync(vm.ContentImage2File, "uploads/images/service", FileType.Image)
                : existing.ContentImage2Path;

            var logoPath = vm.LogoFile != null
                ? await _fileService.SaveFileAsync(vm.LogoFile, "uploads/images/service", FileType.Image)
                : existing.LogoPath;

            var dto = vm.ToDto(mainImagePath, contentImage1Path, contentImage2Path, logoPath);

            var result = await _serviceService.UpdateAsync(dto);

            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Servis güncellenemedi.");
                return View(vm);
            }

            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int serviceId)
        {
            var result = await _serviceService.GetByIdAsync(serviceId);
            if (result.Success && result.Data != null)
            {
                _fileService.DeleteFile(result.Data.MainImagePath, "uploads/images/service");
                _fileService.DeleteFile(result.Data.ContentImage1Path, "uploads/images/service");
                _fileService.DeleteFile(result.Data.ContentImage2Path, "uploads/images/service");
                _fileService.DeleteFile(result.Data.LogoPath, "uploads/images/service");

                var deleteResult = await _serviceService.DeleteAsync(serviceId);
                if (!deleteResult.Success)
                    TempData["Error"] = deleteResult.ErrorMessage ?? "Servis silinemedi.";
            }
            else
            {
                TempData["Error"] = result.ErrorMessage ?? "Silinecek kayıt bulunamadı.";
            }

            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde silindi.";
            return RedirectToAction(nameof(Index));
        }
    }
}
