namespace GurventVantilator.Domain.Entities
{
    public class VersionInfo
    {
        public int Id { get; set; }
        public string VersionNumber { get; set; }  = null!;  
        public string Title { get; set; } = null!;  
        public string Description { get; set; } = null!;  
        public DateTime ReleaseDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = false;              
    }
}
