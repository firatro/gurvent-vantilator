using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.WebUI.ViewComponents
{
    public class AboutUsViewComponent : ViewComponent
    {
        private readonly IAboutUsService _aboutUsService;

        public AboutUsViewComponent(IAboutUsService aboutUsService)
        {
            _aboutUsService = aboutUsService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var aboutUs = await _aboutUsService.GetAsync();

            if (aboutUs.Success && aboutUs.Data != null)
            {
                return View(aboutUs.Data);
            }

            return View(new AboutUsDto());
        }
    }
}
