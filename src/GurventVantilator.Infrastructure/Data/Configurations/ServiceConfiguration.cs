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
                    MainImagePath = "/img/service/default-image1.jpg",
                    ContentImage1Path = "/img/service/default-image2.jpg",
                    ContentImage2Path = "/img/service/default-image3.jpg",
                    LogoPath = "/img/service/default-image4.png",
                    Name = "Web Uygulama Geliştirme",
                    Title = "Modern ve Ölçeklenebilir Web Uygulamaları",
                    Description = "Web uygulama geliştirme, işletmelerin dijital dönüşüm süreçlerinde en önemli adımlardan biridir. .NET Core, Node.js ve modern frontend teknolojileri (React, Angular, Vue) kullanılarak geliştirilen web uygulamaları; güvenli, ölçeklenebilir ve kullanıcı dostu çözümler sunar. E-ticaret, CRM, ERP ve kurumsal portallar başta olmak üzere birçok alanda modern web çözümleri geliştiriyoruz. Tüm projelerimizde yüksek performans, güvenlik ve kullanıcı deneyimini önceliklendiriyoruz.",
                    ExtraTitle = "Profesyonel Yazılım Geliştirme Yaklaşımı",
                    ExtraDescription = "Projelerimizde çevik (Agile) metodolojiler kullanarak müşterilerimizle sürekli iletişim halinde çalışıyoruz. Her aşamada şeffaflık ve kalite kontrolü sağlıyor, test odaklı geliştirme (TDD) ve otomasyon süreçleri ile hatasız ve sürdürülebilir çözümler üretiyoruz. Bu sayede müşterilerimiz, hızlı, güvenli ve uzun vadeli yazılım yatırımlarına sahip oluyor."
                },
                new Service
                {
                    Id = 2,
                    MainImagePath = "/img/service/default-image5.jpg",
                    ContentImage1Path = "/img/service/default-image6.jpg",
                    ContentImage2Path = "/img/service/default-image7.jpg",
                    LogoPath = "/img/service/default-image8.png",
                    Name = "Mobil Uygulama Geliştirme",
                    Title = "iOS ve Android için Profesyonel Mobil Çözümler",
                    Description = "Mobil uygulamalar günümüzün dijital dünyasında işletmeler için en önemli iletişim araçlarından biridir. Flutter, React Native ve Swift/Kotlin teknolojilerini kullanarak hem iOS hem Android cihazlarda sorunsuz çalışan, performanslı ve kullanıcı dostu mobil uygulamalar geliştiriyoruz. Müşteri ihtiyaçlarına göre özelleştirilmiş çözümler sunuyoruz.",
                    ExtraTitle = "Çapraz Platform ve Yerel Uygulamalar",
                    ExtraDescription = "Hem native hem de cross-platform geliştirme tecrübemiz sayesinde projeleriniz için en uygun teknolojiyi seçiyoruz. Kullanıcı deneyimini en üst seviyeye çıkarırken bakım ve güncelleme maliyetlerini minimumda tutuyoruz."
                },

                new Service
                {
                    Id = 3,
                    MainImagePath = "/img/service/default-image9.jpg",
                    ContentImage1Path = "/img/service/default-image10.jpg",
                    ContentImage2Path = "/img/service/default-image11.jpg",
                    LogoPath = "/img/service/default-image12.png",
                    Name = "Masaüstü Yazılım Geliştirme",
                    Title = "Kurumsal Çözümler İçin Güçlü Masaüstü Uygulamaları",
                    Description = "Windows, macOS ve Linux platformları için performanslı ve güvenilir masaüstü yazılımlar geliştiriyoruz. .NET, WPF, Electron ve Java teknolojilerini kullanarak işletmelerin özel ihtiyaçlarına uygun ERP, CRM ve üretim takip sistemleri tasarlıyoruz.",
                    ExtraTitle = "Dayanıklı ve Güvenli Masaüstü Çözümler",
                    ExtraDescription = "Masaüstü yazılımlarımız offline çalışma imkanı, güvenli veri yönetimi ve kullanıcı dostu arayüzleri ile şirketlerin iş süreçlerini hızlandırır. Ayrıca bulut ve API entegrasyonları ile modern altyapılarla uyumlu çalışır."
                },

                new Service
                {
                    Id = 4,
                    MainImagePath = "/img/service/default-image13.jpg",
                    ContentImage1Path = "/img/service/default-image14.jpg",
                    ContentImage2Path = "/img/service/default-image15.jpg",
                    LogoPath = "/img/service/default-image16.png",
                    Name = "E-Ticaret Çözümleri",
                    Title = "Ölçeklenebilir ve Güvenli E-Ticaret Platformları",
                    Description = "KOBİ’lerden büyük ölçekli işletmelere kadar her seviyede e-ticaret çözümleri sunuyoruz. ASP.NET Core, Shopify, WooCommerce ve özel yazılım altyapılarıyla hızlı, güvenli ve kullanıcı dostu e-ticaret platformları geliştiriyoruz.",
                    ExtraTitle = "Modern E-Ticaret Deneyimi",
                    ExtraDescription = "Ürün yönetimi, güvenli ödeme sistemleri, stok takibi, kargo entegrasyonları ve kullanıcı deneyimi odaklı arayüzler ile müşterilerinize en iyi alışveriş deneyimini sunmanıza yardımcı oluyoruz."
                },

                new Service
                {
                    Id = 5,
                    MainImagePath = "/img/service/default-image17.jpg",
                    ContentImage1Path = "/img/service/default-image18.jpg",
                    ContentImage2Path = "/img/service/default-image19.jpg",
                    LogoPath = "/img/service/default-image20.png",
                    Name = "SEO ve Dijital Pazarlama",
                    Title = "Arama Motoru Optimizasyonu ve Görünürlük Artırma",
                    Description = "SEO hizmetlerimiz ile web sitenizin Google ve diğer arama motorlarında üst sıralarda yer almasını sağlıyoruz. Teknik SEO, içerik optimizasyonu ve backlink çalışmaları ile markanızın dijital görünürlüğünü artırıyoruz.",
                    ExtraTitle = "Stratejik SEO Yaklaşımı",
                    ExtraDescription = "Anahtar kelime analizi, rakip araştırması, performans raporları ve sürekli iyileştirme adımları ile uzun vadeli başarı hedefliyoruz. Dijital pazarlama stratejilerimizle organik trafiğinizi ve müşteri dönüşüm oranlarınızı yükseltiyoruz."
                }
            );
        }
    }
}
