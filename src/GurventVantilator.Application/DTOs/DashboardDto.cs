using GurventVantilator.Application.DTOs;

public class DashboardDto
{
    public int TotalContacts { get; set; }
    public int TotalBlogs { get; set; }
    public int TotalServices { get; set; }
    public int TotalChatBotQnAs { get; set; }
    public int TotalTeamMembers { get; set; }
    public int TotalBeforeAfter { get; set; }

    public List<ContactDto> LatestContacts { get; set; } = new();
    public List<BlogDto> LatestBlogs { get; set; } = new();
    public List<TeamMemberDto> LatestTeamMembers { get; set; } = new();
    public List<ServiceDto> LatestServices { get; set; } = new();
}
