namespace GurventVantilator.AdminUI.Models.Company
{
    public class CompanyEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? LogoPath { get; set; }
        public IFormFile? LogoFile { get; set; }
    }
}
