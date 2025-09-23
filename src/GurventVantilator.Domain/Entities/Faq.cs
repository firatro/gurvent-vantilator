namespace GurventVantilator.Domain.Entities
{
    public class Faq
    {
        public int Id { get; set; } 
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;  
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
