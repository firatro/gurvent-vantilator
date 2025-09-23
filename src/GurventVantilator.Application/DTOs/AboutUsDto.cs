namespace GurventVantilator.Application.DTOs
{
    public class AboutUsDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string ExtraTitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ExtraDescription { get; set; } = string.Empty;
        public string? YoutubeVideoUrl { get; set; }
        public string? ImagePath { get; set; }

        public int ExperienceYear { get; set; }
        public int HappyClients { get; set; }
        public int CompletedProjects { get; set; }
        public int Awards { get; set; }

    }
}
