namespace GurventVantilator.Domain.Entities
{
    public class ProductWorkingCondition
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;
        public int? Order { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<ProductModel> ProductModels { get; set; } = new List<ProductModel>();
    }

}
