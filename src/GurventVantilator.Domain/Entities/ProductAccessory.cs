namespace GurventVantilator.Domain.Entities
{
    public class ProductAccessory
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public string AccessoryName { get; set; } = string.Empty;
        public string ArticleNumber { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

        public string? ImagePath { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
