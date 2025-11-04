using GurventVantilator.AdminUI.Models.ProductContentFeature;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GurventVantilator.AdminUI.Models.Product
{
    public class ProductEditViewModel
    {
        // Temel bilgiler
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }

        // Boyut
        public string? Diameter { get; set; }
        public string? DiameterUnit { get; set; }

        // Hava debisi
        public string? AirFlow { get; set; }
        public string? AirFlowUnit { get; set; }

        // Basınç
        public string? Pressure { get; set; }
        public string? PressureUnit { get; set; }

        // Güç
        public string? Power { get; set; }
        public string? PowerUnit { get; set; }

        // Elektriksel
        public string? Voltage { get; set; }
        public string? Frequency { get; set; }

        // Performans
        public string? Speed { get; set; }
        public string? SpeedUnit { get; set; }
        public string? NoiseLevel { get; set; }
        public string? NoiseLevelUnit { get; set; }
        public string? SpeedControl { get; set; } = "No Regulation";

        // Dosyalar
        public IFormFile? Image1File { get; set; }
        public IFormFile? Image2File { get; set; }
        public IFormFile? Image3File { get; set; }
        public IFormFile? Image4File { get; set; }
        public IFormFile? Image5File { get; set; }
        public IFormFile? DataSheetFile { get; set; }
        public IFormFile? Model3DFile { get; set; }
        public IFormFile? TestDataFile { get; set; }
        public IFormFile? ScaleImageFile { get; set; }

        public string? Image1Path { get; set; }
        public string? Image2Path { get; set; }
        public string? Image3Path { get; set; }
        public string? Image4Path { get; set; }
        public string? Image5Path { get; set; }
        public string? DataSheetPath { get; set; }
        public string? Model3DPath { get; set; }
        public string? TestDataPath { get; set; }
        public string? ScaleImagePath { get; set; }

        // İlişkiler
        public int ProductCategoryId { get; set; }
        public IEnumerable<SelectListItem>? ProductCategoryList { get; set; }

        public List<int> SelectedApplicationIds { get; set; } = new();
        public IEnumerable<SelectListItem>? ProductApplicationList { get; set; }

        // Ortak alanlar
        public bool IsActive { get; set; }
        public int? Order { get; set; } = 0;
        public string? ContentTitle { get; set; }
        public string? ContentDescription { get; set; }

        // Çoklu özellikler (key-value)
        public List<ProductContentFeatureViewModel> ContentFeatures { get; set; } = new();
    }
}
