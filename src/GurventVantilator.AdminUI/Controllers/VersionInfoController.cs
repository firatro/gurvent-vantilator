using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.AdminUI.Controllers
{
    public class VersionInfoController : Controller
    {
        private readonly IVersionInfoService _versionInfoService;

        public VersionInfoController(IVersionInfoService versionInfoService)
        {
            _versionInfoService = versionInfoService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _versionInfoService.GetAllAsync();
            if (!result.Success)
            {
                TempData["Error"] = result.ErrorMessage;
                return View(new List<VersionInfoDto>());
            }

            return View(result.Data);
        }

        public IActionResult Create()
        {
            return View(new VersionInfoDto { ReleaseDate = DateTime.Now });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VersionInfoDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var result = await _versionInfoService.AddAsync(dto);
            if (!result.Success)
            {
                TempData["Error"] = result.ErrorMessage;
                return View(dto);
            }

            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde eklendi.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int versionInfoId)
        {
            var result = await _versionInfoService.GetByIdAsync(versionInfoId);
            if (!result.Success || result.Data == null)
            {
                TempData["Error"] = result.ErrorMessage ?? "Sürüm bulunamadı.";
                return RedirectToAction(nameof(Index));
            }

            return View(result.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VersionInfoDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var result = await _versionInfoService.UpdateAsync(dto);
            if (!result.Success)
            {
                TempData["Error"] = result.ErrorMessage;
                return View(dto);
            }

            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int versionInfoId)
        {
            var result = await _versionInfoService.DeleteAsync(versionInfoId);
            if (!result.Success)
            {
                TempData["Error"] = result.ErrorMessage;
                return RedirectToAction(nameof(Index));
            }

            TempData["Success"] = "Sürüm başarıyla silindi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> SetActive(int id)
        {
            var result = await _versionInfoService.SetActiveAsync(id);
            if (!result.Success)
            {
                TempData["Error"] = result.ErrorMessage;
            }
            else
            {
                TempData["Success"] = "Aktif sürüm başarıyla değiştirildi.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
