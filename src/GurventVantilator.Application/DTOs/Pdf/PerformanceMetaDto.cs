namespace GurventVantilator.Application.DTOs.Pdf
{
    public class PerformanceMetaDto
    {
        public double Q { get; set; }
        public double Ps { get; set; }
        public double Pd { get; set; }
        public double Pt { get; set; }

        public double Speed { get; set; }
        public double Current { get; set; }
        public double AirPower { get; set; }

        public double TotalEfficiency { get; set; }
        public double MechanicalEfficiency { get; set; }

        public double Db { get; set; }
    }
}
