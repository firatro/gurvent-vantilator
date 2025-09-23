namespace GurventVantilator.AdminUI.Models.VisionMission
{
    public class VisionMissionEditViewModel
    {
        public int Id { get; set; }
        public string VisionTitle { get; set; } = string.Empty;
        public string VisionDescription { get; set; } = string.Empty;
        public string MissionTitle { get; set; } = string.Empty;
        public string MissionDescription { get; set; } = string.Empty;
        public string? VisionImagePath { get; set; }
        public string? MissionImagePath { get; set; }
        public IFormFile? VisionImageFile { get; set; }
        public IFormFile? MissionImageFile { get; set; }
    }
}

