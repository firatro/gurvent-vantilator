using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Application.DTOs;
using GurventVantilator.AdminUI.Models.ProductContentFeature;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GurventVantilator.AdminUI.Controllers
{
    public class ProductContentFeatureController : Controller
    {
        private readonly IProductContentFeatureService _service;
        private readonly IProductService _productService;

        public ProductContentFeatureController(IProductContentFeatureService service, IProductService productService)
        {
            _service = service;
            _productService = productService;
        }

        #region INDEX
        public async Task<IActionResult> Index(int? productId)
        {
            // 🔹 Özellikleri al
            var result = await _service.GetAllAsync();
            if (!result.Success || result.Data == null)
                return View(new List<ProductContentFeatureViewModel>());

            // 🔹 Ürün listesini al
            var productResult = await _productService.GetAllAsync();
            var productList = productResult.Success && productResult.Data != null
                ? productResult.Data
                : new List<ProductDto>();

            // 🔹 Ürünleri dictionary'e çevir (id -> name)
            var productDict = productList.ToDictionary(p => p.Id, p => p.Name);

            // 🔹 ViewModel listesi oluştur
            var list = result.Data.Select(x => new ProductContentFeatureViewModel
            {
                Id = x.Id,
                ProductId = x.ProductId,
                ProductName = productDict.ContainsKey(x.ProductId) ? productDict[x.ProductId] : "—",
                Key = x.Key,
                Value = x.Value,
                Order = x.Order
            }).ToList();

            // 🔹 Filtre uygulanmışsa
            if (productId.HasValue && productId.Value > 0)
                list = list.Where(x => x.ProductId == productId.Value).ToList();

            // 🔹 Dropdown için ürün listesi
            ViewBag.Products = new SelectList(productList, "Id", "Name", productId);

            return View(list);
        }

        #endregion

        #region CREATE
        public async Task<IActionResult> Create()
        {
            var products = await _productService.GetAllAsync();
            ViewBag.Products = new SelectList(products.Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductContentFeatureViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var dto = new ProductContentFeatureDto
            {
                ProductId = vm.ProductId,
                Key = vm.Key,
                Value = vm.Value,
                Order = vm.Order
            };

            var result = await _service.AddAsync(dto);
            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Kayıt eklenemedi.");
                return View(vm);
            }

            TempData["SuccessMessage"] = "İçerik özelliği başarıyla eklendi.";
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region EDIT
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (!result.Success || result.Data == null)
                return NotFound();

            var vm = new ProductContentFeatureViewModel
            {
                Id = result.Data.Id,
                ProductId = result.Data.ProductId,
                Key = result.Data.Key,
                Value = result.Data.Value,
                Order = result.Data.Order
            };

            var products = await _productService.GetAllAsync();
            ViewBag.Products = new SelectList(products.Data, "Id", "Name", vm.ProductId);

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductContentFeatureViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var dto = new ProductContentFeatureDto
            {
                Id = vm.Id,
                ProductId = vm.ProductId,
                Key = vm.Key,
                Value = vm.Value,
                Order = vm.Order
            };

            var result = await _service.UpdateAsync(dto);
            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Kayıt güncellenemedi.");
                return View(vm);
            }

            TempData["SuccessMessage"] = "İçerik özelliği başarıyla güncellendi.";
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result.Success)
                TempData["ErrorMessage"] = result.ErrorMessage ?? "Kayıt silinemedi.";
            else
                TempData["SuccessMessage"] = "Kayıt başarıyla silindi.";

            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
