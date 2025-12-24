namespace GurventVantilator.Application.DTOs
{
    public class ProductModelFeatureDto
    {
        public int Id { get; set; }
        public int ProductModelId { get; set; }
        public string FeatureName { get; set; } = string.Empty;
        public string? StandardValue { get; set; }
        public string? OptionalValue { get; set; }
        public int Order { get; set; }
    }
}
