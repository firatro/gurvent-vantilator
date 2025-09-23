namespace GurventVantilator.Application.DTOs
{
    public class ProjectFeatureDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int ProjectId { get; set; }
        public string? ProjectTitle { get; set; }
    }
}
