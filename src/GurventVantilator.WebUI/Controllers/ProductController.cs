using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.WebUI.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IProductTestDataService _productTestDataService;

        public ProductController(IProductService productService, IProductCategoryService productCategoryService, IPageImageService pageImageService, IProductTestDataService productTestDataService)
            : base(pageImageService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
            _productTestDataService = productTestDataService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _productService.GetAllAsync();
            if (!result.Success || result.Data == null)
                return HandleError(result);

            await SetPageImageAsync("Product");

            return View(result.Data);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var result = await _productService.GetByIdAsync(id);
            if (!result.Success || result.Data == null)
                return HandleError(result);

            await SetPageImageAsync("Product");
            return View(result.Data);
        }


        [Route("product/listbycategory/{id:int}")]
        public async Task<IActionResult> ListByCategory(int id)
        {
            var productCategoryResult = await _productCategoryService.GetByIdAsync(id);
            if (!productCategoryResult.Success || productCategoryResult.Data == null)
                return NotFound();

            // ✅ Var olan metodu kullanıyoruz:
            var productResult = await _productService.GetProductsByCategoryAsync(id, includeSubCategories: true);

            if (!productResult.Success)
            {
                ViewBag.ErrorMessage = productResult.ErrorMessage;
                return View(new ProductListViewModel
                {
                    Category = productCategoryResult.Data,
                    Products = new List<ProductDto>()
                });
            }

            var vm = new ProductListViewModel
            {
                Category = productCategoryResult.Data,
                Products = productResult.Data
            };

            return View(vm);
        }

        public IActionResult ModelViewer(string path)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetFanData(int productId)
        {
            var result = await _productTestDataService.GetCurvePointsByProductIdAsync(productId);

            if (!result.Success || result.Data == null || result.Data.Count == 0)
                return Json(new { success = false, data = new List<object>() });

            var points = result.Data.Select(p => new { x = p.Q, y = p.Pt }).ToList();

            return Json(new { success = true, data = points });
        }

    }
}
