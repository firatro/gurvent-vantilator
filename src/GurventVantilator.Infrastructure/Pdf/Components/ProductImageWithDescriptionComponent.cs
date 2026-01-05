using GurventVantilator.Infrastructure.Pdf.Helpers;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace GurventVantilator.Infrastructure.Pdf.Components
{
    public class ProductImageWithDescriptionComponent : IComponent
    {
        private readonly string? _imageUrl;
        private readonly string? _description;
        private readonly float _imageHeight;

        public ProductImageWithDescriptionComponent(
            string? imageUrl,
            string? description,
            float imageHeight = 260)
        {
            _imageUrl = imageUrl;
            _description = description;
            _imageHeight = imageHeight;
        }

        public void Compose(IContainer container)
        {
            var imageBytes = ImageDownloader.Download(_imageUrl);

            container.Column(col =>
            {
                // 🔹 GÖRSEL
                col.Item().Height(_imageHeight).AlignCenter().Element(e =>
                {
                    if (imageBytes != null)
                    {
                        e.Image(imageBytes, ImageScaling.FitArea);
                    }
                    else
                    {
                        e.Border(1)
                         .Padding(10)
                         .AlignCenter()
                         .Text("Görsel bulunamadı")
                         .FontSize(9)
                         .FontColor(Colors.Grey.Darken1);
                    }
                });

                // 🔹 DESCRIPTION (TEK SATIR)
                if (!string.IsNullOrWhiteSpace(_description))
                {
                    col.Item()
                        .PaddingTop(4)
                        .Text(_description)
                        .FontSize(9)
                        .FontColor(Colors.Black);
                }
            });
        }
    }
}
