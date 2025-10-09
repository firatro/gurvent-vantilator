namespace GurventVantilator.Application.DTOs
{
    public class ProductCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImagePath { get; set; }

        public bool IsActive { get; set; }
        public int Order { get; set; } = 0;

        // 🔹 Hiyerarşi yapısı
        public int? ParentCategoryId { get; set; }                     // Üst kategori
        public string? ParentCategoryName { get; set; }                // (isteğe bağlı) üst kategori adı

        // 🔹 Alt kategoriler (listeleme için)
        public List<ProductCategoryDto> SubCategories { get; set; } = new List<ProductCategoryDto>();

        // 🔹 Ürün sayısı (liste veya dashboard için)
        public int ProductCount { get; set; }
    }
}
