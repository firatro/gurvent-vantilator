using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.AdminUI.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _tagService.GetAllAsync();

            if (!result.Success || result.Data == null)
            {
                ViewBag.ErrorMessage = result.ErrorMessage ?? "Etiketler listelenemedi.";
                return View(new List<TagDto>());
            }

            return View(result.Data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TagDto tag)
        {
            if (!ModelState.IsValid) return View(tag);

            var result = await _tagService.AddAsync(tag);
            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Etiket eklenemedi.");
                return View(tag);
            }

            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde eklendi.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int tagId)
        {
            var result = await _tagService.GetByIdAsync(tagId);
            if (!result.Success || result.Data == null)
                return NotFound();

            return View(result.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TagDto tag)
        {
            if (!ModelState.IsValid) return View(tag);

            var result = await _tagService.UpdateAsync(tag);
            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Etiket güncellenemedi.");
                return View(tag);
            }

            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int tagId)
        {
            var result = await _tagService.DeleteAsync(tagId);

            if (!result.Success)
                TempData["Error"] = result.ErrorMessage ?? "Etiket silinemedi.";

            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde silindi.";
            return RedirectToAction(nameof(Index));
        }
    }

}
