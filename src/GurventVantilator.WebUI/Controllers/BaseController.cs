using GurventVantilator.Application.Common;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.WebUI.Controllers
{
    public class BaseController : Controller
    {
        private readonly IPageImageService _pageImageService;

        public BaseController(IPageImageService pageImageService)
        {
            _pageImageService = pageImageService;
        }
        protected IActionResult HandleError<T>(Result<T> result, string action = "Show", string controller = "Error")
        {
            TempData["ErrorMessage"] = result.ErrorMessage ?? "Beklenmeyen bir hata oluştu.";
            return RedirectToAction(action, controller);
        }

        protected async Task SetPageImageAsync(string pageKey, string sectionKey = "Breadcrumb")
        {
            var result = await _pageImageService.GetImageAsync(pageKey, sectionKey);
            if (result.Success && result.Data != null)
                ViewBag.PageImage = result.Data;
        }
    }
}
