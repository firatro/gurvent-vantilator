using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GurventVantilator.AdminUI.Controllers
{
    public class ProductContentFeatureController : Controller
    {
        private readonly IProductContentFeatureService _featureService;
        private readonly IProductModelService _modelService;
        private readonly IProductService _productService;

        public ProductContentFeatureController(
            IProductContentFeatureService featureService,
            IProductModelService modelService, IProductService productService)
        {
            _featureService = featureService;
            _modelService = modelService;
            _productService = productService;
        }

        // ================================================================
        // INDEX
        // ================================================================
        public async Task<IActionResult> Index(int? modelId)
        {
            var featureResult = await _featureService.GetAllAsync();
            var modelResult = await _modelService.GetAllAsync();
            var productResult = await _productService.GetAllAsync();

            var modelList = modelResult.Success ? modelResult.Data : new List<ProductModelDto>();
            var modelDict = modelList.ToDictionary(x => x.Id, x => x.Name);

            var productList = productResult.Success ? productResult.Data : new List<ProductDto>();
            var productDict = productList.ToDictionary(x => x.Id, x => x.Name);

            var list = featureResult.Data
                .Where(f => f.ProductModelId.HasValue)
                .Select(f => new ProductContentFeatureViewModel
                {
                    Id = f.Id,
                    ProductModelId = f.ProductModelId ?? 0,
                    ProductName = productDict.ContainsKey(f.ProductId ?? 0)
                        ? productDict[f.ProductId ?? 0]
                        : "—",
                    ProductModelName = modelDict.ContainsKey(f.ProductModelId ?? 0)
                        ? modelDict[f.ProductModelId ?? 0]
                        : "—",
                    Key = f.Key,
                    Value = f.Value,
                    Order = f.Order
                }).ToList();

            if (modelId.HasValue)
                list = list.Where(x => x.ProductModelId == modelId.Value).ToList();

            ViewBag.Models = new SelectList(modelList, "Id", "Name", modelId);

            return View(list);
        }

        // ================================================================
        // CREATE
        // ================================================================
        public async Task<IActionResult> Create()
        {
            var models = await _modelService.GetAllAsync();
            ViewBag.Models = new SelectList(models.Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductContentFeatureViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var dto = new ProductContentFeatureDto
            {
                ProductModelId = vm.ProductModelId,
                Key = vm.Key,
                Value = vm.Value,
                Order = vm.Order
            };

            var result = await _featureService.AddAsync(dto);
            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Ekleme başarısız.");
                return View(vm);
            }

            TempData["SuccessMessage"] = "Özellik eklendi.";
            return RedirectToAction(nameof(Index), new { modelId = vm.ProductModelId });
        }

        // ================================================================
        // EDIT
        // ================================================================
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _featureService.GetByIdAsync(id);

            var vm = new ProductContentFeatureViewModel
            {
                Id = result.Data.Id,
                ProductModelId = result.Data.ProductModelId ?? 0,
                Key = result.Data.Key,
                Value = result.Data.Value,
                Order = result.Data.Order
            };

            var models = await _modelService.GetAllAsync();
            ViewBag.Models = new SelectList(models.Data, "Id", "Name", vm.ProductModelId);

            return View(vm);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(ProductContentFeatureViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var dto = new ProductContentFeatureDto
            {
                Id = vm.Id,
                ProductModelId = vm.ProductModelId,
                Key = vm.Key,
                Value = vm.Value,
                Order = vm.Order
            };

            var result = await _featureService.UpdateAsync(dto);
            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Güncelleme başarısız.");
                return View(vm);
            }

            TempData["SuccessMessage"] = "Özellik güncellendi.";
            return RedirectToAction(nameof(Index), new { modelId = vm.ProductModelId });
        }

        // ================================================================
        // DELETE
        // ================================================================
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _featureService.DeleteAsync(id);
            TempData[result.Success ? "SuccessMessage" : "ErrorMessage"]
                = result.Success ? "Silindi" : result.ErrorMessage;

            return RedirectToAction(nameof(Index));
        }
    }
}
