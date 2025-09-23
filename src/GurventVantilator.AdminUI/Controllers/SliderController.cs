using GurventVantilator.AdminUI.Mappings;
using GurventVantilator.AdminUI.Models.Slider;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.AdminUI.Controllers
{
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IFileService _fileService;

        public SliderController(ISliderService sliderService, IFileService fileService)
        {
            _sliderService = sliderService;
            _fileService = fileService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _sliderService.GetAllAsync();

            if (!result.Success || result.Data == null)
            {
                ViewBag.ErrorMessage = result.ErrorMessage ?? "Slider listesi yüklenemedi.";
                return View(new List<SliderDto>());
            }

            return View(result.Data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SliderCreateViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var imagePath = vm.ImageFile != null
                ? await _fileService.SaveFileAsync(vm.ImageFile, "uploads/images/slider")
                : null;

            var dto = vm.ToDto(imagePath);

            var result = await _sliderService.AddAsync(dto);

            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Slider eklenemedi.");
                return View(vm);
            }

            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde eklendi.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int sliderId)
        {
            var result = await _sliderService.GetByIdAsync(sliderId);

            if (!result.Success || result.Data == null)
                return NotFound();

            var vm = result.Data.ToEditViewModel();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SliderEditViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var existingResult = await _sliderService.GetByIdAsync(vm.Id);
            if (!existingResult.Success || existingResult.Data == null)
                return NotFound();

            var existing = existingResult.Data;

            var imagePath = vm.ImageFile != null
                ? await _fileService.SaveFileAsync(vm.ImageFile, "uploads/images/slider")
                : existing.ImagePath;

            var dto = vm.ToDto(imagePath);

            var result = await _sliderService.UpdateAsync(dto);

            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Slider güncellenemedi.");
                return View(vm);
            }

            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int sliderId)
        {
            var existingResult = await _sliderService.GetByIdAsync(sliderId);
            if (existingResult.Success && existingResult.Data != null)
            {
                _fileService.DeleteFile(existingResult.Data.ImagePath, "uploads/images/slider");

                var deleteResult = await _sliderService.DeleteAsync(sliderId);
                if (!deleteResult.Success)
                    TempData["Error"] = deleteResult.ErrorMessage ?? "Slider silinemedi.";
            }
            else
            {
                TempData["Error"] = existingResult.ErrorMessage ?? "Silinecek slider bulunamadı.";
            }

            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde silindi.";
            return RedirectToAction(nameof(Index));
        }
    }

}
