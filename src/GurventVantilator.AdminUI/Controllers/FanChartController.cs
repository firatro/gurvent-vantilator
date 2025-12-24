using Microsoft.AspNetCore.Mvc;

public class FanChartController : Controller
{
    private readonly IFanChartService _fanChartService;

    public FanChartController(IFanChartService fanChartService)
    {
        _fanChartService = fanChartService;
    }

    // AJAX / API gibi kullanılabilir
    public async Task<IActionResult> GetChart(int productId)
    {
        var chart = await _fanChartService.GetChartByProductIdAsync(productId);
        return Json(chart);
    }
}
