using GurventVantilator.Application.Interfaces;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.WebUI.Controllers
{
    public class AboutUsController : BaseController
    {
        private readonly IAboutUsService _aboutUsService;
        private readonly IServiceService _serviceService;

        public AboutUsController(IAboutUsService aboutUsService, IServiceService serviceService, IPageImageService pageImageService) : base(pageImageService)
        {
            _aboutUsService = aboutUsService;
            _serviceService = serviceService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _aboutUsService.GetAsync();

            if (!result.Success || result.Data == null)
            {
                TempData["ErrorMessage"] = result.ErrorMessage ?? "Hakkımızda bilgileri şu an getirilemedi.";
                return RedirectToAction("Show", "Error");
            }

            await SetPageImageAsync("AboutUs");

            return View(result.Data);
        }


    }
}
