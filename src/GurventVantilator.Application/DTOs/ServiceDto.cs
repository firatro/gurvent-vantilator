namespace GurventVantilator.Application.DTOs
{
    public class ServiceDto
    {
        public int Id { get; set; }
        public string? MainImagePath { get; set; }
        public string? ContentImage1Path { get; set; }
        public string? ContentImage2Path { get; set; }
        public string? LogoPath { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ExtraTitle { get; set; }
        public string? ExtraDescription { get; set; }

        public List<ServiceFeatureDto> Features { get; set; } = new();
        public List<ServiceFaqDto> Faqs { get; set; } = new();
    }
}
