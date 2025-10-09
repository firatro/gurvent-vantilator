using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.WebUI.Controllers
{
    public class ContactController : BaseController
    {
        private readonly IContactService _contactService;
        private readonly ISiteInfoService _siteInfoService;

        public ContactController(
            IContactService contactService,
            ISiteInfoService siteInfoService,
            IPageImageService pageImageService
        ) : base(pageImageService)
        {
            _contactService = contactService;
            _siteInfoService = siteInfoService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var siteInfoResult = await _siteInfoService.GetAsync();
            if (!siteInfoResult.Success || siteInfoResult.Data == null)
                return HandleError(siteInfoResult);

            var vm = new ContactPageViewModel
            {
                Contact = new ContactDto(),
                SiteInfo = siteInfoResult.Data
            };

            await SetPageImageAsync("Contact");

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ContactPageViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                var siteInfoResult = await _siteInfoService.GetAsync();
                vm.SiteInfo = siteInfoResult.Data;
                return View(vm);
            }

            vm.Contact.CreatedAt = DateTime.Now;

            var result = await _contactService.AddAsync(vm.Contact);
            if (!result.Success)
            {
                ViewBag.Error = result.ErrorMessage ?? "Mesaj gönderilirken hata oluştu.";
                var siteInfoResult = await _siteInfoService.GetAsync();
                vm.SiteInfo = siteInfoResult.Data;
                return View(vm);
            }

            TempData["Success"] = "Mesajınız başarıyla gönderildi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContactDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Geçersiz veri.");

            dto.CreatedAt = DateTime.Now;
            var result = await _contactService.AddAsync(dto);

            if (!result.Success)
                return BadRequest(result.ErrorMessage ?? "Mesaj gönderilirken hata oluştu.");

            return Ok(new { message = "Mesajınız başarıyla gönderildi." });
        }

    }
}
