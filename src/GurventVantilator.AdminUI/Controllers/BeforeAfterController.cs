using GurventVantilator.AdminUI.Models.BeforeAfter;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.AdminUI.Mappings;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.AdminUI.Controllers
{
    public class BeforeAfterController : Controller
    {
        private readonly IBeforeAfterService _beforeAfterService;
        private readonly IFileService _fileService;

        public BeforeAfterController(IBeforeAfterService beforeAfterService, IFileService fileService)
        {
            _beforeAfterService = beforeAfterService;
            _fileService = fileService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _beforeAfterService.GetAllAsync();
            if (!result.Success || result.Data == null)
            {
                ViewBag.ErrorMessage = result.ErrorMessage ?? "Öncesi/Sonrası listelenemedi.";
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
        public async Task<IActionResult> Create(BeforeAfterCreateViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var beforeImagePath = vm.BeforeImageFile != null
                ? await _fileService.SaveFileAsync(vm.BeforeImageFile, "uploads/images/before-after")
                : null;

            var afterImagePath = vm.AfterImageFile != null
                ? await _fileService.SaveFileAsync(vm.AfterImageFile, "uploads/images/before-after")
                : null;

            var dto = vm.ToDto(beforeImagePath, afterImagePath);

            var result = await _beforeAfterService.AddAsync(dto);

            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Öncesi/Sonrası kaydı eklenemedi.");
                return View(vm);
            }

            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde eklendi.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int beforeAfterId)
        {
            var result = await _beforeAfterService.GetByIdAsync(beforeAfterId);

            if (!result.Success || result.Data == null)
                return NotFound();

            var vm = result.Data.ToEditViewModel();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BeforeAfterEditViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var existingResult = await _beforeAfterService.GetByIdAsync(vm.Id);
            if (!existingResult.Success || existingResult.Data == null)
                return NotFound();

            var existing = existingResult.Data;

            var afterImagePath = vm.AfterImageFile != null
                ? await _fileService.SaveFileAsync(vm.AfterImageFile, "uploads/images/before-after")
                : existing.AfterImagePath;

            var beforeImagePath = vm.BeforeImageFile != null
                ? await _fileService.SaveFileAsync(vm.BeforeImageFile, "uploads/images/before-after")
                : existing.BeforeImagePath;

            var dto = vm.ToDto(beforeImagePath, afterImagePath);

            var result = await _beforeAfterService.UpdateAsync(dto);

            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Öncesi/Sonrası kaydı güncellenemedi.");
                return View(vm);
            }

            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int beforeAfterId)
        {
            var result = await _beforeAfterService.GetByIdAsync(beforeAfterId);
            if (result.Success && result.Data != null)
            {
                _fileService.DeleteFile(result.Data.BeforeImagePath, "uploads/images/before-after");
                _fileService.DeleteFile(result.Data.AfterImagePath, "uploads/images/before-after");

                var deleteResult = await _beforeAfterService.DeleteAsync(beforeAfterId);
                if (!deleteResult.Success)
                    TempData["Error"] = deleteResult.ErrorMessage ?? "Öncesi/Sonrası kaydı silinemedi.";
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
