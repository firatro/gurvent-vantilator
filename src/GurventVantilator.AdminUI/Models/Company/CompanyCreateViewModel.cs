namespace GurventVantilator.AdminUI.Models.Company
{
    public class CompanyCreateViewModel
    {
        public string Name { get; set; } = string.Empty;

        public IFormFile? LogoFile { get; set; }
    }
}
