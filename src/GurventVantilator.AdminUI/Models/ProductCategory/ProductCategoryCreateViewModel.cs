using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GurventVantilator.AdminUI.Models.ProductCategory
{
    public class ProductCategoryCreateViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public IFormFile? ImageFile { get; set; }
        public bool IsActive { get; set; } = true;
        public int? Order { get; set; } = 0;

        // 🔹 Yeni alan
        public int? ParentCategoryId { get; set; }
        public IEnumerable<SelectListItem>? ParentCategoryList { get; set; }
    }
}
