namespace GurventVantilator.AdminUI.Models.TeamMember
{
    public class TeamMemberCreateViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public string Facebook { get; set; } = string.Empty;
        public string Twitter { get; set; } = string.Empty;
        public string Youtube { get; set; } = string.Empty;
        public string Linkedin { get; set; } = string.Empty;
        public string Instagram { get; set; } = string.Empty;
        public string Experience { get; set; } = string.Empty;
        public string Skills { get; set; } = string.Empty;
        public IFormFile? ImageFile { get; set; } 
    }
}
