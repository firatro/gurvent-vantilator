using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.WebUI.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly ISiteInfoService _siteInfoService;
        private readonly ISocialMediaInfoService _socialMediaInfoService;
        private readonly IMenuService _menuService;

        public HeaderViewComponent(ISiteInfoService siteInfoService, ISocialMediaInfoService socialMediaInfoService, IMenuService menuService)
        {
            _siteInfoService = siteInfoService;
            _socialMediaInfoService = socialMediaInfoService;
            _menuService = menuService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var siteInfo = await _siteInfoService.GetAsync();
            var socialMediaInfo = await _socialMediaInfoService.GetAsync();
            var menus = await _menuService.GetAllAsync();

            var vm = new HeaderViewModel
            {
                SiteInfo = siteInfo.Data ?? new SiteInfoDto(),
                SocialMediaInfo = socialMediaInfo.Data ?? new SocialMediaInfoDto(),
                Menus = menus.Data ?? new List<MenuDto>()
            };

            return View(vm);
        }
    }

}