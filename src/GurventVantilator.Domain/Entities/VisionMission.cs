namespace GurventVantilator.Domain.Entities
{
    public class VisionMission
    {
        public int Id { get; set; }
        public string VisionTitle { get; set; } = string.Empty;
        public string VisionDescription { get; set; } = string.Empty;
        public string MissionTitle { get; set; } = string.Empty;
        public string MissionDescription { get; set; } = string.Empty;
        public string? VisionImagePath { get; set; }
        public string? MissionImagePath { get; set; }
    }
}
