using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.WebUI.Controllers
{
    public class FanSelectorController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IProductTestDataService _productTestDataService;
        private readonly IProductUsageTypeService _usageService;
        private readonly IProductWorkingConditionService _workingService;
        private readonly IProductSeriesService _seriesService;
        private readonly IProductModelService _modelService;
        private readonly IFanSearchService _fanSearchService;

        public FanSelectorController(
            IPageImageService pageImageService,
            IProductService productService,
            IProductTestDataService productTestDataService,
            IProductUsageTypeService usageService,
            IProductWorkingConditionService workingService,
            IProductSeriesService seriesService,
            IProductModelService modelService,
            IFanSearchService fanSearchService
        ) : base(pageImageService)
        {
            _productService = productService;
            _productTestDataService = productTestDataService;
            _usageService = usageService;
            _workingService = workingService;
            _seriesService = seriesService;
            _modelService = modelService;
            _fanSearchService = fanSearchService;
        }


        public async Task<IActionResult> Index(
     int? usageId,
     int? workingId,
     int? seriesId,
     int? modelId,
     string mode = "category")
        {
            // Kullanım ve çalışma listeleri
            var usageResult = await _usageService.GetAllAsync();
            var workingResult = await _workingService.GetAllAsync();

            // ========== SERİ LİSTESİ GETİR ==========
            Result<List<ProductSeriesDto>> seriesResult;

            if (usageId.HasValue || workingId.HasValue)
            {
                var filtered = await _seriesService.GetByFilterAsync(usageId, workingId);

                seriesResult = Result<List<ProductSeriesDto>>.Ok(
                    filtered.Data ?? new List<ProductSeriesDto>() // 👈 NULL koruma
                );
            }
            else
            {
                var all = await _seriesService.GetAllAsync();

                seriesResult = Result<List<ProductSeriesDto>>.Ok(
                    all.Data.ToList() ?? new List<ProductSeriesDto>() // 👈 NULL koruma
                );
            }

            // ========== VIEW MODEL ==========
            var vm = new ProductPageViewModel
            {
                UsageTypes = usageResult.Data?.ToList() ?? new(),
                WorkingConditions = workingResult.Data?.ToList() ?? new(),
                Series = seriesResult.Data ?? new(),

                SelectedUsageId = usageId,
                SelectedWorkingId = workingId,
                SelectedSeriesId = seriesId,
                SelectedModelId = modelId,

                ViewMode = mode
            };

            // ========== SERİ ADI ==========
            if (seriesId.HasValue)
            {
                var series = await _seriesService.GetByIdAsync(seriesId.Value);
                vm.SelectedSeriesName = series.Data?.Name;
            }

            // ========== SERİ SEÇİLDİ → MODELLERİ GETİR ==========
            if (seriesId.HasValue)
            {
                var result = await _modelService.GetBySeriesIdAsync(seriesId.Value);

                var models = (result.Data ?? new List<ProductModelDto>()).AsQueryable(); // 👈 NULL koruma

                // Filtreleri uygula
                if (usageId.HasValue)
                    models = models.Where(m => m.UsageTypeIds.Contains(usageId.Value));

                if (workingId.HasValue)
                    models = models.Where(m => m.WorkingConditionIds.Contains(workingId.Value));

                vm.Models = models.ToList();
            }

            // ========== MODEL SEÇİLDİ → ÜRÜNLERİ GETİR ==========
            if (modelId.HasValue)
            {
                var productList = await _productService.GetByModelIdAsync(modelId.Value);
                vm.Products = productList.Data ?? new(); // 👈 NULL koruma
            }

            return View(vm);
        }




        // === PARAMETRE FİLTRESİ (DEĞİŞTİRİLMEDİ) ===
        [HttpPost, IgnoreAntiforgeryToken]
        public async Task<IActionResult> FilterProducts([FromBody] ProductFilterRequest request)
        {
            var result = await _productService.FilterAsync(request);
            if (!result.Success)
                return BadRequest(result.ErrorMessage);

            return PartialView("_ProductList", result.Data);
        }

        // ============================================
        // AJAX → Seriye Göre Modeller
        // ============================================
        [HttpGet]
        public async Task<IActionResult> GetModelsBySeries(int seriesId, int? usageId, int? workingId)
        {
            var result = await _modelService.GetBySeriesIdAsync(seriesId);
            var models = result.Data.AsQueryable();

            if (usageId.HasValue)
                models = models.Where(m => m.UsageTypeIds.Contains(usageId.Value));

            if (workingId.HasValue)
                models = models.Where(m => m.WorkingConditionIds.Contains(workingId.Value));

            var series = await _seriesService.GetByIdAsync(seriesId);

            var vm = new ModelListViewModel
            {
                Models = models.ToList(),
                SelectedSeriesId = seriesId,
                SelectedSeriesName = series.Data?.Name,
                SelectedUsageId = usageId,
                SelectedWorkingId = workingId
            };

            return PartialView("_ModelList", vm);
        }


        // ============================================
        // AJAX → Kategoriye Göre Seriler
        // ============================================
        [HttpGet]
        public async Task<IActionResult> GetSeriesByCategory(int? usageId, int? workingId)
        {
            var result = await _seriesService.GetByFilterAsync(usageId, workingId);

            var vm = new SeriesListViewModel
            {
                Series = result.Data,
                SelectedUsageId = usageId,
                SelectedWorkingId = workingId
            };

            return PartialView("_SeriesList", vm);
        }

        [HttpPost]
        public async Task<IActionResult> SearchFans(
    double AirFlow,
    double? TotalPressure,
    int Tolerans,
    string SpeedControl,
    int? UsageId,
    int? WorkingId
)
        {
            SpeedControlType speedControl = SpeedControl switch
            {
                "DirectCoupled" => SpeedControlType.DirectCoupled,
                "FrequencyDriver" => SpeedControlType.FrequencyDriver,
                _ => SpeedControlType.All
            };

            var result = await _fanSearchService.SearchByAirFlowAsync(
                AirFlow,
                TotalPressure,
                Tolerans,
                speedControl,
                UsageId,
                WorkingId
            );

            return Json(result);
        }



    }
}
