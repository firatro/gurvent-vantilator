namespace GurventVantilator.AdminUI.Models.PageImage
{
    public class PageImageCreateViewModel
    {
        public string PageKey { get; set; } = string.Empty;
        public string ImageType { get; set; } = string.Empty;
        public IFormFile? ImageFile { get; set; }
    }
}
