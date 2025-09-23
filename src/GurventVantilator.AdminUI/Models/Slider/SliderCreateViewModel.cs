namespace GurventVantilator.AdminUI.Models.Slider
{
    public class SliderCreateViewModel
    {
        public string Tag { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
        public IFormFile? ImageFile { get; set; }
    }
}
