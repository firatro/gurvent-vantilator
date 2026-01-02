using GurventVantilator.AdminUI.Models.ProductModel;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Enums;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Application.Mappings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GurventVantilator.AdminUI.Controllers
{
    public class ProductModelController : BaseController
    {
        private readonly IProductModelService _modelService;
        private readonly IProductSeriesService _seriesService;
        private readonly IProductUsageTypeService _usageTypeService;
        private readonly IProductWorkingConditionService _workingConditionService;
        private readonly IProductModelDocumentService _documentService;

        public ProductModelController(
            IFileService fileService,
            IProductModelService modelService,
            IProductSeriesService seriesService,
            IProductUsageTypeService usageTypeService,
            IProductWorkingConditionService workingConditionService,
            IProductModelDocumentService documentService
        ) : base(fileService)
        {
            _modelService = modelService;
            _seriesService = seriesService;
            _usageTypeService = usageTypeService;
            _workingConditionService = workingConditionService;
            _documentService = documentService;
        }

        // ======================================================
        // 📋 INDEX
        // ======================================================
        public async Task<IActionResult> Index()
        {
            var result = await _modelService.GetAllAsync();

            if (!result.Success || result.Data == null)
            {
                SetErrorMessage(result.ErrorMessage ?? "Modeller alınamadı.");
                return View(new List<ProductModelDto>());
            }

            return View(result.Data.OrderBy(x => x.Order));
        }

        // ======================================================
        // ➕ CREATE (GET)
        // ======================================================
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await PopulateDropdowns();
            return View(new ProductModelCreateViewModel());
        }

        // ======================================================
        // ➕ CREATE (POST)
        // ======================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductModelCreateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropdowns();
                return View(vm);
            }

            // -----------------------------
            // 📌 Görseller
            // -----------------------------
            var image1Path = await SaveImageAsync(vm.Image1File, "uploads/models", FileType.Image);
            var image2Path = await SaveImageAsync(vm.Image2File, "uploads/models", FileType.Image);
            var image3Path = await SaveImageAsync(vm.Image3File, "uploads/models", FileType.Image);
            var image4Path = await SaveImageAsync(vm.Image4File, "uploads/models", FileType.Image);
            var image5Path = await SaveImageAsync(vm.Image5File, "uploads/models", FileType.Image);

            // -----------------------------
            // 📌 Ek dosyalar
            // -----------------------------
            var dataSheetPath = await SaveImageAsync(vm.DataSheetFile, "uploads/datasheets", FileType.Pdf);
            var model3DPath = await SaveImageAsync(vm.Model3DFile, "uploads/3d", FileType.Model3D);
            var testDataPath = await SaveImageAsync(vm.TestDataFile, "uploads/testdata", FileType.TestData);
            var scaleImagePath = await SaveImageAsync(vm.ScaleImageFile, "uploads/models", FileType.Image);

            // -----------------------------
            // 📌 DTO’ya dönüştür
            // -----------------------------
            var dto = vm.ToDto(
                image1Path,
                image2Path,
                image3Path,
                image4Path,
                image5Path,
                dataSheetPath,
                model3DPath,
                testDataPath,
                scaleImagePath
            );

            var result = await _modelService.AddAsync(dto);

            if (!result.Success)
            {
                SetErrorMessage(result.ErrorMessage);
                await PopulateDropdowns();
                return View(vm);
            }

            int modelId = result.Data.Id;

            // -----------------------------
            // 📄 PDF Dokümanları ekle
            // -----------------------------
            if (vm.DocumentFiles != null && vm.DocumentFiles.Any())
            {
                foreach (var file in vm.DocumentFiles)
                {
                    var filePath = await SaveImageAsync(file, "uploads/model-documents", FileType.Pdf);

                    if (filePath != null)
                    {
                        await _documentService.AddAsync(new ProductModelDocumentDto
                        {
                            ProductModelId = modelId,
                            Title = file.FileName,
                            FilePath = filePath
                        });
                    }
                }
            }

            SetSuccessMessage("Model başarıyla eklendi.");
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _modelService.GetByIdAsync(id);
            if (!result.Success || result.Data == null)
            {
                SetErrorMessage("Model bulunamadı.");
                return RedirectToAction(nameof(Index));
            }

            var vm = result.Data.ToEditVm();
            vm.ExistingDocuments = await _documentService.GetByModelIdAsync(id);

            await PopulateDropdowns(vm.ProductSeriesId);
            return View(vm);
        }


        // ======================================================
        // ✏️ EDIT (POST)
        // ======================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductModelEditViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.ExistingDocuments = await _documentService.GetByModelIdAsync(vm.Id);
                await PopulateDropdowns(vm.ProductSeriesId);
                return View(vm);
            }

            // 1️⃣ Eski modeli veritabanından çek
            var existingResult = await _modelService.GetByIdAsync(vm.Id);
            if (!existingResult.Success || existingResult.Data == null)
            {
                SetErrorMessage("Model bulunamadı.");
                return RedirectToAction(nameof(Index));
            }

            var oldDto = existingResult.Data;

            // 2️⃣ Silinecek özellik ID'lerini string → int list dönüştür
            var deletedFeatureIds = new List<int>();
            if (!string.IsNullOrEmpty(vm.DeletedFeatureIdsString))
            {
                deletedFeatureIds = vm.DeletedFeatureIdsString
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
            }

            // 3️⃣ Dosya yüklemeleri (null değilse yenisi alınır, değilse eskisi korunur)
            string? image1Path = vm.Image1File != null ? await SaveImageAsync(vm.Image1File, "uploads/models", FileType.Image) : null;
            string? image2Path = vm.Image2File != null ? await SaveImageAsync(vm.Image2File, "uploads/models", FileType.Image) : null;
            string? image3Path = vm.Image3File != null ? await SaveImageAsync(vm.Image3File, "uploads/models", FileType.Image) : null;
            string? image4Path = vm.Image4File != null ? await SaveImageAsync(vm.Image4File, "uploads/models", FileType.Image) : null;
            string? image5Path = vm.Image5File != null ? await SaveImageAsync(vm.Image5File, "uploads/models", FileType.Image) : null;

            string? dataSheetPath = vm.DataSheetFile != null ? await SaveImageAsync(vm.DataSheetFile, "uploads/datasheets", FileType.Pdf) : null;
            string? model3DPath = vm.Model3DFile != null ? await SaveImageAsync(vm.Model3DFile, "uploads/3d", FileType.Model3D) : null;
            string? testDataPath = vm.TestDataFile != null ? await SaveImageAsync(vm.TestDataFile, "uploads/testdata", FileType.TestData) : null;
            string? scaleImagePath = vm.ScaleImageFile != null ? await SaveImageAsync(vm.ScaleImageFile, "uploads/models", FileType.Image) : null;

            // 4️⃣ DTO oluştur (mapping bunu otomatik yapacak)
            var updateDto = vm.ToUpdateDto(
                oldDto,
                image1Path,
                image2Path,
                image3Path,
                image4Path,
                image5Path,
                dataSheetPath,
                model3DPath,
                testDataPath,
                scaleImagePath
            );

            // 5️⃣ Silinecek özellik ID'lerini DTO’ya gönder
            updateDto.DeletedFeatureIds = deletedFeatureIds;

            // 6️⃣ Servis üzerinden güncelleme
            var updateResult = await _modelService.UpdateAsync(updateDto);

            if (!updateResult.Success)
            {
                SetErrorMessage(updateResult.ErrorMessage);
                vm.ExistingDocuments = await _documentService.GetByModelIdAsync(vm.Id);
                await PopulateDropdowns(vm.ProductSeriesId);
                return View(vm);
            }

            // 7️⃣ Yeni PDF dokümanları ekle
            if (vm.NewDocumentFiles != null && vm.NewDocumentFiles.Any())
            {
                foreach (var file in vm.NewDocumentFiles)
                {
                    var filePath = await SaveImageAsync(file, "uploads/model-documents", FileType.Pdf);

                    if (filePath != null)
                    {
                        await _documentService.AddAsync(new ProductModelDocumentDto
                        {
                            ProductModelId = vm.Id,
                            Title = file.FileName,
                            FilePath = filePath
                        });
                    }
                }
            }

            // ✔ Başarılı
            SetSuccessMessage("Model başarıyla güncellendi.");
            return RedirectToAction(nameof(Index));
        }



        // ======================================================
        // 🗑 DELETE DOCUMENT
        // ======================================================
        [HttpGet]
        public async Task<IActionResult> DeleteDocument(int id)
        {
            var doc = await _documentService.GetByIdAsync(id);

            if (doc != null)
            {
                DeleteFileIfExists(doc.FilePath, "uploads/model-documents");
                await _documentService.DeleteAsync(id);
            }

            SetSuccessMessage("Doküman silindi.");
            return Redirect(Request.Headers["Referer"].ToString());
        }


        // ======================================================
        // 🗑 DELETE MODEL
        // ======================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {

            Console.WriteLine("DELETE ID = " + id);

            if (id <= 0)
            {
                SetErrorMessage("ID POST edilmedi.");
                return RedirectToAction(nameof(Index));
            }

            var existing = await _modelService.GetByIdAsync(id);

            if (existing.Success && existing.Data != null)
            {
                DeleteFileIfExists(existing.Data.Image1Path, "uploads/models");
                DeleteFileIfExists(existing.Data.Image2Path, "uploads/models");
                DeleteFileIfExists(existing.Data.Image3Path, "uploads/models");
                DeleteFileIfExists(existing.Data.Image4Path, "uploads/models");
                DeleteFileIfExists(existing.Data.Image5Path, "uploads/models");

                DeleteFileIfExists(existing.Data.DataSheetPath, "uploads/datasheets");
                DeleteFileIfExists(existing.Data.Model3DPath, "uploads/3d");
                DeleteFileIfExists(existing.Data.TestDataPath, "uploads/testdata");
                DeleteFileIfExists(existing.Data.ScaleImagePath, "uploads/models");

                var documents = await _documentService.GetByModelIdAsync(id);
                foreach (var doc in documents)
                {
                    DeleteFileIfExists(doc.FilePath, "uploads/model-documents");
                    await _documentService.DeleteAsync(doc.Id);
                }
            }

            var result = await _modelService.DeleteAsync(id);

            if (!result.Success)
                SetErrorMessage(result.ErrorMessage ?? "Silme işlemi başarısız.");
            else
                SetSuccessMessage("Model başarıyla silindi.");

            return RedirectToAction(nameof(Index));
        }

        // ======================================================
        // 🔽 DROPDOWNS
        // ======================================================
        private async Task PopulateDropdowns(int? selectedSeriesId = null)
        {
            var seriesResult = await _seriesService.GetAllAsync();
            var usageResult = await _usageTypeService.GetAllAsync();
            var workingResult = await _workingConditionService.GetAllAsync();

            ViewBag.SeriesList = new SelectList(seriesResult.Data ?? new List<ProductSeriesDto>(), "Id", "Name", selectedSeriesId);

            ViewBag.UsageTypeList = (usageResult.Data ?? new List<ProductUsageTypeDto>())
                .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name })
                .ToList();

            ViewBag.WorkingConditionList = (workingResult.Data ?? new List<ProductWorkingConditionDto>())
                .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name })
                .ToList();
        }

        [HttpGet]
        public async Task<IActionResult> Copy(int id)
        {
            var result = await _modelService.GetByIdAsync(id);
            if (!result.Success || result.Data == null)
            {
                SetErrorMessage("Kopyalanacak model bulunamadı.");
                return RedirectToAction(nameof(Index));
            }

            var copyDto = result.Data.ToCopyDto();

            var addResult = await _modelService.AddAsync(copyDto);
            if (!addResult.Success)
            {
                SetErrorMessage(addResult.ErrorMessage ?? "Model kopyalanamadı.");
                return RedirectToAction(nameof(Index));
            }

            SetSuccessMessage("Model tüm verileriyle kopyalandı.");
            return RedirectToAction(nameof(Edit), new { id = addResult.Data.Id });
        }

    }
}
