namespace GurventVantilator.Application.DTOs
{
    public class ProductFilterRequest
    {
        public double? AirFlow { get; set; }
        public string? AirFlowUnit { get; set; }

        public double? TotalPressure { get; set; }
        public string? TotalPressureUnit { get; set; }
        public string? Power { get; set; }
        public double? Voltage { get; set; }
        public double? Frequency { get; set; }
        public double? Speed { get; set; }
        public double? TolerancePercent { get; set; }
    }
}
