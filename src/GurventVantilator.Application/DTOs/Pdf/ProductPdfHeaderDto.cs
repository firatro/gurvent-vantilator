namespace GurventVantilator.Application.DTOs.Pdf
{
    public class ProductPdfHeaderDto
    {
        // 🔹 ANA MODEL KODU
        public string ProductModelCode { get; set; } = string.Empty;

        // 🔹 TEST / ALT MODEL ADI (opsiyonel)
        public string? ProductTestName { get; set; }

        // 🔹 PATLAYICI ORTAM (Ex)
        public bool IsEx { get; set; }

        // 🔹 VOLTAJ KODU (T / M)
        public string? VoltageCode { get; set; }

        public string? WorkingPointLabel { get; set; }

        // 🔹 PDF ÜZERİNDE GÖSTERİLECEK TAM BAŞLIK
        public string GetDisplayTitle()
        {
            /*
             * Örnek çıktılar:
             * RSDP 31B/2/50
             * RSDP 31B/2/50 Ex
             * RSDP 31B/2/50 Ex (M)
             * RSDP 31B/2/50 (M)
             */

            var parts = new List<string>
            {
                ProductModelCode
            };

            if (!string.IsNullOrWhiteSpace(ProductTestName))
                parts.Add(ProductTestName);

            if (IsEx)
                parts.Add("Ex");

            if (!string.IsNullOrWhiteSpace(VoltageCode))
                parts.Add(VoltageCode);

            return string.Join(" ", parts);
        }
    }
}
