namespace GurventVantilator.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }

        // Temel bilgiler
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }

        // Yeni içerik alanları
        public string? ContentTitle { get; set; }
        public string? ContentDescription { get; set; }

        // Boyut
        public double? Diameter { get; set; }
        public string? DiameterUnit { get; set; } // "mm", "cm"

        // Hava debisi
        public double? AirFlow { get; set; }
        public string? AirFlowUnit { get; set; } // "m³/h", "m³/s", "L/s"

        // Basınç
        public double? Pressure { get; set; }
        public string? PressureUnit { get; set; } // "Pa", "N/m²"

        // Elektriksel
        public double? Power { get; set; } // "kW"
        public string? PowerUnit { get; set; }
        public double? Voltage { get; set; } // "V"
        public double? Frequency { get; set; } // "Hz"

        // Performans
        public double? Speed { get; set; } // "rpm"
        public string? SpeedUnit { get; set; }
        public double? NoiseLevel { get; set; } // "dB(A)"
        public string? NoiseLevelUnit { get; set; }
        public string? SpeedControl { get; set; }

        // Dosyalar
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
        public ProductCategory ProductCategory { get; set; } = null!;
        public ICollection<ProductApplication> Applications { get; set; } = new List<ProductApplication>();
        public ICollection<ProductTestData> TestData { get; set; } = new List<ProductTestData>();
        public ICollection<ProductContentFeature> ContentFeatures { get; set; } = new List<ProductContentFeature>();


        // Ortak alanlar
        public bool IsActive { get; set; } = true;
        public int? Order { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
