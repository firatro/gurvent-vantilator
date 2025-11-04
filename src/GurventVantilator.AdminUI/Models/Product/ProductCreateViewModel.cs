using GurventVantilator.AdminUI.Models.ProductContentFeature;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GurventVantilator.AdminUI.Models.Product
{
    public class ProductCreateViewModel
    {
        // Temel bilgiler
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }

        // Boyut
        public string? Diameter { get; set; }
        public string? DiameterUnit { get; set; } // mm, cm, inch

        // Hava debisi
        public string? AirFlow { get; set; }
        public string? AirFlowUnit { get; set; } // m³/h, m³/s, L/s

        // Basınç
        public string? Pressure { get; set; }
        public string? PressureUnit { get; set; } // Pa, mmH₂O, inH₂O

        // Güç
        public string? Power { get; set; }
        public string? PowerUnit { get; set; } // kW, W, HP

        // Elektriksel
        public string? Voltage { get; set; } // V
        public string? Frequency { get; set; } // Hz

        // Performans
        public string? Speed { get; set; } // rpm
        public string? SpeedUnit { get; set; } // rpm
        public string? NoiseLevel { get; set; } // dB(A)
        public string? NoiseLevelUnit { get; set; } // dB(A)
        public string? SpeedControl { get; set; }

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

        // İlişkiler
        public int ProductCategoryId { get; set; }
        public IEnumerable<SelectListItem>? ProductCategoryList { get; set; }

        public List<int> SelectedApplicationIds { get; set; } = new();
        public IEnumerable<SelectListItem>? ProductApplicationList { get; set; }

        // Ortak alanlar
        public bool IsActive { get; set; } = true;
        public int? Order { get; set; } = 0;

        public string? ContentTitle { get; set; }
        public string? ContentDescription { get; set; }

        // Çoklu özellikler (key-value)
        public List<ProductContentFeatureViewModel> ContentFeatures { get; set; } = new();

    }
}
