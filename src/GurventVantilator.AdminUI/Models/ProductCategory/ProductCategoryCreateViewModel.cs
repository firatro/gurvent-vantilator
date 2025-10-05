using Microsoft.AspNetCore.Http;

namespace GurventVantilator.AdminUI.Models.ProductCategory
{
    public class ProductCategoryCreateViewModel
    {
        // 🔹 Temel Bilgiler
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        // 🔹 Görsel
        public IFormFile? ImageFile { get; set; }    

        // 🔹 Diğer
        public bool IsActive { get; set; } = true;
        public int Order { get; set; } = 0;
    }
}
