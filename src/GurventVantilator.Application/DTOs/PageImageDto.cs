namespace GurventVantilator.Application.DTOs
{
    public class PageImageDto
    {
        public int Id { get; set; }
        public string PageKey { get; set; } = string.Empty;
        public string ImageType { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
    }
}