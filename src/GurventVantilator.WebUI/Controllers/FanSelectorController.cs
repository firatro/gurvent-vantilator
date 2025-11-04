using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.WebUI.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.WebUI.Controllers
{
    public class FanSelectorController : BaseController
    {
        private readonly IProductApplicationService _productApplicationService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IProductService _productService;
        private readonly IProductTestDataService _productTestDataService;

        public FanSelectorController(
            IPageImageService pageImageService,
            IProductApplicationService productApplicationService,
            IProductCategoryService productCategoryService,
            IProductService productService, IProductTestDataService productTestDataService
        ) : base(pageImageService)
        {
            _productApplicationService = productApplicationService;
            _productCategoryService = productCategoryService;
            _productService = productService;
            _productTestDataService = productTestDataService;
        }

        public async Task<IActionResult> Index()
        {
            var applications = await _productApplicationService.GetAllAsync();
            var categories = await _productCategoryService.GetAllAsync();
            var products = await _productService.GetAllAsync();

            ViewBag.Applications = applications.Data?.ToList() ?? new();
            ViewBag.Categories = categories.Data?.ToList() ?? new();
            ViewBag.Products = products.Data?.ToList() ?? new();

            return View();
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> FilterProducts([FromBody] ProductFilterRequest request)
        {
            var result = await _productService.FilterAsync(request);
            if (!result.Success)
                return BadRequest(result.ErrorMessage);

            return PartialView("_ProductList", result.Data); // ✅ doğru isim
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> FilterProductsWithCurves([FromBody] ProductFilterRequest request)
        {
            // 🔹 Güvenli tolerans sınır kontrolü
            if (request.TolerancePercent is < 0 or > 100)
                request.TolerancePercent = 0;

            var filtered = await _productService.FilterAsync(request);
            if (!filtered.Success)
                return BadRequest(filtered.ErrorMessage);

            var productIds = filtered.Data.Select(p => p.Id).ToList();

            if (!productIds.Any())
            {
                return Json(new
                {
                    html = "<div class='alert alert-warning'>Kriterlere uygun fan bulunamadı.</div>",
                    curves = new List<object>()
                });
            }

            // 🔴 ÖNEMLİ: Artık sadece Q1-Pt1 taşıyan servisi çağırıyoruz
            var curves = await _productTestDataService.GetCurvesByProductIds_Q1Pt1_OnlyAsync(productIds);

            return Json(new
            {
                html = await this.RenderViewAsync("_ProductList", filtered.Data, true),
                curves,
                tolerance = request.TolerancePercent ?? 10
            });
        }


        public IActionResult Detail()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetTestCurves(int productId)
        {
            var result = await _productTestDataService.GetCurvesByProductIdsAsync(new List<int> { productId });
            return Json(result);
        }


    }
}
