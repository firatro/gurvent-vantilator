using Microsoft.AspNetCore.Http;

namespace GurventVantilator.AdminUI.Models.ProductCategory
{
    public class ProductCategoryEditViewModel
    {
        public int Id { get; set; }

        // 🔹 Temel Bilgiler
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        // 🔹 Görsel
        public IFormFile? ImageFile { get; set; }     
        public string? ImagePath { get; set; }        

        // 🔹 Diğer
        public bool IsActive { get; set; }
        public int Order { get; set; }
    }
}
