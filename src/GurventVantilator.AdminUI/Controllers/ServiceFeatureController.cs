using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.AdminUI.Controllers
{
    public class ServiceFeatureController : Controller
    {
        private readonly IServiceFeatureService _serviceFeatureService;

        public ServiceFeatureController(IServiceFeatureService serviceFeatureService)
        {
            _serviceFeatureService = serviceFeatureService;
        }

        public async Task<IActionResult> Index(int serviceId)
        {
            var result = await _serviceFeatureService.GetAllByIdAsync(serviceId);
            ViewBag.ServiceId = serviceId;

            if (!result.Success || result.Data == null)
            {
                ViewBag.ErrorMessage = result.ErrorMessage ?? "Özellik listesi yüklenemedi.";
                return View(new List<ServiceFeatureDto>());
            }

            return View(result.Data);
        }

        public IActionResult Create(int serviceId)
        {
            ViewBag.ServiceId = serviceId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceFeatureDto serviceFeature, int serviceId)
        {
            if (!ModelState.IsValid) return View(serviceFeature);

            var result = await _serviceFeatureService.AddAsync(serviceFeature, serviceId);

            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Özellik eklenemedi.");
                return View(serviceFeature);
            }

            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde eklendi.";
            return RedirectToAction("Index", new { serviceId });
        }

        public async Task<IActionResult> Edit(int serviceFeatureId, int serviceId)
        {
            var result = await _serviceFeatureService.GetByIdAsync(serviceFeatureId);

            if (!result.Success || result.Data == null)
                return NotFound();

            ViewBag.ServiceId = serviceId;
            return View(result.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ServiceFeatureDto serviceFeature, int serviceId)
        {
            if (!ModelState.IsValid) return View(serviceFeature);

            var result = await _serviceFeatureService.UpdateAsync(serviceFeature);

            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Özellik güncellenemedi.");
                return View(serviceFeature);
            }

            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde güncellendi.";
            return RedirectToAction("Index", new { serviceId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int serviceFeatureId, int serviceId)
        {
            var result = await _serviceFeatureService.DeleteAsync(serviceFeatureId);

            if (!result.Success)
                TempData["Error"] = result.ErrorMessage ?? "Özellik silinemedi.";

            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde silindi.";
            return RedirectToAction("Index", new { serviceId });
        }
    }

}
