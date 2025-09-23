namespace GurventVantilator.Domain.Entities
{
    public class ServiceFaq
    {
        public int Id { get; set; }
        public string Question { get; set; } = string.Empty; 
        public string Answer { get; set; } = string.Empty;   

        // İlişki
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
