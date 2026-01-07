namespace GurventVantilator.Application.DTOs.Pdf
{
    public class ProductPerformancePdfRequestDto
    {
        public int ProductId { get; set; }

        // 🔹 KULLANICI GİRİŞİ (İSTENEN)
        public double RequestedQ { get; set; }
        public double RequestedPt { get; set; }

        public string? WorkingPointLabel { get; set; }

        public string? Voltage { get; set; }

        // 🔴 CANVAS GÖRSELLER (BASE64)
        public ChartImagesDto Charts { get; set; } = new();

        // 🔴 HESAPLANMIŞ META DEĞERLER
        public PerformanceMetaDto Meta { get; set; } = new();
    }
}
