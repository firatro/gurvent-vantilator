namespace GurventVantilator.Application.DTOs.Pdf
{
    public class ProductPerformancePdfRequestDto
    {
        public int ProductId { get; set; }

        // 🔴 ÇALIŞMA NOKTASI
        public double Q { get; set; }
        public double Pt { get; set; }

        public string? Voltage { get; set; }

        // 🔴 CANVAS GÖRSELLER (BASE64)
        public ChartImagesDto Charts { get; set; } = new();

        // 🔴 HESAPLANMIŞ META DEĞERLER
        public PerformanceMetaDto Meta { get; set; } = new();
    }
}
