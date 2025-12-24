namespace GurventVantilator.Application.DTOs.Charts
{
    public class FanChartDto
    {
        public string Title { get; set; } = "Fan Performans Eğrisi";
        public string XAxisLabel { get; set; } = "Debi (Q)";
        public string YAxisLabel { get; set; } = "Toplam Basınç (Pt)";

        public List<FanChartDatasetDto> Datasets { get; set; } = new();
        public FanTestMetaDto? Meta { get; set; }

    }
}
