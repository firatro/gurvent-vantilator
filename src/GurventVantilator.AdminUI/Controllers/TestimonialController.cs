using GurventVantilator.AdminUI.Mappings;
using GurventVantilator.AdminUI.Models.Testimonial;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.AdminUI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IFileService _fileService;

        public TestimonialController(ITestimonialService testimonialService, IFileService fileService)
        {
            _testimonialService = testimonialService;
            _fileService = fileService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _testimonialService.GetAllAsync();
            if (!result.Success || result.Data == null)
            {
                ViewBag.ErrorMessage = result.ErrorMessage ?? "Referanslar listelenemedi.";
                return View(new List<TestimonialDto>());
            }

            return View(result.Data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TestimonialCreateViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var imagePath = vm.ImageFile != null
                ? await _fileService.SaveFileAsync(vm.ImageFile, "uploads/images/testimonial")
                : null;

            var dto = vm.ToDto(imagePath);
            var result = await _testimonialService.AddAsync(dto);

            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Referans eklenemedi.");
                return View(vm);
            }
            
            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde eklendi.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int testimonialId)
        {
            var result = await _testimonialService.GetByIdAsync(testimonialId);
            if (!result.Success || result.Data == null)
                return NotFound();

            var vm = result.Data.ToEditViewModel();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TestimonialEditViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var existingResult = await _testimonialService.GetByIdAsync(vm.Id);
            if (!existingResult.Success || existingResult.Data == null)
                return NotFound();

            var existing = existingResult.Data;

            var imagePath = vm.ImageFile != null
                ? await _fileService.SaveFileAsync(vm.ImageFile, "uploads/images/testimonial")
                : existing.ImagePath;

            var dto = vm.ToDto(imagePath);
            var result = await _testimonialService.UpdateAsync(dto);

            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Referans güncellenemedi.");
                return View(vm);
            }

            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int testimonialId)
        {
            var result = await _testimonialService.GetByIdAsync(testimonialId);
            if (result.Success && result.Data != null)
            {
                _fileService.DeleteFile(result.Data.ImagePath, "uploads/images/testimonial");

                var deleteResult = await _testimonialService.DeleteAsync(testimonialId);
                if (!deleteResult.Success)
                    TempData["Error"] = deleteResult.ErrorMessage ?? "Referans silinemedi.";
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
