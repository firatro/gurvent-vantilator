namespace GurventVantilator.Domain.Entities
{
    public class ProductCategory
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;     
        public string? Description { get; set; }             
        public string? ImagePath { get; set; }               
        public bool IsActive { get; set; } = true;           
        public int Order { get; set; }                       

        // Navigation Property
        public ICollection<Product> Products { get; set; } = new List<Product>();

        // Base columns
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
