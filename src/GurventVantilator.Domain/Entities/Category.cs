namespace GurventVantilator.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Blog> Blogs { get; set; } = new List<Blog>();
    }
}
