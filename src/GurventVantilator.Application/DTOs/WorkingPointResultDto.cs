namespace GurventVantilator.Application.DTOs.WorkingPoint
{
    public class WorkingPointResultDto
    {
        public double InputQ { get; set; }
        public double InputPt { get; set; }

        public double CalculatedRPM { get; set; }
        public double CalculatedPower { get; set; }

        public double NearestQ { get; set; }
        public double NearestPt { get; set; }

        public double Distance { get; set; } // ne kadar saptı
    }
}
