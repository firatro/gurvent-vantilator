using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.WebUI.Controllers
{
    public class ServiceController : BaseController
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService, IPageImageService pageImageService)
            : base(pageImageService)
        {
            _serviceService = serviceService;
        }


        public async Task<IActionResult> Detail(int id)
        {
            var result = await _serviceService.GetByIdAsync(id);
            if (!result.Success || result.Data == null)
                return HandleError(result);

            await SetPageImageAsync("Service");
            return View(result.Data);
        }

    }
}
