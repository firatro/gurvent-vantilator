namespace GurventVantilator.Domain.Entities
{
    public class ProductFeature
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<ProductModelFeature> ModelFeatures { get; set; }
            = new List<ProductModelFeature>();
    }
}
