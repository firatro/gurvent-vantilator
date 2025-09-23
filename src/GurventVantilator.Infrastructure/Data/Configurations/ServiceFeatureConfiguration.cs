using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class ServiceFeatureConfiguration : IEntityTypeConfiguration<ServiceFeature>
    {
        public void Configure(EntityTypeBuilder<ServiceFeature> builder)
        {
            builder.HasData(
                new ServiceFeature { Id = 1, ServiceId = 1, Name = "Ölçeklenebilir altyapı" },
                new ServiceFeature { Id = 2, ServiceId = 1, Name = "Modern frontend teknolojileri" },
                new ServiceFeature { Id = 3, ServiceId = 1, Name = "Yüksek güvenlik standartları" },
                new ServiceFeature { Id = 4, ServiceId = 1, Name = "Kullanıcı dostu arayüz tasarımı" },
                new ServiceFeature { Id = 5, ServiceId = 2, Name = "iOS ve Android uyumluluk" },
                new ServiceFeature { Id = 6, ServiceId = 2, Name = "Cross-platform geliştirme" },
                new ServiceFeature { Id = 7, ServiceId = 2, Name = "Gerçek zamanlı bildirimler" },
                new ServiceFeature { Id = 8, ServiceId = 2, Name = "Yüksek performanslı mobil deneyim" },
                new ServiceFeature { Id = 9, ServiceId = 3, Name = "Windows, macOS ve Linux desteği" },
                new ServiceFeature { Id = 10, ServiceId = 3, Name = "Offline çalışma imkanı" },
                new ServiceFeature { Id = 11, ServiceId = 3, Name = "Bulut entegrasyonu" },
                new ServiceFeature { Id = 12, ServiceId = 3, Name = "Kurumsal iş süreçlerine özel çözümler" },
                new ServiceFeature { Id = 13, ServiceId = 4, Name = "Güvenli ödeme sistemleri" },
                new ServiceFeature { Id = 14, ServiceId = 4, Name = "Stok ve sipariş yönetimi" },
                new ServiceFeature { Id = 15, ServiceId = 4, Name = "Kargo entegrasyonu" },
                new ServiceFeature { Id = 16, ServiceId = 4, Name = "Mobil uyumlu e-ticaret deneyimi" },
                new ServiceFeature { Id = 17, ServiceId = 5, Name = "Anahtar kelime analizi" },
                new ServiceFeature { Id = 18, ServiceId = 5, Name = "Teknik SEO optimizasyonu" },
                new ServiceFeature { Id = 19, ServiceId = 5, Name = "Backlink stratejileri" },
                new ServiceFeature { Id = 20, ServiceId = 5, Name = "Performans ve hız iyileştirmeleri" }
            );
        }
    }
}
