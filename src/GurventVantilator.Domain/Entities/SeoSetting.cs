namespace GurventVantilator.Domain.Entities
{
    public class SeoSetting
    {
        public int Id { get; set; }
        public string SiteName { get; set; } = string.Empty;
        public string DefaultTitle { get; set; } = string.Empty;
        public string DefaultMetaDescription { get; set; } = string.Empty;
        public string DefaultMetaKeywords { get; set; } = string.Empty;
        public string DefaultOgImagePath { get; set; } = string.Empty;
        public string RobotsTxtContent { get; set; } = string.Empty;
        public string GoogleAnalyticsId { get; set; } = string.Empty;
        public string GoogleTagManagerId { get; set; } = string.Empty;
        public string FacebookPixelId { get; set; } = string.Empty;
    }
}
