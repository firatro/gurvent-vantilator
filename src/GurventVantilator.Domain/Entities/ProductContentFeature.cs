namespace GurventVantilator.Domain.Entities
{
    public class ProductContentFeature
    {
        public int Id { get; set; }

        // --- Product bağlantısı ---
        public int? ProductId { get; set; }
        public Product? Product { get; set; }

        // --- Model bağlantısı ---
        public int? ProductModelId { get; set; }
        public ProductModel? ProductModel { get; set; }

        // --- Feature info ---
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public int? Order { get; set; }
    }
}
