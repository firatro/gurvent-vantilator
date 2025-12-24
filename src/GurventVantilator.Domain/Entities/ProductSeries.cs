namespace GurventVantilator.Domain.Entities
{
    public class ProductSeries
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<ProductModel> Models { get; set; } = new List<ProductModel>();
    }
}
