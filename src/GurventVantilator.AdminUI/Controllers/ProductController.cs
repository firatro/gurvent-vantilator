using GurventVantilator.AdminUI.Models;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.AdminUI.Mappings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using GurventVantilator.AdminUI.Models.Product;
using GurventVantilator.Application.Enums;

namespace GurventVantilator.AdminUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IFileService _fileService;

        public ProductController(IProductService productService, IProductCategoryService productCategoryService, IFileService fileService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
            _fileService = fileService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _productService.GetAllAsync();
            if (!result.Success)
            {
                TempData["Error"] = result.ErrorMessage;
                return View(new List<ProductDto>()); // Boş liste dön
            }

            return View(result.Data);
        }

        public async Task<IActionResult> Create()
        {
            await FillDropdowns();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                await FillDropdowns();
                return View(vm);
            }

            var imagePath = vm.ImageFile != null
                ? await _fileService.SaveFileAsync(vm.ImageFile, "uploads/images/product", FileType.Image)
                : null;

            var dataSheetPath = vm.DataSheetFile != null
                ? await _fileService.SaveFileAsync(vm.DataSheetFile, "uploads/datasheets/product", FileType.Pdf)
                : null;

            var model3DPath = vm.Model3DFile != null
                ? await _fileService.SaveFileAsync(vm.Model3DFile, "uploads/model3D/product", FileType.Model3D)
                : null;

            var dto = vm.ToDto(imagePath, dataSheetPath, model3DPath);

            var result = await _productService.AddAsync(dto);
            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Ürün eklenemedi.");
                await FillDropdowns();
                return View(vm);
            }

            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde eklendi.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int productId)
        {
            var result = await _productService.GetByIdAsync(productId);
            if (!result.Success || result.Data == null)
                return NotFound();

            var vm = result.Data.ToEditViewModel();
            await FillDropdowns();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductEditViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                await FillDropdowns();
                return View(vm);
            }

            var existingResult = await _productService.GetByIdAsync(vm.Id);
            if (!existingResult.Success || existingResult.Data == null)
                return NotFound();

            var existing = existingResult.Data;

            var imagePath = vm.ImageFile != null
                ? await _fileService.SaveFileAsync(vm.ImageFile, "uploads/images/product", FileType.Image)
                : existing.ImagePath;

            var dataSheetPath = vm.DataSheetFile != null
                ? await _fileService.SaveFileAsync(vm.DataSheetFile, "uploads/datasheets/product", FileType.Pdf)
                : existing.DataSheetPath;

            var model3DPath = vm.Model3DFile != null
                ? await _fileService.SaveFileAsync(vm.Model3DFile, "uploads/model3D/product", FileType.Model3D)
                : existing.Model3DPath;

            var dto = vm.ToDto(imagePath, dataSheetPath, model3DPath, existing.CreatedAt);

            var result = await _productService.UpdateAsync(dto);
            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Ürün güncellenemedi.");
                await FillDropdowns();
                return View(vm);
            }

            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int productId)
        {
            var result = await _productService.DeleteAsync(productId);
            if (!result.Success)
            {
                TempData["Error"] = result.ErrorMessage;
                return RedirectToAction(nameof(Index));
            }

            // Silinen productun görsellerini de temizle
            if (result.Success)
            {
                var product = await _productService.GetByIdAsync(productId);
                if (product.Success && product.Data != null)
                {
                    _fileService.DeleteFile(product.Data.ImagePath, "uploads/images/product");
                    _fileService.DeleteFile(product.Data.DataSheetPath, "uploads/datasheets/product");
                    _fileService.DeleteFile(product.Data.Model3DPath, "uploads/model3D/product");
                }
            }

            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde silindi.";
            return RedirectToAction(nameof(Index));
        }

        private async Task FillDropdowns()
        {
            var productCategoryList = await _productCategoryService.GetAllAsync();
            if (productCategoryList.Success && productCategoryList.Data != null)
            {
                ViewBag.ProductCategoryList = new SelectList(productCategoryList.Data, "Id", "Name");
            }
            else
            {
                ViewBag.ProductCategoryList = new SelectList(Enumerable.Empty<SelectListItem>());
                ViewBag.ProductCategoryError = productCategoryList.ErrorMessage ?? "Kategori listesi yüklenemedi.";
            }
        }
    }
}
