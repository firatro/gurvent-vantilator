namespace GurventVantilator.Domain.Entities
{
    public class SiteInfo
    {
        public int Id { get; set; }
        public string Phone1 { get; set; } = string.Empty;
        public string? Phone2 { get; set; }
        public string? Fax1 { get; set; }
        public string? Fax2 { get; set; }
        public string Email1 { get; set; } = string.Empty;
        public string? Email2 { get; set; }
        public string SiteName { get; set; } = string.Empty;
        public string SiteInformation { get; set; } = string.Empty;
        public string SiteOwner { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string CompanyOwner { get; set; } = string.Empty;
        public string GoogleMapsApi { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string WorkingHours { get; set; } = string.Empty;
        public string TaxNumber { get; set; } = string.Empty;
        public string TaxOffice { get; set; } = string.Empty;
        public string WaNumber { get; set; } = string.Empty;
        public string TNumber { get; set; } = string.Empty;
        public string? LogoPath { get; set; }

    }
}
