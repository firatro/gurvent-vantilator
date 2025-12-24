using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.AdminUI.Models.Product;
using GurventVantilator.AdminUI.Mappings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using GurventVantilator.Application.Common;
using GurventVantilator.AdminUI.Controllers;
using GurventVantilator.Application.Enums;

namespace GurventVantilator.AdminUI.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IProductSeriesService _seriesService;
        private readonly IProductModelService _modelService;
        private readonly IProductUsageTypeService _usageTypeService;
        private readonly IProductWorkingConditionService _workingConditionService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(
            IFileService fileService,
            IProductService productService,
            IProductSeriesService seriesService,
            IProductModelService modelService,
            IProductUsageTypeService usageTypeService,
            IProductWorkingConditionService workingConditionService,
            ILogger<ProductController> logger)
            : base(fileService)
        {
            _productService = productService;
            _seriesService = seriesService;
            _modelService = modelService;
            _usageTypeService = usageTypeService;
            _workingConditionService = workingConditionService;
            _logger = logger;
        }

        // ======================================================
        // 📋 Listeleme
        // ======================================================
        public async Task<IActionResult> Index()
        {
            var result = await _productService.GetAllAsync();
            if (!result.Success)
            {
                SetErrorMessage(result.ErrorMessage ?? "Ürün listesi alınamadı.");
                return View(new List<ProductDto>());
            }
            return View(result.Data.OrderBy(p => p.Order));
        }

        // ======================================================
        // ➕ Yeni Ürün Ekle (GET)
        // ======================================================
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await PopulateDropdowns();
            return View(new ProductCreateViewModel());
        }

        // ======================================================
        // ➕ Yeni Ürün Ekle (POST)
        // ======================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropdowns();
                return View(vm);
            }

            try
            {
                // --- Dosya yükleme ---
                var image1Path = await SaveImageAsync(vm.Image1File, "uploads/images/products", FileType.Image);
                var image2Path = await SaveImageAsync(vm.Image2File, "uploads/images/products", FileType.Image);
                var image3Path = await SaveImageAsync(vm.Image3File, "uploads/images/products", FileType.Image);
                var image4Path = await SaveImageAsync(vm.Image4File, "uploads/images/products", FileType.Image);
                var image5Path = await SaveImageAsync(vm.Image5File, "uploads/images/products", FileType.Image);
                var dataSheetPath = await SaveImageAsync(vm.DataSheetFile, "uploads/datasheets/products", FileType.Pdf);
                var model3DPath = await SaveImageAsync(vm.Model3DFile, "uploads/model3D/products", FileType.Model3D);
                var testDataPath = await SaveImageAsync(vm.TestDataFile, "uploads/testdata/products", FileType.TestData);
                var scaleImagePath = await SaveImageAsync(vm.ScaleImageFile, "uploads/scale/products", FileType.Image);

                var dto = vm.ToDto(image1Path, image2Path, image3Path, image4Path, image5Path,
                                   dataSheetPath, model3DPath, testDataPath, scaleImagePath);

                var result = await _productService.AddAsync(dto);
                return HandleServiceResult(result, nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ürün eklenirken hata oluştu");
                SetErrorMessage($"Bir hata oluştu: {ex.Message}");
                await PopulateDropdowns();
                return View(vm);
            }
        }

        // ======================================================
        // ✏️ Ürün Güncelle (GET)
        // ======================================================
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _productService.GetByIdAsync(id);
            if (!result.Success || result.Data == null)
            {
                SetErrorMessage("Ürün bulunamadı.");
                return RedirectToAction(nameof(Index));
            }

            var vm = result.Data.ToEditViewModel();
            await PopulateDropdowns(vm.ProductSeriesId, vm.ProductModelId);
            return View(vm);
        }

        // ======================================================
        // ✏️ Ürün Güncelle (POST)
        // ======================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductEditViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropdowns(vm.ProductSeriesId, vm.ProductModelId);
                return View(vm);
            }

            try
            {
                // 🔹 Eski ürün bilgilerini al
                var existing = await _productService.GetByIdAsync(vm.Id);
                if (!existing.Success || existing.Data == null)
                {
                    SetErrorMessage("Ürün bulunamadı.");
                    return RedirectToAction(nameof(Index));
                }

                var old = existing.Data;

                // --- Dosya güncellemeleri ---
                var image1Path = vm.Image1File != null
                    ? await SaveImageAsync(vm.Image1File, "uploads/images/products", FileType.Image)
                    : old.Image1Path;

                var image2Path = vm.Image2File != null
                    ? await SaveImageAsync(vm.Image2File, "uploads/images/products", FileType.Image)
                    : old.Image2Path;

                var image3Path = vm.Image3File != null
                    ? await SaveImageAsync(vm.Image3File, "uploads/images/products", FileType.Image)
                    : old.Image3Path;

                var image4Path = vm.Image4File != null
                    ? await SaveImageAsync(vm.Image4File, "uploads/images/products", FileType.Image)
                    : old.Image4Path;

                var image5Path = vm.Image5File != null
                    ? await SaveImageAsync(vm.Image5File, "uploads/images/products", FileType.Image)
                    : old.Image5Path;

                var dataSheetPath = vm.DataSheetFile != null
                    ? await SaveImageAsync(vm.DataSheetFile, "uploads/datasheets/products", FileType.Pdf)
                    : old.DataSheetPath;

                var model3DPath = vm.Model3DFile != null
                    ? await SaveImageAsync(vm.Model3DFile, "uploads/model3D/products", FileType.Model3D)
                    : old.Model3DPath;

                var testDataPath = vm.TestDataFile != null
                    ? await SaveImageAsync(vm.TestDataFile, "uploads/testdata/products", FileType.TestData)
                    : old.TestDataPath;

                var scaleImagePath = vm.ScaleImageFile != null
                    ? await SaveImageAsync(vm.ScaleImageFile, "uploads/scale/products", FileType.Image)
                    : old.ScaleImagePath;

                // DTO'ya dönüştür
                var dto = vm.ToDto(image1Path, image2Path, image3Path, image4Path, image5Path,
                                   dataSheetPath, model3DPath, testDataPath, scaleImagePath,
                                   old.CreatedAt);

                var result = await _productService.UpdateAsync(dto);
                return HandleServiceResult(result, nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ürün güncellenirken hata oluştu");
                SetErrorMessage($"Bir hata oluştu: {ex.Message}");
                await PopulateDropdowns(vm.ProductSeriesId, vm.ProductModelId);
                return View(vm);
            }
        }

        // ======================================================
        // 🗑️ Ürün Sil
        // ======================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product.Success && product.Data != null)
            {
                DeleteFileIfExists(product.Data.Image1Path, "uploads/images/products");
                DeleteFileIfExists(product.Data.Image2Path, "uploads/images/products");
                DeleteFileIfExists(product.Data.Image3Path, "uploads/images/products");
                DeleteFileIfExists(product.Data.Image4Path, "uploads/images/products");
                DeleteFileIfExists(product.Data.Image5Path, "uploads/images/products");
                DeleteFileIfExists(product.Data.DataSheetPath, "uploads/datasheets/products");
                DeleteFileIfExists(product.Data.Model3DPath, "uploads/model3D/products");
                DeleteFileIfExists(product.Data.ScaleImagePath, "uploads/scale/products");
            }

            var result = await _productService.DeleteAsync(id);

            if (!result.Success)
            {
                TempData["Error"] = result.ErrorMessage ?? "Ürün silinemedi.";
                return RedirectToAction(nameof(Index));
            }

            TempData["Success"] = "Ürün başarıyla silindi.";
            return RedirectToAction(nameof(Index));
        }


        // ======================================================
        // 🔹 Dropdown Verileri
        // ======================================================
        private async Task PopulateDropdowns(int? selectedSeriesId = null, int? selectedModelId = null)
        {
            var seriesResult = await _seriesService.GetAllAsync();
            var modelResult = await _modelService.GetAllAsync();
            var usageResult = await _usageTypeService.GetAllAsync();
            var conditionResult = await _workingConditionService.GetAllAsync();

            ViewBag.SeriesList = new SelectList(seriesResult.Data, "Id", "Name", selectedSeriesId);
            ViewBag.ModelList = new SelectList(modelResult.Data, "Id", "Name", selectedModelId);
            ViewBag.UsageTypeList = usageResult.Data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
            ViewBag.WorkingConditionList = conditionResult.Data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

        }
    }
}
