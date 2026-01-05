using GurventVantilator.Infrastructure.Pdf.Helpers;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace GurventVantilator.Infrastructure.Pdf.Components
{
    public class ProductImageComponent : IComponent
    {
        private readonly string? _imageUrl;
        private readonly float _height;

        public ProductImageComponent(string? imageUrl, float height = 250)
        {
            _imageUrl = imageUrl;
            _height = height;
        }

        public void Compose(IContainer container)
        {
            var img = ImageDownloader.Download(_imageUrl);

            if (img == null)
            {
                container.Text("Görsel bulunamadı");
                return;
            }

            container
                .Height(_height)
                .AlignCenter()
                .Image(img, ImageScaling.FitArea);
        }
    }
}
