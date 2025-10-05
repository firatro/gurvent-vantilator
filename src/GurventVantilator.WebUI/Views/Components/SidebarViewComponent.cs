using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.WebUI.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly ISiteInfoService _siteInfoService;

        public SidebarViewComponent(ISiteInfoService siteInfoService)
        {
            _siteInfoService = siteInfoService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var siteInfo = await _siteInfoService.GetAsync();

            return View(siteInfo.Data);
        }
    }

}