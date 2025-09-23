namespace GurventVantilator.AdminUI.Models.BeforeAfter
{
    public class BeforeAfterEditViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? BeforeImagePath { get; set; }
        public string? AfterImagePath { get; set; }
        public IFormFile? BeforeImageFile { get; set; }
        public IFormFile? AfterImageFile { get; set; }
    }
}

