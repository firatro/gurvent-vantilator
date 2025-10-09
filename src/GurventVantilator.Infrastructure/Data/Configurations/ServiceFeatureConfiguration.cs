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
                // 1️⃣ Endüstriyel Fan Üretimi
                new ServiceFeature { Id = 1, ServiceId = 1, Name = "Yüksek verimli motor teknolojisi" },
                new ServiceFeature { Id = 2, ServiceId = 1, Name = "Sessiz çalışma prensibi" },
                new ServiceFeature { Id = 3, ServiceId = 1, Name = "Uzun ömürlü rulman sistemi" },
                new ServiceFeature { Id = 4, ServiceId = 1, Name = "Farklı kapasite ve ölçü seçenekleri" },

                // 2️⃣ Havalandırma Sistemleri Tasarımı ve Montajı
                new ServiceFeature { Id = 5, ServiceId = 2, Name = "Enerji verimli sistem tasarımı" },
                new ServiceFeature { Id = 6, ServiceId = 2, Name = "Projeye özel mühendislik hesapları" },
                new ServiceFeature { Id = 7, ServiceId = 2, Name = "Profesyonel montaj ekibi" },
                new ServiceFeature { Id = 8, ServiceId = 2, Name = "Bina otomasyon sistemleri entegrasyonu" },

                // 3️⃣ Fan Bakım ve Onarım Hizmetleri
                new ServiceFeature { Id = 9, ServiceId = 3, Name = "Yerinde servis hizmeti" },
                new ServiceFeature { Id = 10, ServiceId = 3, Name = "Balans ve titreşim kontrolü" },
                new ServiceFeature { Id = 11, ServiceId = 3, Name = "Rulman ve kayış değişimi" },
                new ServiceFeature { Id = 12, ServiceId = 3, Name = "Periyodik bakım sözleşmesi imkanı" },

                // 4️⃣ Hava Filtrasyon ve Toz Toplama Sistemleri
                new ServiceFeature { Id = 13, ServiceId = 4, Name = "Yüksek filtrasyon verimliliği" },
                new ServiceFeature { Id = 14, ServiceId = 4, Name = "Düşük enerji tüketimi" },
                new ServiceFeature { Id = 15, ServiceId = 4, Name = "Kompakt ve modüler tasarım" },
                new ServiceFeature { Id = 16, ServiceId = 4, Name = "Kolay bakım ve temizlik" },

                // 5️⃣ Ar-Ge ve Özel Üretim Çözümleri
                new ServiceFeature { Id = 17, ServiceId = 5, Name = "Yüksek sıcaklığa dayanıklı fan tasarımları" },
                new ServiceFeature { Id = 18, ServiceId = 5, Name = "Korozyona dayanıklı malzeme kullanımı" },
                new ServiceFeature { Id = 19, ServiceId = 5, Name = "Sessiz çalışma optimizasyonu" },
                new ServiceFeature { Id = 20, ServiceId = 5, Name = "Prototip geliştirme ve performans testleri" }
            );
        }
    }
}
