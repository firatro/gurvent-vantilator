using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

public class FanChartController : BaseController
{
    private readonly IProductService _productService;
    private readonly IProductTestDataService _productTestDataService;
    private readonly IProductUsageTypeService _usageService;
    private readonly IProductWorkingConditionService _workingService;
    private readonly IProductSeriesService _seriesService;
    private readonly IProductModelService _modelService;
    private readonly IFanChartService _fanChartService;

    public FanChartController(
        IPageImageService pageImageService,
        IProductService productService,
        IProductTestDataService productTestDataService,
        IProductUsageTypeService usageService,
        IProductWorkingConditionService workingService,
        IProductSeriesService seriesService,
        IProductModelService modelService,
        IFanChartService fanChartService
    ) : base(pageImageService)
    {
        _productService = productService;
        _productTestDataService = productTestDataService;
        _usageService = usageService;
        _workingService = workingService;
        _seriesService = seriesService;
        _modelService = modelService;
        _fanChartService = fanChartService;
    }


    // AJAX / API gibi kullanılabilir
    public async Task<IActionResult> GetChart(int productId, string? speedControl, string? voltage)
    {
        var chart = await _fanChartService.GetChartByProductIdAsync(
            productId,
            speedControl,
            voltage
        );

        ViewBag.ProductId = productId;
        return Json(chart);
    }
}
