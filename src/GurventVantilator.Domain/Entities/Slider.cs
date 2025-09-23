namespace GurventVantilator.Domain.Entities
{
    public class Slider
    {
        public int Id { get; set; }
        public string Tag { get; set; } = string.Empty;    
        public string ImagePath { get; set; } = string.Empty; 
        public string Title { get; set; } = string.Empty;  
        public string Subtitle { get; set; } = string.Empty;
    }
}
