using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using GurventVantilator.Application.DTOs.Pdf;

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
        private readonly IPdfService _pdfService;

        public ProductController(IProductService productService, IPageImageService pageImageService, IProductTestDataService productTestDataService, IProductUsageTypeService usageService,
        IProductWorkingConditionService workingService,
        IProductSeriesService seriesService, IProductModelService modelService, IPdfService pdfService)
            : base(pageImageService)
        {
            _productService = productService;
            _productTestDataService = productTestDataService;
            _usageService = usageService;
            _workingService = workingService;
            _seriesService = seriesService;
            _modelService = modelService;
            _pdfService = pdfService;
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

        public async Task<IActionResult> Performance(int id, double? q, double? pt, string? voltage, string? speedControl)
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
            ViewBag.SpeedControl = speedControl;
            
            return View(product); // ProductDto direkt gidiyor
        }

        [HttpPost]
        public async Task<IActionResult> GeneratePerformancePdf(
    [FromBody] ProductPerformancePdfRequestDto request)
        {
            if (request == null)
                return BadRequest("PDF request boş geldi.");

            var result = await _productService.GetByIdAsync(request.ProductId);
            if (!result.Success || result.Data == null)
                return NotFound();

            var product = result.Data;

            var header = BuildPdfHeader(product, request.Voltage);

            var pdfBytes = _pdfService.GenerateProductPerformancePdf(
                product,
                header,
                request
            );

            return File(
                pdfBytes,
                "application/pdf",
                $"{product.ProductModelCode}-performance.pdf"
            );
        }

        private ProductPdfHeaderDto BuildPdfHeader(ProductDto product, string? selectedVoltage)
        {
            bool isEx = product.WorkingConditionNames != null && product.WorkingConditionNames.Any(x => x.Equals("Patlayıcı Ortamlar", StringComparison.OrdinalIgnoreCase) || x.Equals("Patlayıcı ve Kimyasal Ortamlar", StringComparison.OrdinalIgnoreCase));

            string voltageCode = string.Empty; if (!string.IsNullOrEmpty(selectedVoltage))
            {
                if (selectedVoltage.StartsWith("3Ph")) voltageCode = "(T)";
                else if (selectedVoltage.StartsWith("1Ph")) voltageCode = "(M)";
            }

            bool showVoltageCode = !string.IsNullOrEmpty(voltageCode) && !(isEx && voltageCode == "(T)");

            return new ProductPdfHeaderDto
            {
                ProductModelCode = product.ProductModelCode,
                ProductTestName = product.ProductTestName,
                IsEx = isEx,
                VoltageCode = showVoltageCode ? voltageCode : null
            };
        }

    }
}
