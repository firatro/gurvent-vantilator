using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.WebUI.Controllers;

public class HomeController : Controller
{
    private readonly IServiceService _serviceService;
    private readonly ISliderService _sliderService;
    private readonly ICompanyService _companyService;
    public HomeController(IServiceService serviceService, ISliderService sliderService, ICompanyService companyService)
    {
        _sliderService = sliderService;
        _serviceService = serviceService;
        _companyService = companyService;
    }

    public async Task<IActionResult> Index()
    {
        var sliders = await _sliderService.GetAllAsync();
        var services = await _serviceService.GetAllAsync();
        var companies = await _companyService.GetAllAsync();

        var vm = new HomeViewModel
        {
            Slider = sliders.Data?.First() ?? new SliderDto(),
            Services = services.Data ?? new List<ServiceDto>(),
            Companies = companies.Data ?? new List<CompanyDto>(),
        };

        return View(vm);
    }
}
