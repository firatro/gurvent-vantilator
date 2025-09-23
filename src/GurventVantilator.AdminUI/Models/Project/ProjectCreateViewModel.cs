namespace GurventVantilator.AdminUI.Models.Project
{
    public class ProjectCreateViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string? Subtitle { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? IntroText { get; set; }
        public string? Description { get; set; }
        public DateTime ProjectDate { get; set; }
        public string? CustomerInfo { get; set; }
        public string? ExtraTitle { get; set; }
        public string? ExtraDescription { get; set; }
        public IFormFile? MainImageFile { get; set; }
        public IFormFile? ContentImage1File { get; set; }
        public IFormFile? ContentImage2File { get; set; }
    }
}
