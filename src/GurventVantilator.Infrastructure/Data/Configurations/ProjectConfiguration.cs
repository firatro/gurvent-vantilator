

using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasData(
                new Project
                {
                    Id = 1,
                    MainImagePath = "/img/project/default-image1.jpg",
                    ContentImage1Path = "/img/project/default-image2.jpg",
                    ContentImage2Path = "/img/project/default-image3.jpg",
                    Title = "E-Ticaret Platformu",
                    Subtitle = "Ölçeklenebilir Web Uygulaması",
                    IntroText = "Proje başlangıcında müşterinin ihtiyaçları, hedef kitlesi ve iş modeli detaylı şekilde analiz edilerek yazılım mimarisi planlandı. Kullanıcı dostu arayüz, güvenli ödeme altyapısı ve hızlı ürün yönetimi ön planda tutuldu.",
                    Description = "E-ticaret projesinde React tabanlı modern bir frontend, .NET Core tabanlı güçlü bir backend ve MSSQL veritabanı kullanıldı. Projede mikroservis mimarisi tercih edilerek ölçeklenebilirlik sağlandı. Ayrıca kullanıcı deneyimi için dinamik filtreleme, ürün öneri sistemi ve güvenli ödeme entegrasyonu geliştirildi. Bulut tabanlı dağıtım sayesinde sistem performansı ve güvenliği üst seviyeye çıkarıldı.",
                    CustomerInfo = "Elif Yılmaz",
                    ExtraTitle = "Canlıya Alım ve Destek",
                    ExtraDescription = "Proje tamamlandıktan sonra CI/CD süreçleriyle canlıya alındı. Müşteriye eğitim verildi ve bakım-destek süreci başlatıldı. Kullanıcı geri bildirimlerine göre düzenli güncellemeler yapılmaktadır.",
                    ProjectDate = new DateTime(2023, 5, 20),
                    CreatedAt = new DateTime(2025, 9, 5, 9, 0, 0)
                },
                new Project
                {
                    Id = 2,
                    MainImagePath = "/img/project/default-image4.jpg",
                    ContentImage1Path = "/img/project/default-image5.jpg",
                    ContentImage2Path = "/img/project/default-image6.jpg",
                    Title = "Mobil Bankacılık Uygulaması",
                    Subtitle = "iOS ve Android için Cross-Platform Çözüm",
                    IntroText = "Proje öncesinde müşterinin mevcut bankacılık altyapısı incelendi ve güvenlik, performans ve kullanıcı deneyimi açısından ihtiyaçlar belirlendi. Kullanıcıların hızlı ve güvenli bir şekilde finansal işlemler yapabilmesi hedeflendi.",
                    Description = "Flutter kullanılarak hem iOS hem Android platformlarında çalışan mobil uygulama geliştirildi. Uygulamada para transferi, fatura ödeme, QR ile işlem ve anlık bildirim gibi özellikler yer aldı. Güvenlik için çift faktörlü kimlik doğrulama ve SSL şifreleme entegre edildi. Backend kısmında .NET Core API kullanıldı ve yüksek trafik altında sorunsuz çalışması için bulut tabanlı servisler tercih edildi.",
                    CustomerInfo = "Zeynep Kaya",
                    ExtraTitle = "Test ve Yayınlama",
                    ExtraDescription = "Uygulama, farklı cihazlarda kapsamlı testlerden geçirildi. Yayın sürecinde App Store ve Google Play standartlarına uygun hale getirildi. Yayın sonrası müşteri destek ekibiyle birlikte kullanıcı geri bildirimleri sürekli olarak değerlendirilmektedir.",
                    ProjectDate = new DateTime(2023, 7, 12),
                    CreatedAt = new DateTime(2025, 9, 5, 9, 0, 0)
                },
                new Project
                {
                    Id = 3,
                    MainImagePath = "/img/project/default-image7.jpg",
                    ContentImage1Path = "/img/project/default-image8.jpg",
                    ContentImage2Path = "/img/project/default-image9.jpg",
                    Title = "Yapay Zeka Destekli CRM Sistemi",
                    Subtitle = "Müşteri İlişkileri Yönetiminde Akıllı Çözümler",
                    IntroText = "Proje öncesinde satış ekiplerinin ihtiyaçları analiz edildi. Müşteri verilerinin daha verimli yönetilmesi, satış süreçlerinin hızlanması ve yapay zeka destekli tahminleme hedeflendi.",
                    Description = "Proje kapsamında .NET Core ile geliştirilen güçlü bir backend ve Angular tabanlı modern bir frontend tasarlandı. CRM sistemi; müşteri segmentasyonu, otomatik görev atamaları ve e-posta entegrasyonu özelliklerini içeriyor. Yapay zeka destekli tahminleme modülü sayesinde satış fırsatları önceden öngörülerek ekiplerin stratejileri optimize edildi.",
                    CustomerInfo = "Derya Demir",
                    ExtraTitle = "Uygulama Sonrası",
                    ExtraDescription = "Sistem devreye alındıktan sonra satış ekibinin verimliliğinde %35 artış gözlemlendi. Düzenli güncellemelerle yeni özellikler eklenmeye devam ediliyor. Müşteri, uzun vadeli destek paketimizden faydalanıyor.",
                    ProjectDate = new DateTime(2023, 9, 1),
                    CreatedAt = new DateTime(2025, 9, 5, 9, 0, 0)
                }
            );
        }
    }
}

