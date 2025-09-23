using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class BeforeAfterConfiguration : IEntityTypeConfiguration<BeforeAfter>
    {
        public void Configure(EntityTypeBuilder<BeforeAfter> builder)
        {
            builder.HasData(
                new BeforeAfter
                {
                    Id = 1,
                    Title = "Web Sitesi Yenileme Sonuçları",
                    Subtitle = "Modern ve Kullanıcı Dostu Arayüz",
                    Description = "Müşterimizin mevcut web sitesi, güncel tasarım trendleri ve kullanıcı deneyimi ilkeleri doğrultusunda yeniden tasarlandı. Yeni sürümde hız, mobil uyumluluk ve SEO performansı artırıldı.",
                    BeforeImagePath = "img/before-after/default-image1.jpg",
                    AfterImagePath = "img/before-after/default-image2.jpg"
                },
                new BeforeAfter
                {
                    Id = 2,
                    Title = "Mobil Uygulama Dönüşümü",
                    Subtitle = "Hızlı, Şık ve Kullanıcı Odaklı",
                    Description = "Eski mobil uygulama, modern UI/UX prensipleriyle baştan tasarlandı. Yeni versiyonda performans iyileştirmeleri, sadeleştirilmiş arayüz ve gelişmiş kullanıcı deneyimi sunuldu.",
                    BeforeImagePath = "img/before-after/default-image3.jpg",
                    AfterImagePath = "img/before-after/default-image4.jpg"
                }
            );
        }
    }
}
