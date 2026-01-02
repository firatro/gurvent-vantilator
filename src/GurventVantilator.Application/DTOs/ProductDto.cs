namespace GurventVantilator.Application.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int? ProductModelId { get; set; }
        public string? ProductModelName { get; set; }
        public string? ProductModelCode { get; set; }
        public int? ProductSeriesId { get; set; }
        public string? ProductSeriesName { get; set; }
        public List<int> UsageTypeIds { get; set; } = new();
        public List<string>? UsageTypeNames { get; set; }
        public List<int> WorkingConditionIds { get; set; } = new();
        public List<string>? WorkingConditionNames { get; set; }
        public string? ContentTitle { get; set; }
        public string? ContentDescription { get; set; }
        public List<ProductContentFeatureDto> ContentFeatures { get; set; } = new();
        public double? AirFlow { get; set; }
        public string? AirFlowUnit { get; set; }
        public double? TotalPressure { get; set; }
        public string? TotalPressureUnit { get; set; }
        public string? Power { get; set; }
        public string? Voltage { get; set; }
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
        public string? ProductTestName { get; set; } // ✅ YENİ
        public string? ScaleImagePath { get; set; }
        public bool IsActive { get; set; }
        public int? Order { get; set; } = 0;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public List<ProductAccessoryDto> Accessories { get; set; }
    = new();


    }
}
