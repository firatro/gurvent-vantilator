using GurventVantilator.AdminUI.Mappings;
using GurventVantilator.AdminUI.Models.TeamMember;
using GurventVantilator.Application.Enums;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.AdminUI.Controllers
{
    public class TeamMemberController : Controller
    {
        private readonly ITeamMemberService _teamMemberService;
        private readonly IFileService _fileService;

        public TeamMemberController(ITeamMemberService teamMemberService, IFileService fileService)
        {
            _teamMemberService = teamMemberService;
            _fileService = fileService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _teamMemberService.GetAllAsync();
            if (!result.Success || result.Data == null)
            {
                ViewBag.ErrorMessage = result.ErrorMessage ?? "Takım üyeleri listelenemedi.";
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
        public async Task<IActionResult> Create(TeamMemberCreateViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var imagePath = vm.ImageFile != null
                ? await _fileService.SaveFileAsync(vm.ImageFile, "uploads/images/team-member", FileType.Image)
                : null;

            var dto = vm.ToDto(imagePath);

            var result = await _teamMemberService.AddAsync(dto);

            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Takım üyesi eklenemedi.");
                return View(vm);
            }

            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde eklendi.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int teamMemberId)
        {
            var result = await _teamMemberService.GetByIdAsync(teamMemberId);

            if (!result.Success || result.Data == null)
                return NotFound();

            var vm = result.Data.ToEditViewModel();

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TeamMemberEditViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var existingResult = await _teamMemberService.GetByIdAsync(vm.Id);
            if (!existingResult.Success || existingResult.Data == null)
                return NotFound();

            var existing = existingResult.Data;

            var imagePath = vm.ImageFile != null
                ? await _fileService.SaveFileAsync(vm.ImageFile, "uploads/images/team-member", FileType.Image)
                : existing.ImagePath;

            var dto = vm.ToDto(imagePath);

            var result = await _teamMemberService.UpdateAsync(dto);

            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Takım üyesi güncellenemedi.");
                return View(vm);
            }

            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int teamMemberId)
        {
            var result = await _teamMemberService.GetByIdAsync(teamMemberId);
            if (result.Success && result.Data != null)
            {
                _fileService.DeleteFile(result.Data.ImagePath, "uploads/images/team-member");

                var deleteResult = await _teamMemberService.DeleteAsync(teamMemberId);
                if (!deleteResult.Success)
                {
                    TempData["Error"] = deleteResult.ErrorMessage ?? "Takım üyesi silinemedi.";
                }
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
