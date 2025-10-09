using GurventVantilator.Application.Interfaces;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Cosmedest.WebUI.Controllers
{
    public class FanSelectorController : BaseController
    {

        public FanSelectorController(IPageImageService pageImageService) : base(pageImageService)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
