using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.WebUI.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly ISiteInfoService _siteInfoService;
        private readonly ISocialMediaInfoService _socialMediaInfoService;
        private readonly IMenuService _menuService;
        private readonly IServiceService _serviceService;

        public FooterViewComponent(ISiteInfoService siteInfoService, ISocialMediaInfoService socialMediaInfoService, IMenuService menuService, IServiceService serviceService)
        {
            _siteInfoService = siteInfoService;
            _socialMediaInfoService = socialMediaInfoService;
            _menuService = menuService;
            _serviceService = serviceService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var siteInfo = await _siteInfoService.GetAsync();
            var socialMediaInfo = await _socialMediaInfoService.GetAsync();
            var menus = await _menuService.GetAllAsync();
            var services = await _serviceService.GetAllAsync();

            var vm = new FooterViewModel
            {
                SiteInfo = siteInfo.Data ?? new SiteInfoDto(),
                SocialMediaInfo = socialMediaInfo.Data ?? new SocialMediaInfoDto(),
                Menus = menus.Data ?? new List<MenuDto>(),
                Services = services.Data ?? new List<ServiceDto>()
            };

            return View(vm);
        }
    }

}