using GurventVantilator.Application.DTOs.WorkingPoint;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.AdminUI.Controllers
{
    public class WorkingPointController : Controller
    {
        private readonly IWorkingPointService _workingPointService;

        public WorkingPointController(IWorkingPointService workingPointService)
        {
            _workingPointService = workingPointService;
        }


        [HttpPost]
        public async Task<IActionResult> Calculate(
     int productId,
     WorkingPointRequestDto request)
        {
            var result = await _workingPointService.CalculateAsync(productId, request);

            if (result == null)
                return NotFound();

            return Json(result);
        }

    }
}
