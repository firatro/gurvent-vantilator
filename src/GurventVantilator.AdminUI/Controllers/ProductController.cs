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
        private readonly IProductApplicationService _productApplicationService;
        private readonly IFileService _fileService;
        private readonly IProductTestDataImportService _productTestDataImportService;

        public ProductController(
            IProductService productService,
            IProductCategoryService productCategoryService,
            IProductApplicationService productApplicationService,
            IFileService fileService, IProductTestDataImportService productTestDataImportService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
            _productApplicationService = productApplicationService;
            _fileService = fileService;
            _productTestDataImportService = productTestDataImportService;
        }

        #region INDEX
        public async Task<IActionResult> Index(string? search, int? categoryId, bool? isActive)
        {
            var result = await _productService.GetAllAsync();
            if (!result.Success || result.Data == null)
            {
                TempData["Error"] = result.ErrorMessage ?? "Ürün listesi alınamadı.";
                return View(new List<ProductDto>());
            }

            var list = result.Data.AsEnumerable();

            // 🔹 Arama (isim veya kod)
            if (!string.IsNullOrWhiteSpace(search))
                list = list.Where(p =>
                    (p.Name?.Contains(search, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (p.Code?.Contains(search, StringComparison.OrdinalIgnoreCase) ?? false));

            // 🔹 Kategori filtresi
            if (categoryId.HasValue && categoryId.Value > 0)
                list = list.Where(p => p.ProductCategoryId == categoryId.Value);

            // 🔹 Durum filtresi
            if (isActive.HasValue)
                list = list.Where(p => p.IsActive == isActive.Value);

            // 🔹 Dropdown verileri
            var categories = await _productCategoryService.GetAllAsync();
            ViewBag.ProductCategories = categories.Success && categories.Data != null
                ? new SelectList(categories.Data, "Id", "Name")
                : new SelectList(Enumerable.Empty<SelectListItem>());

            return View(list.ToList());
        }
        #endregion

        #region CREATE
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

            // 🔹 Dosyaları kaydet
            var image1Path = await SaveFileIfExists(vm.Image1File, "uploads/images/product", FileType.Image);
            var image2Path = await SaveFileIfExists(vm.Image2File, "uploads/images/product", FileType.Image);
            var image3Path = await SaveFileIfExists(vm.Image3File, "uploads/images/product", FileType.Image);
            var image4Path = await SaveFileIfExists(vm.Image4File, "uploads/images/product", FileType.Image);
            var image5Path = await SaveFileIfExists(vm.Image5File, "uploads/images/product", FileType.Image);

            var dataSheetPath = await SaveFileIfExists(vm.DataSheetFile, "uploads/datasheets/product", FileType.Pdf);
            var model3DPath = await SaveFileIfExists(vm.Model3DFile, "uploads/model3D/product", FileType.Model3D);
            var testDataPath = await SaveFileIfExists(vm.TestDataFile, "uploads/test-data/product", FileType.TestData);
            var scaleImagePath = await SaveFileIfExists(vm.ScaleImageFile, "uploads/images/product", FileType.Image);

            // 🔹 DTO dönüşümü (testDataPath burada da kaydedilebilir)
            var dto = vm.ToDto(image1Path, image2Path, image3Path, image4Path, image5Path, dataSheetPath, model3DPath, testDataPath, scaleImagePath);

            var result = await _productService.AddAsync(dto);
            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Ürün eklenemedi.");
                await FillDropdowns();
                return View(vm);
            }

            // 🔹 Test datası dosyası yüklendiyse Excel'den veritabanına aktar
            if (!string.IsNullOrEmpty(testDataPath))
            {
                try
                {
                    await _productTestDataImportService.ImportAsync(result.Data.Id, testDataPath);
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "Ürün eklendi ancak test datası içeri alınamadı: " + ex.Message;
                }
            }

            TempData["SuccessMessage"] = "Ürün başarıyla eklendi.";
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region EDIT
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

            // 🔹 Dosya güncelleme
            var image1Path = await SaveFileIfExists(vm.Image1File, "uploads/images/product", FileType.Image, existing.Image1Path);
            var image2Path = await SaveFileIfExists(vm.Image2File, "uploads/images/product", FileType.Image, existing.Image2Path);
            var image3Path = await SaveFileIfExists(vm.Image3File, "uploads/images/product", FileType.Image, existing.Image3Path);
            var image4Path = await SaveFileIfExists(vm.Image4File, "uploads/images/product", FileType.Image, existing.Image4Path);
            var image5Path = await SaveFileIfExists(vm.Image5File, "uploads/images/product", FileType.Image, existing.Image5Path);
            var dataSheetPath = await SaveFileIfExists(vm.DataSheetFile, "uploads/datasheets/product", FileType.Pdf, existing.DataSheetPath);
            var model3DPath = await SaveFileIfExists(vm.Model3DFile, "uploads/model3D/product", FileType.Model3D, existing.Model3DPath);
            var testDataPath = await SaveFileIfExists(vm.TestDataFile, "uploads/test-data/product", FileType.TestData, existing.TestDataPath);
            var scaleImagePath = await SaveFileIfExists(vm.ScaleImageFile, "uploads/images/product", FileType.Image, existing.ScaleImagePath);

            // 🔹 DTO dönüşümü
            var dto = vm.ToDto(image1Path, image2Path, image3Path, image4Path, image5Path, dataSheetPath, model3DPath, testDataPath, scaleImagePath, existing.CreatedAt);

            var result = await _productService.UpdateAsync(dto);
            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Ürün güncellenemedi.");
                await FillDropdowns();
                return View(vm);
            }

            // 🔹 Test datası dosyası yüklendiyse, Excel'den yeniden veritabanına aktar
            if (!string.IsNullOrEmpty(testDataPath))
            {
                try
                {
                    await _productTestDataImportService.ImportAsync(vm.Id, testDataPath);
                    TempData["SuccessMessage"] = "Ürün ve test verileri başarıyla güncellendi.";
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "Ürün güncellendi ancak test datası içeri alınamadı: " + ex.Message;
                }
            }
            else
            {
                TempData["SuccessMessage"] = "Ürün başarıyla güncellendi.";
            }

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int productId)
        {
            var productResult = await _productService.GetByIdAsync(productId);
            if (!productResult.Success || productResult.Data == null)
            {
                TempData["Error"] = "Ürün bulunamadı.";
                return RedirectToAction(nameof(Index));
            }

            var result = await _productService.DeleteAsync(productId);
            if (!result.Success)
            {
                TempData["Error"] = result.ErrorMessage ?? "Ürün silinemedi.";
                return RedirectToAction(nameof(Index));
            }

            // 🔹 Dosyaları temizle
            var p = productResult.Data;
            _fileService.DeleteFile(p.Image1Path, "uploads/images/product");
            _fileService.DeleteFile(p.Image2Path, "uploads/images/product");
            _fileService.DeleteFile(p.Image3Path, "uploads/images/product");
            _fileService.DeleteFile(p.Image4Path, "uploads/images/product");
            _fileService.DeleteFile(p.Image5Path, "uploads/images/product");

            _fileService.DeleteFile(p.DataSheetPath, "uploads/datasheets/product");
            _fileService.DeleteFile(p.Model3DPath, "uploads/model3D/product");
            _fileService.DeleteFile(p.TestDataPath, "uploads/test-data/product");
            _fileService.DeleteFile(p.ScaleImagePath, "uploads/images/product");

            TempData["SuccessMessage"] = "Ürün başarıyla silindi.";
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region HELPERS
        private async Task<string?> SaveFileIfExists(IFormFile? file, string folder, FileType type, string? existingPath = null)
        {
            if (file != null)
                return await _fileService.SaveFileAsync(file, folder, type);

            return existingPath;
        }

        private async Task FillDropdowns()
        {
            // 🔹 Kategoriler
            var productCategoryList = await _productCategoryService.GetAllAsync();
            ViewBag.ProductCategoryList = productCategoryList.Success && productCategoryList.Data != null
                ? new SelectList(productCategoryList.Data, "Id", "Name")
                : new SelectList(Enumerable.Empty<SelectListItem>());

            // 🔹 Uygulama Alanları
            var appList = await _productApplicationService.GetAllAsync();
            ViewBag.ProductApplications = appList.Success && appList.Data != null
                ? new MultiSelectList(appList.Data, "Id", "Name")
                : new MultiSelectList(Enumerable.Empty<SelectListItem>());
        }
        #endregion
    }
}
