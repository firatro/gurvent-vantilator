namespace GurventVantilator.AdminUI.Models.Slider
{
    public class SliderEditViewModel
    {
        public int Id { get; set; }
        public string Tag { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
        public string? ImagePath { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}