using GurventVantilator.Application.DTOs.Pdf;
using GurventVantilator.Infrastructure.Pdf.Helpers;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace GurventVantilator.Infrastructure.Pdf.Components
{
    public class PdfHeaderComponent : IComponent
    {
        private readonly ProductPdfHeaderDto _header;

        public PdfHeaderComponent(ProductPdfHeaderDto header)
        {
            _header = header;
        }

        public void Compose(IContainer container)
        {
            var logo = LogoLoader.LoadFromWwwRoot("img/logo/gurvent-logo.png");

            container.Row(row =>
            {
                // 🔹 LOGO
                row.ConstantItem(90).AlignMiddle().AlignLeft().Element(e =>
                {
                    if (logo != null)
                        e.Image(logo, ImageScaling.FitWidth);
                    else
                        e.Text("LOGO");
                });

                // 🔹 SAĞ BİLGİ
                row.RelativeItem(1).AlignRight().Column(col =>
                {
                    col.Item().Text(t =>
                    {
                        t.Span(_header.ProductModelCode).FontSize(16).Bold();

                        if (!string.IsNullOrEmpty(_header.ProductTestName))
                            t.Span(" " + _header.ProductTestName).FontSize(16).Bold();

                        if (!string.IsNullOrEmpty(_header.WorkingPointLabel))
                        {
                            t.Span(" ");
                            t.Span(_header.WorkingPointLabel)
                                .FontSize(16).Bold();
                        }

                        if (_header.IsEx)
                            t.Span(" Ex") .FontSize(16).Bold();;

                        if (!string.IsNullOrEmpty(_header.VoltageCode))
                            t.Span(" " + _header.VoltageCode).FontSize(16).Bold();
                    });

                });
            });
        }
    }
}
