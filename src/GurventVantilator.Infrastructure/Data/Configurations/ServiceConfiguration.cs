using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasData(
                new Service
                {
                    Id = 1,
                    MainImagePath = "/img/service/fan-uretim1.jpg",
                    ContentImage1Path = "/img/service/fan-uretim2.jpg",
                    ContentImage2Path = "/img/service/fan-uretim3.jpg",
                    LogoPath = "/img/service/fan-logo1.png",
                    Name = "Endüstriyel Fan Üretimi",
                    Title = "Yüksek Performanslı Endüstriyel Fan Sistemleri",
                    Description = "Gurvent, endüstriyel ihtiyaçlara özel olarak santrifüj, aksiyel, kanal tipi ve çatı tipi fan üretimi yapmaktadır. Üretim sürecinde yüksek verimli motorlar, kaliteli malzeme ve modern üretim teknolojileri kullanılmaktadır.",
                    ExtraTitle = "Kalite ve Güvenilirlik Odaklı Üretim",
                    ExtraDescription = "Tüm fanlarımız uluslararası standartlara uygun olarak test edilmekte, uzun ömürlü ve sessiz çalışma prensipleriyle üretilmektedir. Müşteri taleplerine göre özel boyut ve kapasitede üretim yapılabilmektedir."
                },
                new Service
                {
                    Id = 2,
                    MainImagePath = "/img/service/havalandirma1.jpg",
                    ContentImage1Path = "/img/service/havalandirma2.jpg",
                    ContentImage2Path = "/img/service/havalandirma3.jpg",
                    LogoPath = "/img/service/havalandirma-logo.png",
                    Name = "Havalandırma Sistemleri Tasarımı ve Montajı",
                    Title = "Verimli ve Sessiz Havalandırma Çözümleri",
                    Description = "Endüstriyel tesisler, otoparklar, restoranlar ve üretim alanları için havalandırma sistemlerinin mühendislik hesapları, proje tasarımı ve montaj süreçlerini anahtar teslim gerçekleştiriyoruz.",
                    ExtraTitle = "Mühendislik Odaklı Yaklaşım",
                    ExtraDescription = "Hava debisi, statik basınç ve ses seviyesi kriterlerine uygun sistem tasarımları yaparak işletmelerde maksimum enerji verimliliği sağlıyoruz."
                },
                new Service
                {
                    Id = 3,
                    MainImagePath = "/img/service/fan-uretim1.jpg",
                    ContentImage1Path = "/img/service/fan-uretim2.jpg",
                    ContentImage2Path = "/img/service/fan-uretim3.jpg",
                    LogoPath = "/img/service/bakim-logo.png",
                    Name = "Fan Bakım ve Onarım Hizmetleri",
                    Title = "Tüm Marka Fanlarda Profesyonel Bakım ve Onarım",
                    Description = "Deneyimli teknik ekibimiz, arızalı veya performansı düşen fanların bakım ve onarımını orijinal yedek parçalarla gerçekleştirir. Dengeleme, rulman değişimi ve balans ayarları yapılmaktadır.",
                    ExtraTitle = "Yerinde Servis Desteği",
                    ExtraDescription = "Türkiye genelinde yerinde servis hizmeti sunuyor, fanlarınızın uzun ömürlü çalışmasını garanti altına alıyoruz."
                },
                new Service
                {
                    Id = 4,
                    MainImagePath = "/img/service/havalandirma1.jpg",
                    ContentImage1Path = "/img/service/havalandirma2.jpg",
                    ContentImage2Path = "/img/service/havalandirma3.jpg",
                    LogoPath = "/img/service/filtrasyon-logo.png",
                    Name = "Hava Filtrasyon ve Toz Toplama Sistemleri",
                    Title = "Temiz ve Sağlıklı Çalışma Ortamları İçin Filtrasyon Çözümleri",
                    Description = "Üretim tesislerinde oluşan toz, duman ve partikül kirliliğini minimize etmek için gelişmiş filtrasyon sistemleri tasarlayıp kuruyoruz.",
                    ExtraTitle = "Enerji Verimli Filtrasyon Teknolojisi",
                    ExtraDescription = "Kompakt tasarımlar, yüksek filtrasyon verimi ve kolay bakım özellikleriyle işletmelerde hijyen ve güvenliği artırıyoruz."
                },
                new Service
                {
                    Id = 5,
                    MainImagePath = "/img/service/fan-uretim1.jpg",
                    ContentImage1Path = "/img/service/fan-uretim2.jpg",
                    ContentImage2Path = "/img/service/fan-uretim3.jpg",
                    LogoPath = "/img/service/arge-logo.png",
                    Name = "Ar-Ge ve Özel Üretim Çözümleri",
                    Title = "İhtiyaca Özel Fan ve Havalandırma Sistemleri",
                    Description = "Müşterilerimizin özel ihtiyaçlarına yönelik fan ve havalandırma sistemleri geliştiriyoruz. Yüksek sıcaklık, korozyon veya patlama riski gibi özel çalışma koşullarına uygun çözümler üretiyoruz.",
                    ExtraTitle = "Mühendislikte Yenilikçi Yaklaşım",
                    ExtraDescription = "Ar-Ge ekibimiz, aerodinamik verimlilik, enerji tasarrufu ve sessiz çalışma için sürekli olarak yeni teknolojiler üzerinde çalışmaktadır."
                }
            );
        }
    }
}
