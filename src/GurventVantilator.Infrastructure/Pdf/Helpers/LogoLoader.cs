using System.IO;

namespace GurventVantilator.Infrastructure.Pdf.Helpers
{
    public static class LogoLoader
    {
        public static byte[]? LoadFromWwwRoot(string relativePath)
        {
            try
            {
                var basePath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    relativePath.TrimStart('/')
                );

                return File.Exists(basePath)
                    ? File.ReadAllBytes(basePath)
                    : null;
            }
            catch
            {
                return null;
            }
        }
    }
}
