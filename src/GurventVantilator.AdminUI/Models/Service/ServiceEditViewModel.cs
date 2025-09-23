namespace GurventVantilator.AdminUI.Models.Service
{
    public class ServiceEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ExtraTitle { get; set; }
        public string? ExtraDescription { get; set; }

        // Mevcut görsel path'leri
        public string? MainImagePath { get; set; }
        public string? ContentImage1Path { get; set; }
        public string? ContentImage2Path { get; set; }
        public string? LogoPath { get; set; }

        // Yeni yüklenebilecek görseller
        public IFormFile? MainImageFile { get; set; }
        public IFormFile? ContentImage1File { get; set; }
        public IFormFile? ContentImage2File { get; set; }
        public IFormFile? LogoFile { get; set; }
    }
}
