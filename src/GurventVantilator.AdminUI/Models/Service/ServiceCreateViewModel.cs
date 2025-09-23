namespace GurventVantilator.AdminUI.Models.Service
{
    public class ServiceCreateViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ExtraTitle { get; set; }
        public string? ExtraDescription { get; set; }

        // Upload alanları
        public IFormFile? MainImageFile { get; set; }
        public IFormFile? ContentImage1File { get; set; }
        public IFormFile? ContentImage2File { get; set; }
        public IFormFile? LogoFile { get; set; }
    }
}
