using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System;

namespace GurventVantilator.Infrastructure.Pdf.Components
{
    public class ChartImageComponent : IComponent
    {
        private readonly string? _base64;

        public ChartImageComponent(string? base64)
        {
            _base64 = base64;
        }

        public void Compose(IContainer container)
        {
            if (string.IsNullOrWhiteSpace(_base64))
            {
                container.Text("Grafik bulunamadı");
                return;
            }

            var imageBytes = Convert.FromBase64String(
                _base64.Replace("data:image/png;base64,", "")
            );

            container
                .Padding(15)
                .Image(imageBytes);
        }
    }
}
