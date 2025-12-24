namespace GurventVantilator.Domain.Entities
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int ProductSeriesId { get; set; }
        public ProductSeries ProductSeries { get; set; } = null!;
        public ICollection<ProductUsageType> UsageTypes { get; set; } = new List<ProductUsageType>();
        public ICollection<ProductWorkingCondition> WorkingConditions { get; set; } = new List<ProductWorkingCondition>();
        public string? ContentTitle { get; set; }
        public string? ContentDescription { get; set; }
        public List<ProductContentFeature> ContentFeatures { get; set; } = new();
        public double? AirFlow { get; set; }
        public string? AirFlowUnit { get; set; }
        public double? TotalPressure { get; set; }
        public string? TotalPressureUnit { get; set; }
        public string? Power { get; set; }
        public double? Voltage { get; set; }
        public double? Frequency { get; set; }
        public string? SpeedControl { get; set; }
        public double? Temperature { get; set; }
        public string? Image1Path { get; set; }
        public string? Image2Path { get; set; }
        public string? Image3Path { get; set; }
        public string? Image4Path { get; set; }
        public string? Image5Path { get; set; }
        public string? DataSheetPath { get; set; }
        public string? Model3DPath { get; set; }
        public string? TestDataPath { get; set; }
        public string? ScaleImagePath { get; set; }
        public ICollection<ProductTestData> TestData { get; set; } = new List<ProductTestData>();
        public bool IsActive { get; set; } = true;
        public int? Order { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<ProductModelDocument> Documents { get; set; }

        // 📌 SABİT MODEL ÖZELLİKLERİ
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
        public ICollection<ProductModelFeature> ModelFeatures { get; set; } = new List<ProductModelFeature>();



    }
}
