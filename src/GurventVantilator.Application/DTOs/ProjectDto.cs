namespace GurventVantilator.Application.DTOs
{
    public class ProjectDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string? Subtitle { get; set; }

        public string? MainImagePath { get; set; }
        public string? ContentImage1Path { get; set; }
        public string? ContentImage2Path { get; set; }
        public DateTime CreatedAt { get; set; }

        public string? IntroText { get; set; }
        public string? Description { get; set; }

        public DateTime ProjectDate { get; set; }
        public string? CustomerInfo { get; set; }

        public string? ExtraTitle { get; set; }
        public string? ExtraDescription { get; set; }

        // İlişkiler
        public List<ProjectFeatureDto> Features { get; set; } = new();
    }
}
