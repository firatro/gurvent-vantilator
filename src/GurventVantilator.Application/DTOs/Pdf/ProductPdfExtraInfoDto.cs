namespace GurventVantilator.Application.DTOs.Pdf
{
    public class ProductPdfExtraInfoDto
    {
        public string? ProjectName { get; set; }
        public string? CompanyInfo { get; set; }
        public string? ProductPositionNo { get; set; }
        public DateTime Date { get; set; } = DateTime.Today;
    }
}
