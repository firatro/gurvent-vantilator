namespace GurventVantilator.Application.DTOs.Charts
{
    public class FanChartDatasetDto
    {
        public string Label { get; set; } = string.Empty;
        public List<FanChartPointDto> Data { get; set; } = new();
        public bool HideLegend { get; set; }

    }
}
