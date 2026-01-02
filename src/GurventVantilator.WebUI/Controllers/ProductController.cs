using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.WebUI.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IProductTestDataService _productTestDataService;
        private readonly IProductUsageTypeService _usageService;
        private readonly IProductWorkingConditionService _workingService;
        private readonly IProductSeriesService _seriesService;
        private readonly IProductModelService _modelService;

        public ProductController(IProductService productService, IPageImageService pageImageService, IProductTestDataService productTestDataService, IProductUsageTypeService usageService,
        IProductWorkingConditionService workingService,
        IProductSeriesService seriesService, IProductModelService modelService)
            : base(pageImageService)
        {
            _productService = productService;
            _productTestDataService = productTestDataService;
            _usageService = usageService;
            _workingService = workingService;
            _seriesService = seriesService;
            _modelService = modelService;
        }

        public async Task<IActionResult> Index()
        {
            var seriesResult = await _seriesService.GetAllAsync();
            if (!seriesResult.Success || seriesResult.Data == null)
                return HandleError(seriesResult);

            await SetPageImageAsync("Product");

            return View(seriesResult.Data);  // ✔ SERİLER GİDİYOR !
        }

        public async Task<IActionResult> Series(int id)
        {
            var seriesResult = await _seriesService.GetByIdAsync(id);
            if (!seriesResult.Success || seriesResult.Data == null)
                return HandleError(seriesResult);

            var modelsResult = await _modelService.GetBySeriesIdAsync(id);
            if (!modelsResult.Success)
                return HandleError(modelsResult);

            var vm = new SeriesDetailViewModel
            {
                Series = seriesResult.Data,
                Models = modelsResult.Data
            };

            await SetPageImageAsync("Product");

            return View(vm);
        }


        public async Task<IActionResult> Detail(int id)
        {
            var result = await _productService.GetByIdAsync(id);
            if (!result.Success || result.Data == null)
                return HandleError(result);

            await SetPageImageAsync("Product");
            return View(result.Data);
        }
        public IActionResult ModelViewer(string path)
        {
            return View();
        }

        public async Task<IActionResult> Performance(int id, double? q, double? pt, string? voltage)
        {
            var result = await _productService.GetByIdAsync(id);
            if (!result.Success || result.Data == null)
                return NotFound();

            var product = result.Data;
            ViewBag.ProductId = id;

            // 🔥 ÇALIŞMA NOKTASI PARAMETRELERİ
            ViewBag.InitialQ = q;
            ViewBag.InitialPt = pt;
            ViewBag.SelectedVoltage = voltage;

            return View(product); // ProductDto direkt gidiyor
        }

    }
}
