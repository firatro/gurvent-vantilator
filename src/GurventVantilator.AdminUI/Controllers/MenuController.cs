using System.ComponentModel.DataAnnotations;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Enums;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class MenuController : Controller
{
    private readonly IMenuService _menuService;
    private readonly IServiceService _serviceService;
    private readonly IProjectService _projectService;
    private readonly IProductService _productService;
    private readonly IProductCategoryService _productCategoryService;


    public MenuController(IMenuService menuService, IServiceService serviceService, IProjectService projectService, IProductService productService, IProductCategoryService productCategoryService)
    {
        _menuService = menuService;
        _serviceService = serviceService;
        _projectService = projectService;
        _productService = productService;
        _productCategoryService = productCategoryService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _menuService.GetAllAsync();

        if (!result.Success || result.Data == null)
        {
            ViewBag.ErrorMessage = result.ErrorMessage ?? "Menü listesi yüklenemedi.";
            return View(new List<MenuDto>());
        }

        return View(result.Data);
    }

    public async Task<IActionResult> Create()
    {
        await LoadParentMenusAsync();
        LoadLinkTypes();
        await LoadRelatedDataAsync();
        return View(new MenuDto());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(MenuDto menu)
    {
        if (!ModelState.IsValid)
        {
            await LoadParentMenusAsync(menu.ParentId);
            LoadLinkTypes(menu.LinkType);
            await LoadRelatedDataAsync(menu.ServiceId, menu.ProjectId, menu.ProductId,  menu.ProductCategoryId);
            return View(menu);
        }

        var result = await _menuService.AddAsync(menu);

        if (!result.Success)
        {
            ModelState.AddModelError("", result.ErrorMessage ?? "Menü eklenemedi.");
            await LoadParentMenusAsync(menu.ParentId);
            LoadLinkTypes(menu.LinkType);
            await LoadRelatedDataAsync(menu.ServiceId, menu.ProjectId, menu.ProductId, menu.ProductCategoryId);
            return View(menu);
        }

        TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde eklendi.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int menuId)
    {
        var menuResult = await _menuService.GetByIdAsync(menuId);
        if (!menuResult.Success || menuResult.Data == null)
            return NotFound();

        await LoadParentMenusAsync(menuResult.Data.ParentId, menuResult.Data.Id); // kendisini parent olmasın
        LoadLinkTypes(menuResult.Data.LinkType);
        await LoadRelatedDataAsync(menuResult.Data.ServiceId, menuResult.Data.ProjectId, menuResult.Data.ProductId, menuResult.Data.ProductCategoryId);

        return View(menuResult.Data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(MenuDto menu)
    {
        if (!ModelState.IsValid)
        {
            await LoadParentMenusAsync(menu.ParentId, menu.Id);
            LoadLinkTypes(menu.LinkType);
            await LoadRelatedDataAsync(menu.ServiceId, menu.ProjectId, menu.ProductId,  menu.ProductCategoryId);
            return View(menu);
        }

        var result = await _menuService.UpdateAsync(menu);

        if (!result.Success)
        {
            ModelState.AddModelError("", result.ErrorMessage ?? "Menü güncellenemedi.");
            await LoadParentMenusAsync(menu.ParentId, menu.Id);
            LoadLinkTypes(menu.LinkType);
            await LoadRelatedDataAsync(menu.ServiceId, menu.ProjectId, menu.ProductId,  menu.ProductCategoryId);
            return View(menu);
        }

        TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde güncellendi.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int menuId)
    {
        var result = await _menuService.DeleteAsync(menuId);

        if (!result.Success)
            TempData["Error"] = result.ErrorMessage ?? "Menü silinemedi.";
        else
            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde silindi.";

        return RedirectToAction(nameof(Index));
    }

    #region Helpers

    private async Task LoadParentMenusAsync(int? selectedId = null, int? excludeId = null)
    {
        var result = await _menuService.GetAllAsync();
        if (result.Success && result.Data != null)
        {
            var parentMenus = result.Data.Where(m => excludeId == null || m.Id != excludeId).ToList();
            ViewBag.Menus = new SelectList(parentMenus, "Id", "Title", selectedId);
        }
        else
        {
            ViewBag.Menus = new SelectList(new List<MenuDto>(), "Id", "Title");
            ViewBag.ErrorMessage = result.ErrorMessage;
        }
    }

    private void LoadLinkTypes(MenuLinkTypeDto? selectedType = null)
    {
        var types = Enum.GetValues(typeof(MenuLinkTypeDto))
                        .Cast<MenuLinkTypeDto>()
                        .Select(t => new
                        {
                            Id = (int)t,
                            Name = t.GetType()
                                    .GetMember(t.ToString())
                                    .First()
                                    .GetCustomAttributes(false)
                                    .OfType<DisplayAttribute>()
                                    .FirstOrDefault()?.Name ?? t.ToString()
                        })
                        .ToList();

        ViewBag.LinkTypes = new SelectList(types, "Id", "Name", selectedType);
    }

    private async Task LoadRelatedDataAsync(int? selectedServiceId = null, int? selectedProjectId = null, int? selectedProductId = null, int? selectedProductCategoryId = null)
    {
        var services = await _serviceService.GetAllAsync();
        if (services.Success && services.Data != null)
            ViewBag.Services = new SelectList(services.Data, "Id", "Name", selectedServiceId);
        else
            ViewBag.Services = new SelectList(new List<object>(), "Id", "Name");

        var projects = await _projectService.GetAllAsync();
        if (projects.Success && projects.Data != null)
            ViewBag.Projects = new SelectList(projects.Data, "Id", "Title", selectedProjectId);
        else
            ViewBag.Projects = new SelectList(new List<object>(), "Id", "Title");

        var products = await _productService.GetAllAsync();
        if (products.Success && products.Data != null)
            ViewBag.Products = new SelectList(products.Data, "Id", "Name", selectedProductId);
        else
            ViewBag.Products = new SelectList(new List<object>(), "Id", "Name");

        var productCategories = await _productCategoryService.GetAllAsync();
        if (productCategories.Success && productCategories.Data != null)
            ViewBag.ProductCategories = new SelectList(productCategories.Data, "Id", "Name", selectedProductCategoryId);
        else
            ViewBag.ProductCategories = new SelectList(new List<object>(), "Id", "Name");

    }

    #endregion
}
