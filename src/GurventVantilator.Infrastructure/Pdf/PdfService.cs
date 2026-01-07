using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.DTOs.Pdf;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Infrastructure.Pdf.Components;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace GurventVantilator.Infrastructure.Pdf
{
    public class PdfService : IPdfService
    {
        public byte[] GenerateProductPerformancePdf(
            ProductDto product,
            ProductPdfHeaderDto header,
            ProductPerformancePdfRequestDto request)
        {
            header.WorkingPointLabel = request.WorkingPointLabel;
            var extraInfo = new ProductPdfExtraInfoDto
            {
                ProjectName = ".",
                CompanyInfo = ".",
                ProductPositionNo = "EF01",
                Date = DateTime.Today
            };


            var document = Document.Create(container =>
            {
                // =========================
                // 1. SAYFA – PERFORMANS
                // =========================
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(30);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    page.Content().Column(col =>
                    {
                        col.Item().Component(new PdfHeaderComponent(header));

                        col.Item().PaddingVertical(10).LineHorizontal(1);

                        col.Item().PaddingTop(8).Component(new PdfExtraInfoTableComponent(extraInfo));

                        // 🔹 ÜST SATIR: Ürün Görseli + Ana Grafik
                        var productImageUrl =
                            string.IsNullOrWhiteSpace(product.Image1Path)
                                ? null
                                : $"https://admin.gurvent.firatramazano.com/{product.Image1Path.TrimStart('/')}";

                        col.Item().PaddingTop(20).Row(row =>
                        {
                            row.RelativeItem(1)
                                .Component(new ProductImageWithDescriptionComponent(
                                    productImageUrl,
                                    product.Description,
                                    150
                                ));

                            row.RelativeItem(2)
                                .Component(new ChartImageComponent(request.Charts.Main));
                        });


                        // 🔹 META TABLO + MINI GRAFİKLER (YAN YANA)
                        col.Item().PaddingTop(15).Row(row =>
                        {
                            // SOL: META TABLO
                            row.RelativeItem(1)
                                .Component(new PerformanceMetaTableComponent(
                                    request.Meta,
                                    request.RequestedQ,
                                    request.RequestedPt
                                ));


                            // SAĞ: MINI GRAFİKLER (3x3)
                            row.RelativeItem(2)
                                .Component(new MiniChartGridComponent(request.Charts));
                        });

                    });

                    page.Footer()
                        .AlignCenter()
                        .PaddingTop(5)
                        .Text("www.gurvent.com.tr")
                        .FontSize(8)
                        .FontColor(Colors.BlueGrey.Darken2);
                });

                // =========================
                // 2. SAYFA – ÜRÜN DETAY
                // =========================
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(30);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    page.Content().Column(col =>
                    {
                        col.Item().Component(new PdfHeaderComponent(header));

                        col.Item().PaddingVertical(10).LineHorizontal(1);

                        col.Item().PaddingTop(8).Component(new PdfExtraInfoTableComponent(extraInfo));

                        col.Item().PaddingTop(20)
                            .Text("Teknik Ölçüler")
                            .FontSize(12)
                            .Bold();

                        var scaleImageUrl =
                            string.IsNullOrWhiteSpace(product.ScaleImagePath)
                                ? null
                                : $"https://admin.gurvent.firatramazano.com/{product.ScaleImagePath.TrimStart('/')}";

                        col.Item().PaddingTop(10)
                            .Component(new ProductImageComponent(scaleImageUrl, 250));

                        if (product.Accessories != null && product.Accessories.Any())
                        {
                            col.Item().PaddingTop(20)
                                .Text("Aksesuarlar")
                                .FontSize(12)
                                .Bold();

                            col.Item().PaddingTop(10)
                                .Component(new AccessoriesTableComponent(product.Accessories));
                        }
                    });

                    page.Footer()
                        .AlignCenter()
                        .PaddingTop(5)
                        .Text("www.gurvent.com.tr")
                        .FontSize(8)
                        .FontColor(Colors.BlueGrey.Darken2);
                });
            });

            return document.GeneratePdf();
        }
    }
}
