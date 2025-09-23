namespace GurventVantilator.AdminUI.Models.Blog
{
    public class BlogCreateViewModel
    {
        public string FullName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string? Subtitle { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? EntryTitle { get; set; }
        public string? EntryDescription { get; set; }
        public string? ExtraTitle { get; set; }
        public string? ExtraDescription { get; set; }
        public string? Quote { get; set; }
        public string? QuoteSource { get; set; }
        public string? YoutubeVideoUrl { get; set; }
        public int CategoryId { get; set; }

        // Upload alanları
        public IFormFile? MainImageFile { get; set; }
        public IFormFile? ContentImage1File { get; set; }
        public IFormFile? ContentImage2File { get; set; }

        // Tag seçimi
        public List<int> TagIds { get; set; } = new();
    }
}
