using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GurventVantilator.AdminUI.Models.ProductCategory
{
    public class ProductCategoryEditViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string? ImagePath { get; set; }
        public bool IsActive { get; set; }
        public int? Order { get; set; }

        // 🔹 Yeni alan
        public int? ParentCategoryId { get; set; }
        public IEnumerable<SelectListItem>? ParentCategoryList { get; set; }
    }
}
