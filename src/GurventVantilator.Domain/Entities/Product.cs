namespace GurventVantilator.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }

        // Temel bilgiler
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }

        // Teknik özellikler
        public string? Diameter { get; set; }
        public string? AirFlowMin { get; set; }
        public string? AirFlowMax { get; set; }
        public string? PressureMin { get; set; }
        public string? PressureMax { get; set; }
        public string? Power { get; set; }
        public string? Voltage { get; set; }
        public string? Frequency { get; set; }
        public string? Speed { get; set; }
        public string? NoiseLevel { get; set; }

        // Dosyalar ve görseller
        public string? ImagePath { get; set; }
        public string? DataSheetPath { get; set; }
        public string? Model3DPath { get; set; }

        // İlişkiler
        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; } = null!;

        // Diğer
        public bool IsActive { get; set; } = true;
        public int? Order { get; set; } = 0;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
