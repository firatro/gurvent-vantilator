namespace GurventVantilator.Domain.Entities
{
    public class ProductApplication
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
