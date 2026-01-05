using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace GurventVantilator.Infrastructure.Pdf
{
    public static class QuestPdfSettings
    {
        public static void Configure()
        {
            QuestPDF.Settings.License = LicenseType.Community;
        }
    }
}
