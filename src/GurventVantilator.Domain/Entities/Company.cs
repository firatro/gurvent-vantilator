namespace GurventVantilator.Domain.Entities
{
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty; 

        public string? LogoPath { get; set; } 
    }
}
