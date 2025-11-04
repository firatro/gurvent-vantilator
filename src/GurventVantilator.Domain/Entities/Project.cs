namespace GurventVantilator.Domain.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }             
        public string? Subtitle { get; set; }         
        public string? MainImagePath { get; set; }    
        public string? IntroText { get; set; }        
        public string Description { get; set; }       
        public DateTime ProjectDate { get; set; }     
        public string? CustomerInfo { get; set; }     
        public string? ContentImage1Path { get; set; }
        public string? ContentImage2Path { get; set; }
        public string? ExtraTitle { get; set; }       
        public string? ExtraDescription { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<ProjectFeature> Features { get; set; } = new List<ProjectFeature>();
    }
}
