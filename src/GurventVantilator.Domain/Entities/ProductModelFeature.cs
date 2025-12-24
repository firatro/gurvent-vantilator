namespace GurventVantilator.Domain.Entities
{
    public class ProductModelFeature
    {
        public int Id { get; set; }

        public int ProductModelId { get; set; }
        public ProductModel ProductModel { get; set; } = null!;

        public string FeatureName { get; set; } = string.Empty;
        public string? StandardValue { get; set; }
        public string? OptionalValue { get; set; }

        public int Order { get; set; } = 0;
    }
}
