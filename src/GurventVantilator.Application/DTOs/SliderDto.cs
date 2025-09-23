namespace GurventVantilator.Application.DTOs
{
    public class SliderDto
    {
        public int Id { get; set; }
        public string Tag { get; set; } = string.Empty;
        public string? ImagePath { get; set; } = null!;
        public string Title { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
    }
}
