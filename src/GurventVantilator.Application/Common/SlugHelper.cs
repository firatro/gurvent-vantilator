using System.Text.RegularExpressions;

namespace GurventVantilator.Application.Common
{
    public static class SlugHelper
    {
        public static string GenerateSlug(string phrase)
        {
            if (string.IsNullOrWhiteSpace(phrase))
                return string.Empty;

            string str = phrase.ToLowerInvariant();

            // Türkçe karakter dönüşümleri
            str = str.Replace("ç", "c")
                     .Replace("ğ", "g")
                     .Replace("ı", "i")
                     .Replace("ö", "o")
                     .Replace("ş", "s")
                     .Replace("ü", "u");

            // geçersiz karakterleri temizle
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");

            // boşlukları tireye çevir
            str = Regex.Replace(str, @"\s+", "-").Trim('-');

            // çoklu tireleri tekilleştir
            str = Regex.Replace(str, @"-+", "-");

            return str;
        }
    }
}
