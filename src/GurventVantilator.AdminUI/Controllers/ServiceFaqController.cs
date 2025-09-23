using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.AdminUI.Controllers
{
    public class ServiceFaqController : Controller
    {
        private readonly IServiceFaqService _serviceFaqService;

        public ServiceFaqController(IServiceFaqService serviceFaqService)
        {
            _serviceFaqService = serviceFaqService;
        }

        public async Task<IActionResult> Index(int serviceId)
        {
            var result = await _serviceFaqService.GetAllByIdAsync(serviceId);
            ViewBag.ServiceId = serviceId;

            if (!result.Success || result.Data == null)
            {
                ViewBag.ErrorMessage = result.ErrorMessage ?? "SSS listesi yüklenemedi.";
                return View(new List<ServiceFaqDto>());
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
        public async Task<IActionResult> Create(ServiceFaqDto serviceFaq, int serviceId)
        {
            if (!ModelState.IsValid) return View(serviceFaq);

            var result = await _serviceFaqService.AddAsync(serviceFaq, serviceId);

            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "SSS eklenemedi.");
                return View(serviceFaq);
            }

            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde eklendi.";
            return RedirectToAction("Index", new { serviceId });
        }

        public async Task<IActionResult> Edit(int serviceFaqId, int serviceId)
        {
            var result = await _serviceFaqService.GetByIdAsync(serviceFaqId);

            if (!result.Success || result.Data == null)
                return NotFound();

            ViewBag.ServiceId = serviceId;
            return View(result.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ServiceFaqDto serviceFaq, int serviceId)
        {
            if (!ModelState.IsValid) return View(serviceFaq);

            var result = await _serviceFaqService.UpdateAsync(serviceFaq);

            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "SSS güncellenemedi.");
                return View(serviceFaq);
            }

            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde güncellendi";
            return RedirectToAction("Index", new { serviceId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int serviceFaqId, int serviceId)
        {
            var result = await _serviceFaqService.DeleteAsync(serviceFaqId);

            if (!result.Success)
                TempData["Error"] = result.ErrorMessage ?? "SSS silinemedi.";

            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde silindi.";
            return RedirectToAction("Index", new { serviceId });
        }
    }

}
