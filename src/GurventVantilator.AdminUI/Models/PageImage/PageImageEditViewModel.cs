namespace GurventVantilator.AdminUI.Models.PageImage
{
    public class PageImageEditViewModel
    {
        public int Id { get; set; }
        public string PageKey { get; set; } = string.Empty;
        public string ImageType { get; set; } = string.Empty;
        public string? ImagePath { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}