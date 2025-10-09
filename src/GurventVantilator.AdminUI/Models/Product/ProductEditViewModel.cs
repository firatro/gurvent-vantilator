namespace GurventVantilator.AdminUI.Models.Product
{
    public class ProductEditViewModel
    {
        public int Id { get; set; }

        // Aynı alanlar + mevcut dosya yolları
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }

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

        // Yeni yüklenecek dosyalar
        public IFormFile? ImageFile { get; set; }
        public IFormFile? DataSheetFile { get; set; }
        public IFormFile? Model3DFile { get; set; }

        // Mevcut dosya yolları
        public string? ImagePath { get; set; }
        public string? DataSheetPath { get; set; }
        public string? Model3DPath { get; set; }

        public int ProductCategoryId { get; set; }

        public bool IsActive { get; set; }
        public int? Order { get; set; } = 0;
    }
}
