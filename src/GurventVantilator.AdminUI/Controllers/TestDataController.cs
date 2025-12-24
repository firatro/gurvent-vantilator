using GurventVantilator.AdminUI.Models.TestData;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles = "Admin,DevAdmin")]
public class TestDataController : Controller
{
    private readonly IProductTestDataService _testDataService;
    private readonly IFanChartService _fanChartService;
    private readonly IWorkingPointService _workingPointService;
    private readonly IProductService _productService;
    public TestDataController(IFanChartService fanChartService,
        IWorkingPointService workingPointService,
        IProductTestDataService testDataService, IProductService productService)
    {
        _fanChartService = fanChartService;
        _workingPointService = workingPointService;
        _testDataService = testDataService;
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        var testDataDtos = await _testDataService.GetListAsync();

        var productResult = await _productService.GetAllAsync();
        var products = productResult.Success
            ? productResult.Data!.ToList()
            : new List<ProductDto>();

        var model = new TestDataIndexViewModel
        {
            TestDatas = testDataDtos.Select(x => new TestDataListItemViewModel
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                TestName = x.TestName,
                Diameter = x.Diameter,
                TestDate = x.TestDate,
                IsActive = x.IsActive
            }).ToList(),

            Products = products
        };

        return View(model);
    }


    // ➕ Yeni Test Datası
    public IActionResult Create(int productId)
    {
        if (productId <= 0)
            return RedirectToAction("Index");

        return View(new TestDataUploadViewModel
        {
            ProductId = productId
        });
    }


    [HttpPost]
    public async Task<IActionResult> Create(TestDataUploadViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await _testDataService.CreateFromExcelAsync(
            model.ExcelFile!,
            model.ProductId,
            model.TestName,
            model.Diameter,
            model.TestDate
        );

        if (!result.Success)
        {
            ModelState.AddModelError("", result.ErrorMessage);
            return View(model);
        }

        return RedirectToAction("Detail", new { productId = model.ProductId });
    }

    // 📊 Detay
    public IActionResult Detail(int productId)
    {
        ViewBag.ProductId = productId;
        return View();
    }

    // ⚙️ Working Point
    [HttpPost]
    public async Task<IActionResult> CalculateWorkingPoint(WorkingPointViewModel model)
    {
        var result = await _workingPointService.CalculateAsync(
            model.ProductId,
            new GurventVantilator.Application.DTOs.WorkingPoint.WorkingPointRequestDto
            {
                Q = model.Q,
                Pt = model.Pt
            });

        if (result != null)
        {
            model.CalculatedRPM = result.CalculatedRPM;
            model.CalculatedPower = result.CalculatedPower;
        }

        return View("Detail", model);
    }
}
