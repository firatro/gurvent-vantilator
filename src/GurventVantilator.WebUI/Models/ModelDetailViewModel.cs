using GurventVantilator.Application.DTOs;

namespace GurventVantilator.WebUI.Models
{
    public class ModelDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Code { get; set; }
        public string? Description { get; set; }

        // Görseller
        public string? Image1Path { get; set; }
        public string? Image2Path { get; set; }
        public string? Image3Path { get; set; }
        public string? Image4Path { get; set; }
        public string? Image5Path { get; set; }

        // Dosyalar
        public string? DataSheetPath { get; set; }
        public string? Model3DPath { get; set; }
        public string? TestDataPath { get; set; }
        public string? ScaleImagePath { get; set; }

        public List<string> UsageTypeNames { get; set; }
        public List<string> WorkingConditionNames { get; set; }

        public string? ContentTitle { get; set; }
        public string? ContentDescription { get; set; }
        public List<ProductContentFeatureDto> ContentFeatures { get; set; } = new();

        // Ürünler
        public List<ProductDto> Products { get; set; } = new();

        public double? AirFlow { get; set; }
        public string? AirFlowUnit { get; set; }
        public double? TotalPressure { get; set; }
        public string? TotalPressureUnit { get; set; }
        public string? Power { get; set; }
        public double? Voltage { get; set; }
        public double? Frequency { get; set; }
        public string? SpeedControl { get; set; }
        public double? Temperature { get; set; }
        public List<ProductModelDocumentDto> Documents { get; set; }

        public string? BodyMaterialStandard { get; set; }
        public string? BodyMaterialOptional { get; set; }

        public string? ImpellerMaterialStandard { get; set; }
        public string? ImpellerMaterialOptional { get; set; }

        public string? CarryingBracketStandard { get; set; }
        public string? CarryingBracketOptional { get; set; }

        public string? HeatResistanceStandard { get; set; }
        public string? HeatResistanceOptional { get; set; }

        public string? ColdResistanceStandard { get; set; }
        public string? ColdResistanceOptional { get; set; }

        public string? MotorProtectionCapStandard { get; set; }
        public string? MotorProtectionCapOptional { get; set; }
        public List<ProductModelFeatureDto> ModelFeatures { get; set; } = new();


    }
}
