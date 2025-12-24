using Microsoft.AspNetCore.Mvc.Rendering;

namespace GurventVantilator.AdminUI.Models.Product
{
    public class ProductEditViewModel
    {
        // ======================================================
        // 🧱 TEMEL BİLGİLER
        // ======================================================
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }

        // ======================================================
        // 🔹 SERİ VE MODEL
        // ======================================================
        public int? ProductSeriesId { get; set; }
        public IEnumerable<SelectListItem>? ProductSeriesList { get; set; }

        public int? ProductModelId { get; set; }
        public IEnumerable<SelectListItem>? ProductModelList { get; set; }

        // ======================================================
        // 🔹 KULLANIM TİPİ VE ÇALIŞMA KOŞULU
        // ======================================================
        public List<int> SelectedUsageTypeIds { get; set; } = new();
        public IEnumerable<SelectListItem>? UsageTypeList { get; set; }

        public List<int> SelectedWorkingConditionIds { get; set; } = new();
        public IEnumerable<SelectListItem>? WorkingConditionList { get; set; }

        // ======================================================
        // ⚙️ PERFORMANS PARAMETRELERİ
        // ======================================================
        public string? AirFlow { get; set; }
        public string? AirFlowUnit { get; set; }

        public string? TotalPressure { get; set; }
        public string? TotalPressureUnit { get; set; }

        public string? Power { get; set; }
        public string? Voltage { get; set; }
        public string? Frequency { get; set; }

        public string? SpeedControl { get; set; }
        public double? Temperature { get; set; }

        // ======================================================
        // 🖼️ DOSYA ALANLARI (YENİ YÜKLEME)
        // ======================================================
        public IFormFile? Image1File { get; set; }
        public IFormFile? Image2File { get; set; }
        public IFormFile? Image3File { get; set; }
        public IFormFile? Image4File { get; set; }
        public IFormFile? Image5File { get; set; }
        public IFormFile? DataSheetFile { get; set; }
        public IFormFile? Model3DFile { get; set; }
        public IFormFile? TestDataFile { get; set; }
        public IFormFile? ScaleImageFile { get; set; }

        // ======================================================
        // 🗂️ MEVCUT DOSYA YOLLARI
        // ======================================================
        public string? Image1Path { get; set; }
        public string? Image2Path { get; set; }
        public string? Image3Path { get; set; }
        public string? Image4Path { get; set; }
        public string? Image5Path { get; set; }
        public string? DataSheetPath { get; set; }
        public string? Model3DPath { get; set; }
        public string? TestDataPath { get; set; }
        public string? ScaleImagePath { get; set; }

        // ======================================================
        // 🧩 İÇERİK ALANLARI
        // ======================================================
        public string? ContentTitle { get; set; }
        public string? ContentDescription { get; set; }
        public List<ProductContentFeatureViewModel> ContentFeatures { get; set; } = new();

        // ======================================================
        // ⚙️ GENEL ALANLAR
        // ======================================================
        public bool IsActive { get; set; }
        public int? Order { get; set; } = 0;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
