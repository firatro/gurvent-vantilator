using GurventVantilator.AdminUI.Mappings;
using GurventVantilator.AdminUI.Models.VisionMission;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.AdminUI.Controllers
{
    public class VisionMissionController : Controller
    {
        private readonly IVisionMissionService _visionMissionService;
        private readonly IFileService _fileService;

        public VisionMissionController(IVisionMissionService visionMissionService, IFileService fileService)
        {
            _visionMissionService = visionMissionService;
            _fileService = fileService;
        }

        public async Task<IActionResult> Edit()
        {
            var result = await _visionMissionService.GetAsync();
            if (!result.Success || result.Data == null)
            {
                ViewBag.ErrorMessage = result.ErrorMessage ?? "Vizyon & Misyon bilgisi getirilemedi.";
                return View(new VisionMissionEditViewModel());
            }

            var vm = result.Data.ToEditViewModel();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VisionMissionEditViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var existingResult = await _visionMissionService.GetAsync();
            if (!existingResult.Success || existingResult.Data == null)
                return NotFound();

            var existing = existingResult.Data;

            var visionImagePath = vm.VisionImageFile != null
                ? await _fileService.SaveFileAsync(vm.VisionImageFile, "uploads/images/vision-mission")
                : existing.VisionImagePath;

            var missionImagePath = vm.MissionImageFile != null
                ? await _fileService.SaveFileAsync(vm.MissionImageFile, "uploads/images/vision-mission")
                : existing.MissionImagePath;

            var dto = vm.ToDto(visionImagePath, missionImagePath);

            var updateResult = await _visionMissionService.UpdateAsync(dto);
            if (!updateResult.Success)
            {
                ModelState.AddModelError("", updateResult.ErrorMessage ?? "Vizyon & Misyon güncellenemedi.");
                return View(vm);
            }

            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde güncellendi.";
            return RedirectToAction(nameof(Edit));
        }
    }
}
