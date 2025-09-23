using GurventVantilator.AdminUI.Models.Blog;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.AdminUI.Mappings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GurventVantilator.AdminUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;
        private readonly IFileService _fileService;

        public BlogController(IBlogService blogService, ICategoryService categoryService, ITagService tagService, IFileService fileService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _tagService = tagService;
            _fileService = fileService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _blogService.GetAllAsync();
            if (!result.Success)
            {
                TempData["Error"] = result.ErrorMessage;
                return View(new List<BlogDto>()); // Boş liste dön
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
        public async Task<IActionResult> Create(BlogCreateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                await FillDropdowns();
                return View(vm);
            }

            var mainImagePath = vm.MainImageFile != null
                ? await _fileService.SaveFileAsync(vm.MainImageFile, "uploads/images/blog")
                : null;

            var contentImage1Path = vm.ContentImage1File != null
                ? await _fileService.SaveFileAsync(vm.ContentImage1File, "uploads/images/blog")
                : null;

            var contentImage2Path = vm.ContentImage2File != null
                ? await _fileService.SaveFileAsync(vm.ContentImage2File, "uploads/images/blog")
                : null;

            var dto = vm.ToDto(mainImagePath, contentImage1Path, contentImage2Path);

            var result = await _blogService.AddAsync(dto, vm.TagIds);
            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Blog eklenemedi.");
                await FillDropdowns();
                return View(vm);
            }

            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde eklendi.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int blogId)
        {
            var result = await _blogService.GetByIdAsync(blogId);
            if (!result.Success || result.Data == null)
                return NotFound();

            var vm = result.Data.ToEditViewModel();
            await FillDropdowns();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BlogEditViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                await FillDropdowns();
                return View(vm);
            }

            var existingResult = await _blogService.GetByIdAsync(vm.Id);
            if (!existingResult.Success || existingResult.Data == null)
                return NotFound();

            var existing = existingResult.Data;

            var mainImagePath = vm.MainImageFile != null
                ? await _fileService.SaveFileAsync(vm.MainImageFile, "uploads/images/blog")
                : existing.MainImagePath;

            var contentImage1Path = vm.ContentImage1File != null
                ? await _fileService.SaveFileAsync(vm.ContentImage1File, "uploads/images/blog")
                : existing.ContentImage1Path;

            var contentImage2Path = vm.ContentImage2File != null
                ? await _fileService.SaveFileAsync(vm.ContentImage2File, "uploads/images/blog")
                : existing.ContentImage2Path;

            var dto = vm.ToDto(mainImagePath, contentImage1Path, contentImage2Path, existing.CreatedAt);

            var result = await _blogService.UpdateAsync(dto, vm.TagIds);
            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Blog güncellenemedi.");
                await FillDropdowns();
                return View(vm);
            }

            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int blogId)
        {
            var result = await _blogService.DeleteAsync(blogId);
            if (!result.Success)
            {
                TempData["Error"] = result.ErrorMessage;
                return RedirectToAction(nameof(Index));
            }

            // Silinen blogun görsellerini de temizle
            if (result.Success)
            {
                var blog = await _blogService.GetByIdAsync(blogId);
                if (blog.Success && blog.Data != null)
                {
                    _fileService.DeleteFile(blog.Data.MainImagePath, "uploads/images/blog");
                    _fileService.DeleteFile(blog.Data.ContentImage1Path, "uploads/images/blog");
                    _fileService.DeleteFile(blog.Data.ContentImage2Path, "uploads/images/blog");
                }
            }

            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde silindi.";
            return RedirectToAction(nameof(Index));
        }

        private async Task FillDropdowns()
        {
            var categoryList = await _categoryService.GetAllAsync();
            if (categoryList.Success && categoryList.Data != null)
            {
                ViewBag.CategoryList = new SelectList(categoryList.Data, "Id", "Name");
            }
            else
            {
                ViewBag.CategoryList = new SelectList(Enumerable.Empty<SelectListItem>());
                ViewBag.CategoryError = categoryList.ErrorMessage ?? "Kategori listesi yüklenemedi.";
            }

            var tagList = await _tagService.GetAllAsync();
            ViewBag.TagList = new SelectList(tagList.Data, "Id", "Name");
        }
    }
}
