namespace GurventVantilator.Application.DTOs
{
    public class ProductWorkingConditionDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        // Bu koşula bağlı ürün sayısı
        public int ProductCount { get; set; }

        // Ortak alanlar
        public bool IsActive { get; set; } = true;
        public int? Order { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
