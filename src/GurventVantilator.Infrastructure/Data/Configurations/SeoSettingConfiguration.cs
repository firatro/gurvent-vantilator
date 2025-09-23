using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class SeoSettingUsConfiguration : IEntityTypeConfiguration<SeoSetting>
    {
        public void Configure(EntityTypeBuilder<SeoSetting> builder)
        {
            builder.HasData(
                new SeoSetting
                {
                    Id = 1,
                    SiteName = "Fırat Ramazano Software",
                    DefaultTitle = "Fırat Ramazano | Yazılım Geliştirme ve Teknoloji Çözümleri",
                    DefaultMetaDescription = "Fırat Ramazano, modern web, mobil ve yapay zeka tabanlı yazılım çözümleri geliştirir. Güvenli, ölçeklenebilir ve kullanıcı dostu uygulamalar için profesyonel destek sunar.",
                    DefaultMetaKeywords = "yazılım geliştirme, web uygulamaları, mobil uygulama, yapay zeka, siber güvenlik, bulut, devops, firat ramazano",
                    DefaultOgImagePath = "/img/seo-setting/default-image.jpg",
                    RobotsTxtContent = "User-agent: *\nAllow: /",
                    GoogleAnalyticsId = "G-XXXXXXX",
                    GoogleTagManagerId = "GTM-XXXXXXX",
                    FacebookPixelId = "1234567890"
                }
            );
        }
    }
}
