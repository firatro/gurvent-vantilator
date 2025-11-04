namespace GurventVantilator.Application.DTOs
{
    public class ProductFilterRequest
    {
        public int? ApplicationId { get; set; }
        public int? CategoryId { get; set; }

        public double? Diameter { get; set; }
        public string? DiameterUnit { get; set; }

        public double? AirFlow { get; set; }
        public string? AirFlowUnit { get; set; }

        public double? Pressure { get; set; }
        public string? PressureUnit { get; set; }

        public double? Power { get; set; }
        public string? PowerUnit { get; set; }

        public double? Voltage { get; set; }
        public double? Frequency { get; set; }

        public double? Speed { get; set; }
        public double? NoiseLevel { get; set; }
        public double? TolerancePercent { get; set; }
    }
}
