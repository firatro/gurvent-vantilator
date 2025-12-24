using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.WebUI.Controllers
{
    public class ModelController : Controller
    {
        private readonly IProductModelService _modelService;
        private readonly IProductService _productService;

        public ModelController(
            IProductModelService modelService,
            IProductService productService)
        {
            _modelService = modelService;
            _productService = productService;
        }

        // =====================================
        // 📌 MODEL DETAY SAYFASI
        // =====================================
        public async Task<IActionResult> Detail(int id)
        {
            var modelResult = await _modelService.GetByIdAsync(id);
            if (!modelResult.Success || modelResult.Data == null)
                return NotFound();

            var model = modelResult.Data;

            var productResult = await _productService.GetByModelIdAsync(id);

            var viewModel = new ModelDetailViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Code = model.Code,
                Description = model.Description,

                Image1Path = model.Image1Path,
                Image2Path = model.Image2Path,
                Image3Path = model.Image3Path,
                Image4Path = model.Image4Path,
                Image5Path = model.Image5Path,

                DataSheetPath = model.DataSheetPath,
                Model3DPath = model.Model3DPath,
                TestDataPath = model.TestDataPath,
                ScaleImagePath = model.ScaleImagePath,

                Products = productResult.Data?.ToList() ?? new(),

                UsageTypeNames = model.UsageTypeNames?.ToList() ?? new(),
                WorkingConditionNames = model.WorkingConditionNames?.ToList() ?? new(),
                ContentTitle = model.ContentTitle,
                ContentDescription = model.ContentDescription,
                ContentFeatures = model.ContentFeatures?.ToList() ?? new(),

                AirFlow = model.AirFlow,
                AirFlowUnit = model.AirFlowUnit,
                TotalPressure = model.TotalPressure,
                TotalPressureUnit = model.TotalPressureUnit,
                Power = model.Power,
                Voltage = model.Voltage,
                Frequency = model.Frequency,
                SpeedControl = model.SpeedControl,
                Temperature = model.Temperature,

                Documents = model.Documents,

                BodyMaterialStandard = model.BodyMaterialStandard,
                ColdResistanceStandard = model.ColdResistanceStandard,
                ImpellerMaterialStandard = model.ImpellerMaterialStandard,
                HeatResistanceStandard = model.HeatResistanceStandard,
                CarryingBracketStandard = model.CarryingBracketStandard,
                MotorProtectionCapStandard = model.MotorProtectionCapStandard,

                BodyMaterialOptional = model.BodyMaterialOptional,
                ColdResistanceOptional = model.ColdResistanceOptional,
                ImpellerMaterialOptional = model.ImpellerMaterialOptional,
                HeatResistanceOptional = model.HeatResistanceOptional,
                CarryingBracketOptional = model.CarryingBracketOptional,
                MotorProtectionCapOptional = model.MotorProtectionCapOptional,

                // 🔥 DİNAMİK ÖZELLİKLERİ EKLEDİK!
                ModelFeatures = model.ModelFeatures?.ToList() ?? new()
            };


            ViewData["ModelName"] = model.Name;

            return View(viewModel);
        }

    }
}
