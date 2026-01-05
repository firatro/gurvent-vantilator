using GurventVantilator.Application.DTOs.Pdf;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace GurventVantilator.Infrastructure.Pdf.Components
{
    public class PdfExtraInfoTableComponent : IComponent
    {
        private readonly ProductPdfExtraInfoDto _info;

        public PdfExtraInfoTableComponent(ProductPdfExtraInfoDto info)
        {
            _info = info;
        }

        public void Compose(IContainer container)
        {
            container.Column(col =>
            {
                // Başlık
                col.Item().Text("Ek Bilgi Kısmı:")
                    .FontSize(10)
                    .Bold();

                col.Item().PaddingTop(5).Table(table =>
                {
                    table.ColumnsDefinition(cols =>
                    {
                        cols.ConstantColumn(120); // Sol etiket
                        cols.RelativeColumn();    // Değer
                        cols.ConstantColumn(120); // Sağ etiket
                        cols.ConstantColumn(120); // Sağ değer
                    });

                    void Row(string l1, string v1, string l2, string v2, bool highlight = false)
                    {
                        var bg = highlight ? Colors.LightBlue.Lighten4 : Colors.White;

                        table.Cell().Background(bg).Padding(5).Text(l1).Bold();
                        table.Cell().Background(bg).Padding(5).Text(v1);
                        table.Cell().Background(bg).Padding(5).Text(l2).Bold();
                        table.Cell().Background(bg).Padding(5).Text(v2);
                    }

                    Row(
                        "Proje Adı",
                        _info.ProjectName ?? ".",
                        "Tarih",
                        _info.Date.ToString("dd.MM.yyyy"),
                        highlight: true
                    );

                    Row(
                        "Firma Bilgileri",
                        _info.CompanyInfo ?? ".",
                        "Ürün Poz. No",
                        _info.ProductPositionNo ?? "."
                    );
                });
            });
        }
    }
}
