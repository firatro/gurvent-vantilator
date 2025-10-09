using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GurventVantilator.AdminUI.Models.Product
{
    public class ProductCreateViewModel
    {
        // 🔹 Temel Bilgiler
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }

        // 🔹 Teknik Özellikler
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

        // 🔹 Dosyalar (IFormFile tipinde)
        public IFormFile? ImageFile { get; set; }
        public IFormFile? DataSheetFile { get; set; }
        public IFormFile? Model3DFile { get; set; }

        // 🔹 İlişkiler
        public int ProductCategoryId { get; set; }
        public IEnumerable<SelectListItem>? ProductCategoryList { get; set; }

        // 🔹 Diğer
        public bool IsActive { get; set; } = true;
        public int? Order { get; set; } = 0;
    }
}
