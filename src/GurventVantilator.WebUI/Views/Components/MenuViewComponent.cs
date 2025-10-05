using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.WebUI.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IMenuService _menuService;

        public MenuViewComponent(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _menuService.GetAllAsync();
            if (!result.Success || result.Data == null)
                return View(new List<MenuDto>());

            // sadece aktif menüler
            var menus = result.Data.Where(m => m.IsActive && m.ParentId == null)
                                   .OrderBy(m => m.Order)
                                   .ToList();

            return View(menus);
        }
    }
}
