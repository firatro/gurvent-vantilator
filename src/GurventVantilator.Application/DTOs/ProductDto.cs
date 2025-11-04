namespace GurventVantilator.Application.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }

        // Temel bilgiler
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }

        // Boyut
        public double? Diameter { get; set; }
        public string? DiameterUnit { get; set; } // "mm", "cm", "inch"

        // Hava debisi
        public double? AirFlow { get; set; }
        public string? AirFlowUnit { get; set; } // "m³/h", "m³/s", "L/s"

        // Basınç
        public double? Pressure { get; set; }
        public string? PressureUnit { get; set; } // "Pa", "mmH₂O"

        // Güç
        public double? Power { get; set; }
        public string? PowerUnit { get; set; } // "kW", "W", "HP"

        // Elektriksel değerler
        public double? Voltage { get; set; } // "V"
        public double? Frequency { get; set; } // "Hz"

        // Performans
        public double? Speed { get; set; } // "rpm"
        public string? SpeedUnit { get; set; }
        public double? NoiseLevel { get; set; } // "dB(A)"
        public string? NoiseLevelUnit { get; set; } // "dB(A)"
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
        public string? ProductCategoryName { get; set; }

        public List<int> SelectedApplicationIds { get; set; } = new();
        public List<ProductApplicationDto>? Applications { get; set; }

        // Ortak alanlar
        public bool IsActive { get; set; }
        public int? Order { get; set; } = 0;


        public string? ContentTitle { get; set; }
        public string? ContentDescription { get; set; }
        public List<ProductContentFeatureDto> ContentFeatures { get; set; } = new();

    }
}
