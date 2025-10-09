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
                    SiteName = "Gurvent Vantilatör",
                    DefaultTitle = "Gurvent Vantilatör | Endüstriyel Fan ve Havalandırma Sistemleri",
                    DefaultMetaDescription = "Gurvent, santrifüj, aksiyel ve ATEX sertifikalı endüstriyel fan üretiminde liderdir. Enerji verimli ve uzun ömürlü çözümler için doğru adres.",
                    DefaultMetaKeywords = "endüstriyel fan, havalandırma, santrifüj fan, ATEX, filtrasyon, toz toplama, enerji verimliliği, gurvent",
                    DefaultOgImagePath = "/img/seo/default-image.jpg",
                    RobotsTxtContent = "User-agent: *\nAllow: /",
                    GoogleAnalyticsId = "G-GURVENT1234",
                    GoogleTagManagerId = "GTM-GURVENT01",
                    FacebookPixelId = "999888777"
                }
            );
        }
    }
}
