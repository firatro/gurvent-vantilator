namespace GurventVantilator.Domain.Entities
{
    public class ServiceFeature
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Value { get; set; }

        // İlişki
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
