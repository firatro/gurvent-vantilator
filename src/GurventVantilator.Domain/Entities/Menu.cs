namespace GurventVantilator.Domain.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public MenuLinkType LinkType { get; set; }
        public string? ContentHtml { get; set; }
        public int? ServiceId { get; set; }
        public int? ProjectId { get; set; }
        public int? BlogId { get; set; }
        public int? ProductId { get; set; }
        public int? ProductCategoryId { get; set; }
        public string Url { get; set; } = string.Empty;
        public int? ParentId { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; } = true;
        public Menu? Parent { get; set; }
        public ICollection<Menu> Children { get; set; } = new List<Menu>();
    }

    public enum MenuLinkType
    {
        CustomPage = 0,
        Service = 1,
        Project = 2,
        Blog = 3,
        Contact = 4,
        AboutUs = 5,
        HomePage = 6,
        Product = 7,
        ProductCategory = 8
    }
}
