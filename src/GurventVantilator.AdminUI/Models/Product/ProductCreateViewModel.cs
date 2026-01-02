using Microsoft.AspNetCore.Mvc.Rendering;

namespace GurventVantilator.AdminUI.Models.Product
{
    public class ProductCreateViewModel
    {
        // Temel
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }

        // Seri & Model
        public int? ProductModelId { get; set; }
        public IEnumerable<SelectListItem>? ProductModelList { get; set; }

        public int? ProductSeriesId { get; set; }
        public IEnumerable<SelectListItem>? ProductSeriesList { get; set; }

        // Kullanım Tipi & Çalışma Koşulu
        public List<int> SelectedUsageTypeIds { get; set; } = new();
        public IEnumerable<SelectListItem>? UsageTypeList { get; set; }

        public List<int> SelectedWorkingConditionIds { get; set; } = new();
        public IEnumerable<SelectListItem>? WorkingConditionList { get; set; }

        // İçerik Alanları
        public string? ContentTitle { get; set; }
        public string? ContentDescription { get; set; }
        public List<ProductContentFeatureViewModel> ContentFeatures { get; set; } = new();

        // Performans
        public double? AirFlow { get; set; }
        public string? AirFlowUnit { get; set; }

        public double? TotalPressure { get; set; }
        public string? TotalPressureUnit { get; set; }

        public string? Power { get; set; }
        public string? Voltage { get; set; }
        public double? Frequency { get; set; }
        public string? SpeedControl { get; set; }
        public double? Temperature { get; set; }

        // Dosya Alanları (Upload)
        public IFormFile? Image1File { get; set; }
        public IFormFile? Image2File { get; set; }
        public IFormFile? Image3File { get; set; }
        public IFormFile? Image4File { get; set; }
        public IFormFile? Image5File { get; set; }
        public IFormFile? DataSheetFile { get; set; }
        public IFormFile? Model3DFile { get; set; }
        public IFormFile? TestDataFile { get; set; }
        public IFormFile? ScaleImageFile { get; set; }

        // Kaydedilmiş Dosya Yolları (Edit için)
        public string? Image1Path { get; set; }
        public string? Image2Path { get; set; }
        public string? Image3Path { get; set; }
        public string? Image4Path { get; set; }
        public string? Image5Path { get; set; }
        public string? DataSheetPath { get; set; }
        public string? Model3DPath { get; set; }
        public string? TestDataPath { get; set; }
        public string? ScaleImagePath { get; set; }

        // Ortak
        public bool IsActive { get; set; } = true;
        public int? Order { get; set; } = 0;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
