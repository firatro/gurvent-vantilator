namespace GurventVantilator.Application.DTOs
{
    public class ServiceFaqDto
    {
        public int Id { get; set; }
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
        public int ServiceId { get; set; }

    }
}
