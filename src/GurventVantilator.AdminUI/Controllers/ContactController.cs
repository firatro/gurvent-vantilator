using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.AdminUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IFileService _fileService;

        public ContactController(IContactService contactService, IFileService fileService)
        {
            _contactService = contactService;
            _fileService = fileService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _contactService.GetAllAsync();

            if (!result.Success || result.Data == null)
            {
                ViewBag.ErrorMessage = result.ErrorMessage ?? "İletişim listesi yüklenemedi.";
                return View(new List<ContactDto>()); 
            }

            return View(result.Data);
        }

        public async Task<IActionResult> Edit(int contactId)
        {
            var result = await _contactService.GetByIdAsync(contactId);

            if (!result.Success || result.Data == null)
            {
                return NotFound();
            }

            return View(result.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ContactDto contact)
        {
            if (!ModelState.IsValid)
                return View(contact);

            var result = await _contactService.UpdateAsync(contact);

            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Kayıt güncellenemedi.");
                return View(contact);
            }

            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int contactId)
        {
            var result = await _contactService.DeleteAsync(contactId);

            if (!result.Success)
            {
                TempData["Error"] = result.ErrorMessage ?? "Kayıt silinemedi.";
            }

            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde silindi.";
            return RedirectToAction(nameof(Index));
        }
    }

}
