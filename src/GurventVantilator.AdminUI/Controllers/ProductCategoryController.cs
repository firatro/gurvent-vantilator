using GurventVantilator.AdminUI.Mappings;
using GurventVantilator.AdminUI.Models.ProductCategory;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Enums;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class ProductCategoryController : Controller
{
    private readonly IProductCategoryService _productCategoryService;
    private readonly IFileService _fileService;

    public ProductCategoryController(IProductCategoryService productCategoryService, IFileService fileService)
    {
        _productCategoryService = productCategoryService;
        _fileService = fileService;
    }

    // public async Task<IActionResult> Index()
    // {
    //     var result = await _productCategoryService.GetAllAsync();

    //     if (!result.Success || result.Data == null)
    //     {
    //         ViewBag.ErrorMessage = result.ErrorMessage ?? "Kategoriler listelenemedi.";
    //         return View(new List<ProductCategoryDto>());
    //     }

    //     return View(result.Data);
    // }

    public async Task<IActionResult> Index()
    {
        var result = await _productCategoryService.GetAllAsync(onlyTopLevel: false);
        return View(result.Data);
    }

    // [HttpGet]
    // public async Task<IActionResult> Create()
    // {
    //     var vm = new ProductCategoryCreateViewModel();
    //     await FillDropdowns(createVm: vm);
    //     return View(vm);
    // }

    [HttpGet]
    public async Task<IActionResult> Create(int? parentCategoryId = null)
    {
        var vm = new ProductCategoryCreateViewModel
        {
            ParentCategoryId = parentCategoryId
        };

        await FillDropdowns(createVm: vm);
        return View(vm);
    }

    // [HttpPost]
    // [ValidateAntiForgeryToken]
    // public async Task<IActionResult> Create(ProductCategoryCreateViewModel vm)
    // {
    //     if (!ModelState.IsValid)
    //     {
    //         await FillDropdowns(createVm: vm);
    //         return View(vm);
    //     }

    //     string? imagePath = null;
    //     if (vm.ImageFile != null)
    //         imagePath = await _fileService.SaveFileAsync(vm.ImageFile, "uploads/images/product-category", FileType.Image);

    //     var dto = vm.ToDto(imagePath);
    //     dto.ParentCategoryId = vm.ParentCategoryId;

    //     var result = await _productCategoryService.AddAsync(dto);
    //     if (!result.Success)
    //     {
    //         ModelState.AddModelError("", result.ErrorMessage ?? "Kategori eklenemedi.");
    //         await FillDropdowns(createVm: vm);
    //         return View(vm);
    //     }

    //     TempData["SuccessMessage"] = "Kategori başarıyla eklendi.";
    //     return RedirectToAction(nameof(Index));
    // }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductCategoryCreateViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            await FillDropdowns(createVm: vm);
            return View(vm);
        }

        string? imagePath = null;
        if (vm.ImageFile != null)
            imagePath = await _fileService.SaveFileAsync(vm.ImageFile, "uploads/images/product-category", FileType.Image);

        var dto = vm.ToDto(imagePath);
        dto.ParentCategoryId = vm.ParentCategoryId;

        var result = await _productCategoryService.AddAsync(dto);
        if (!result.Success)
        {
            ModelState.AddModelError("", result.ErrorMessage ?? "Kategori eklenemedi.");
            await FillDropdowns(createVm: vm);
            return View(vm);
        }

        TempData["SuccessMessage"] = "Kategori başarıyla eklendi.";
        return RedirectToAction(nameof(Index));
    }

    // [HttpGet]
    // public async Task<IActionResult> Edit(int productCategoryId)
    // {
    //     var result = await _productCategoryService.GetByIdAsync(productCategoryId);
    //     if (!result.Success || result.Data == null)
    //         return NotFound();

    //     var vm = result.Data.ToEditViewModel();
    //     await FillDropdowns(editVm: vm);
    //     return View(vm);
    // }

    [HttpGet]
    public async Task<IActionResult> Edit(int productCategoryId)
    {
        var result = await _productCategoryService.GetByIdAsync(productCategoryId);
        if (!result.Success || result.Data == null)
            return NotFound();

        var vm = result.Data.ToEditViewModel();
        await FillDropdowns(editVm: vm);
        return View(vm);
    }

    // [HttpPost]
    // [ValidateAntiForgeryToken]
    // public async Task<IActionResult> Edit(ProductCategoryEditViewModel vm)
    // {
    //     if (!ModelState.IsValid)
    //     {
    //         await FillDropdowns(editVm: vm);
    //         return View(vm);
    //     }

    //     string? imagePath = vm.ImageFile != null
    //         ? await _fileService.SaveFileAsync(vm.ImageFile, "uploads/images/product-category", FileType.Image)
    //         : vm.ImagePath;

    //     var dto = vm.ToDto(imagePath);
    //     dto.ParentCategoryId = vm.ParentCategoryId;

    //     var result = await _productCategoryService.UpdateAsync(dto);
    //     if (!result.Success)
    //     {
    //         ModelState.AddModelError("", result.ErrorMessage ?? "Kategori güncellenemedi.");
    //         await FillDropdowns(editVm: vm);
    //         return View(vm);
    //     }

    //     TempData["SuccessMessage"] = "Kategori başarıyla güncellendi.";
    //     return RedirectToAction(nameof(Index));
    // }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ProductCategoryEditViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            await FillDropdowns(editVm: vm);
            return View(vm);
        }

        var existingResult = await _productCategoryService.GetByIdAsync(vm.Id);
        if (!existingResult.Success || existingResult.Data == null)
            return NotFound();

        var existing = existingResult.Data;

        string? imagePath = vm.ImageFile != null
            ? await _fileService.SaveFileAsync(vm.ImageFile, "uploads/images/product-category", FileType.Image)
            : existing.ImagePath;

        var dto = vm.ToDto(imagePath);

        dto.ParentCategoryId = vm.ParentCategoryId;

        var result = await _productCategoryService.UpdateAsync(dto);
        if (!result.Success)
        {
            ModelState.AddModelError("", result.ErrorMessage ?? "Kategori güncellenemedi.");
            await FillDropdowns(editVm: vm);
            return View(vm);
        }

        TempData["SuccessMessage"] = "Kategori başarıyla güncellendi.";
        return RedirectToAction(nameof(Index));
    }

    // [HttpPost]
    // [ValidateAntiForgeryToken]
    // public async Task<IActionResult> Delete(int productCategoryId)
    // {
    //     var result = await _productCategoryService.DeleteAsync(productCategoryId);
    //     if (!result.Success)
    //     {
    //         TempData["Error"] = result.ErrorMessage;
    //         return RedirectToAction(nameof(Index));
    //     }

    //     // Silinen productun görsellerini de temizle
    //     if (result.Success)
    //     {
    //         var productCategory = await _productCategoryService.GetByIdAsync(productCategoryId);
    //         if (productCategory.Success && productCategory.Data != null)
    //         {
    //             _fileService.DeleteFile(productCategory.Data.ImagePath, "uploads/images/product-category");
    //         }
    //     }

    //     TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde silindi.";
    //     return RedirectToAction(nameof(Index));
    // }

    [HttpPost]
    public async Task<IActionResult> Delete(int productCategoryId)
    {
        var result = await _productCategoryService.DeleteAsync(productCategoryId);
        if (!result.Success)
            TempData["Error"] = result.ErrorMessage ?? "Silme işlemi başarısız.";
        else
            TempData["SuccessMessage"] = "Kategori silindi.";

        return RedirectToAction(nameof(Index));
    }

    private async Task FillDropdowns(ProductCategoryCreateViewModel? createVm = null, ProductCategoryEditViewModel? editVm = null)
    {
        var categoriesResult = await _productCategoryService.GetAllAsync();
        if (!categoriesResult.Success || categoriesResult.Data == null)
        {
            if (createVm != null) createVm.ParentCategoryList = new List<SelectListItem>();
            if (editVm != null) editVm.ParentCategoryList = new List<SelectListItem>();
            return;
        }

        var categories = categoriesResult.Data;

        // 🔹 Edit ekranındaysak: Kendisi ve alt kategorileri hariç tut
        if (editVm != null)
        {
            var excludedIds = GetAllSubCategoryIds(categories, editVm.Id);
            excludedIds.Add(editVm.Id); // kendisi de hariç

            categories = categories
                .Where(c => !excludedIds.Contains(c.Id))
                .ToList();
        }

        // 🔹 Hiyerarşik liste (düz ama tüm uygun kategoriler)
        var items = categories
            .Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            })
            .OrderBy(x => x.Text)
            .ToList();

        if (createVm != null)
            createVm.ParentCategoryList = items;

        if (editVm != null)
            editVm.ParentCategoryList = items;
    }

    private List<int> GetAllSubCategoryIds(List<ProductCategoryDto> categories, int parentId)
    {
        var subIds = new List<int>();

        void AddSubIds(int parent)
        {
            var children = categories.Where(c => c.ParentCategoryId == parent).ToList();
            foreach (var child in children)
            {
                subIds.Add(child.Id);
                AddSubIds(child.Id);
            }
        }

        AddSubIds(parentId);
        return subIds;
    }



}
