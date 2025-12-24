using Microsoft.AspNetCore.Http;

namespace GurventVantilator.Application.DTOs
{
    public class ProductSeriesDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        // Seri altında bulunan modeller
        public List<ProductModelDto>? Models { get; set; }

        // Ortak alanlar
        public bool IsActive { get; set; }
        public int? Order { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public string? ImagePath { get; set; }  // Resmin kaydedilen yolu
        public IFormFile? ImageFile { get; set; } // Upload edilecek dosya
    }
}
