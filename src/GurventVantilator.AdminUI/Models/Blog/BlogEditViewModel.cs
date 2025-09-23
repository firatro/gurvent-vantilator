namespace GurventVantilator.AdminUI.Models.Blog
{
    public class BlogEditViewModel
    {
        public int Id { get; set; }

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

        // Mevcut görsel path'leri
        public string? MainImagePath { get; set; }
        public string? ContentImage1Path { get; set; }
        public string? ContentImage2Path { get; set; }

        // Yeni yüklenebilecek görseller
        public IFormFile? MainImageFile { get; set; }
        public IFormFile? ContentImage1File { get; set; }
        public IFormFile? ContentImage2File { get; set; }

        // Etiket seçimi
        public List<int> TagIds { get; set; } = new();
    }
}
