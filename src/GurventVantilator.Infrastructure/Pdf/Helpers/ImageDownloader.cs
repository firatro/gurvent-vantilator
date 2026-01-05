using System.Net.Http;

namespace GurventVantilator.Infrastructure.Pdf.Helpers
{
    public static class ImageDownloader
    {
        private static readonly HttpClient _http = new HttpClient();

        public static byte[]? Download(string? url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return null;

            try
            {
                return _http.GetByteArrayAsync(url).GetAwaiter().GetResult();
            }
            catch
            {
                return null;
            }
        }
    }
}
