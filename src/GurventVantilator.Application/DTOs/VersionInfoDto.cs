namespace GurventVantilator.Application.DTOs
{
    public class VersionInfoDto
    {
        public int Id { get; set; }
        public string VersionNumber { get; set; } = null!;
        public string Title { get; set; }= null!;
        public string Description { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        public bool IsActive { get; set; }
    }
}
