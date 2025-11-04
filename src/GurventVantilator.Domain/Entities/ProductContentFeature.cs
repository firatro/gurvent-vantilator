namespace GurventVantilator.Domain.Entities
{
    public class ProductContentFeature
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        // Key-Value mantığı
        public string Key { get; set; } = string.Empty;   // Örn: “Fan Tipi”
        public string Value { get; set; } = string.Empty; // Örn: “Aksiyal Fan”

        public int? Order { get; set; } = 0;
    }
}
