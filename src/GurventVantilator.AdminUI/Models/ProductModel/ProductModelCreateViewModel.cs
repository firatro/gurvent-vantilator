using GurventVantilator.Application.DTOs;

namespace GurventVantilator.AdminUI.Models.ProductModel
{
    public class ProductModelCreateViewModel
    {
        public int Id { get; set; }
        // Temel
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }

        // Seri
        public int ProductSeriesId { get; set; }

        // Usage Types
        public List<int> SelectedUsageTypeIds { get; set; } = new();

        // Working Conditions
        public List<int> SelectedWorkingConditionIds { get; set; } = new();

        // Performans
        public double? AirFlow { get; set; }
        public string? AirFlowUnit { get; set; }
        public double? TotalPressure { get; set; }
        public string? TotalPressureUnit { get; set; }
        public string? Power { get; set; }
        public double? Voltage { get; set; }
        public double? Frequency { get; set; }
        public string? SpeedControl { get; set; }
        public double? Temperature { get; set; }

        // İçerik
        public string? ContentTitle { get; set; }
        public string? ContentDescription { get; set; }

        public List<ProductContentFeatureDto> ContentFeatures { get; set; } = new();

        // ✔ Dosya yolları (Mapping için gerekli)
        public string? Image1Path { get; set; }
        public string? Image2Path { get; set; }
        public string? Image3Path { get; set; }
        public string? Image4Path { get; set; }
        public string? Image5Path { get; set; }

        public string? DataSheetPath { get; set; }
        public string? Model3DPath { get; set; }
        public string? TestDataPath { get; set; }
        public string? ScaleImagePath { get; set; }

        // ✔ Yüklenen yeni dosyalar
        public IFormFile? Image1File { get; set; }
        public IFormFile? Image2File { get; set; }
        public IFormFile? Image3File { get; set; }
        public IFormFile? Image4File { get; set; }
        public IFormFile? Image5File { get; set; }

        public IFormFile? DataSheetFile { get; set; }
        public IFormFile? Model3DFile { get; set; }
        public IFormFile? TestDataFile { get; set; }
        public IFormFile? ScaleImageFile { get; set; }

        // Genel
        public int? Order { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public List<IFormFile>? DocumentFiles { get; set; }
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
        public List<ProductModelFeatureViewModel> ModelFeatures { get; set; } = new();

    }
}
