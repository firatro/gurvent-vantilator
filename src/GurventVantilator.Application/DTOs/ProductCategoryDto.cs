namespace GurventVantilator.Application.DTOs
{
    public class ProductCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImagePath { get; set; }

        public bool IsActive { get; set; }
        public int Order { get; set; }

        // İsteğe bağlı: Ürün sayısı
        public int ProductCount { get; set; }
    }
}
