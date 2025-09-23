namespace GurventVantilator.Application.DTOs
{
    public class ServiceFeatureDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Value { get; set; }
        public int ServiceId { get; set; }
    }
}
