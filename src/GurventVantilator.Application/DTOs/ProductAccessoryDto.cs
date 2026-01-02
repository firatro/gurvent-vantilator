namespace GurventVantilator.Application.DTOs
{
    public class ProductAccessoryDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public string AccessoryName { get; set; } = string.Empty;
        public string ArticleNumber { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

        public string? ImagePath { get; set; }
    }

}
