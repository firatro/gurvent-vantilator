namespace GurventVantilator.Domain.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string FullName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string EntryTitle { get; set; } = string.Empty;
        public string EntryDescription { get; set; } = string.Empty;
        public string? ExtraTitle { get; set; }
        public string? ExtraDescription { get; set; }
        public string? Quote { get; set; }
        public string? QuoteSource { get; set; }
        public string MainImagePath { get; set; } = string.Empty;
        public string ContentImage1Path { get; set; } = string.Empty;
        public string ContentImage2Path { get; set; } = string.Empty;
        public string? YoutubeVideoUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<BlogTag> BlogTags { get; set; } = new List<BlogTag>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}