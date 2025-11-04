namespace GurventVantilator.Domain.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string? MainImagePath { get; set; }         
        public string? ContentImage1Path { get; set; }     
        public string? ContentImage2Path { get; set; }     
        public string? LogoPath { get; set; }     
        public string Name { get; set; } = string.Empty;   
        public string Title { get; set; } = string.Empty;  
        public string? Description { get; set; }           
        public string? ExtraTitle { get; set; }          
        public string? ExtraDescription { get; set; }    
        public ICollection<ServiceFeature> Features { get; set; } = new List<ServiceFeature>();
        public ICollection<ServiceFaq> Faqs { get; set; } = new List<ServiceFaq>();
    }
}
