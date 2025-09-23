namespace GurventVantilator.AdminUI.Models.BeforeAfter
{
    public class BeforeAfterCreateViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IFormFile? BeforeImageFile { get; set; }
        public IFormFile? AfterImageFile { get; set; }
    }
}
