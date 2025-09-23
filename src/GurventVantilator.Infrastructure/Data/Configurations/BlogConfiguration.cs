using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasData(
                new Blog
                {
                    Id = 1,
                    CreatedAt = new DateTime(2025, 9, 5, 9, 0, 0),
                    FullName = "Admin User",
                    Title = "Yazılım Geliştirmede Modern Yaklaşımlar",
                    Subtitle = "Temiz Kod, Mikroservisler ve Bulut Tabanlı Çözümler",
                    Description = "Yazılım geliştirme, yalnızca kod yazmaktan ibaret değildir; sürdürülebilir, ölçeklenebilir ve kullanıcı odaklı çözümler üretmeyi hedefleyen kapsamlı bir süreçtir. Günümüzde modern yazılım mimarileri sayesinde daha çevik geliştirme süreçleri ve işlevsel açıdan tatmin edici sonuçlar elde edilmektedir.",
                    EntryTitle = "Neden Modern Yazılım Yaklaşımları Tercih Ediliyor?",
                    EntryDescription = "Monolitik yapılardan mikroservislere geçiş, DevOps kültürü ve otomasyon araçlarının yaygınlaşması yazılım ekiplerinin daha hızlı, güvenilir ve esnek ürünler geliştirmesine olanak sağlamaktadır.",
                    ExtraTitle = "Geliştirme Süreci ve Sürdürülebilirlik",
                    ExtraDescription = "Proje öncesinde detaylı bir analiz ve planlama yapılır. Agile metodolojileri sayesinde değişen ihtiyaçlara hızlı şekilde uyum sağlanır. Temiz kod ve test odaklı geliştirme ise uzun vadede sürdürülebilirliği artırır.",
                    Quote = "Temiz kod, iyi bir yazılımcının en önemli imzasıdır.",
                    QuoteSource = "Robert C. Martin (Uncle Bob)",
                    MainImagePath = "/img/blog/default-image1.jpg",
                    ContentImage1Path = "/img/blog/default-image2.jpg",
                    ContentImage2Path = "/img/blog/default-image3.jpg",
                    YoutubeVideoUrl = "https://www.youtube.com/watch?v=O8N1lvkYykg",
                    CategoryId = 1
                }, new Blog
                {
                    Id = 2,
                    CreatedAt = new DateTime(2025, 9, 10, 14, 30, 0),
                    FullName = "Admin User",
                    Title = "Yapay Zeka ve Makine Öğrenmesi",
                    Subtitle = "Geleceği Şekillendiren Teknolojiler",
                    Description = "Yapay zeka ve makine öğrenmesi, günümüzde sağlık, finans, eğitim ve yazılım geliştirme dahil pek çok sektörde devrim yaratmaktadır. Otomasyon ve öngörü yetenekleri sayesinde iş süreçleri daha verimli hale gelmektedir.",
                    EntryTitle = "Yapay Zeka Neden Önemli?",
                    EntryDescription = "Veri odaklı karar verme süreçlerinde yapay zeka, hızlı ve doğru analiz yapabilme kapasitesi ile öne çıkmaktadır.",
                    ExtraTitle = "Makine Öğrenmesi Uygulamaları",
                    ExtraDescription = "Görüntü işleme, doğal dil işleme ve öneri sistemleri günümüzün en yaygın makine öğrenmesi uygulamaları arasında yer almaktadır.",
                    Quote = "Yapay zeka, insanlığın yeni elektrik kaynağıdır.",
                    QuoteSource = "Andrew Ng",
                    MainImagePath = "/img/blog/default-image4.jpg",
                    ContentImage1Path = "/img/blog/default-image5.jpg",
                    ContentImage2Path = "/img/blog/default-image6.jpg",
                    YoutubeVideoUrl = "https://www.youtube.com/watch?v=aircAruvnKk",
                    CategoryId = 2
                },
                new Blog
                {
                    Id = 3,
                    CreatedAt = new DateTime(2025, 9, 12, 11, 15, 0),
                    FullName = "Admin User",
                    Title = "Mobil Uygulama Geliştirmede Trendler",
                    Subtitle = "Flutter, React Native ve Cross-Platform Çözümler",
                    Description = "Mobil uygulamalar, dijital dönüşümün merkezinde yer almaktadır. Günümüzde cross-platform teknolojiler sayesinde tek kod tabanı ile hem iOS hem Android uygulamaları geliştirmek mümkün hale gelmiştir.",
                    EntryTitle = "Neden Cross-Platform?",
                    EntryDescription = "Teknoloji maliyetleri azaltır, geliştirme sürecini hızlandırır ve bakım kolaylığı sağlar.",
                    ExtraTitle = "Geleceğin Mobil Teknolojileri",
                    ExtraDescription = "5G, artırılmış gerçeklik (AR) ve yapay zeka destekli uygulamalar mobil dünyayı yeniden şekillendirmektedir.",
                    Quote = "Mobil, insanın yeni uzvu haline geldi.",
                    QuoteSource = "Eric Schmidt",
                    MainImagePath = "/img/blog/default-image7.jpg",
                    ContentImage1Path = "/img/blog/default-image8.jpg",
                    ContentImage2Path = "/img/blog/default-image9.jpg",
                    YoutubeVideoUrl = "https://www.youtube.com/watch?v=fq4N0hgOWzU",
                    CategoryId = 3
                },
                new Blog
                {
                    Id = 4,
                    CreatedAt = new DateTime(2025, 9, 15, 10, 0, 0),
                    FullName = "Admin User",
                    Title = "Siber Güvenlikte Yeni Nesil Tehditler",
                    Subtitle = "Zero Trust, Ransomware ve Yapay Zeka Destekli Savunmalar",
                    Description = "Siber saldırıların çeşitliliği ve şiddeti her geçen gün artıyor. Yeni nesil güvenlik çözümleri ise şirketlerin verilerini ve kullanıcılarını daha iyi korumayı amaçlıyor.",
                    EntryTitle = "Neden Siber Güvenlik?",
                    EntryDescription = "Veri ihlalleri, kimlik avı saldırıları ve fidye yazılımları hem bireyler hem de kurumlar için ciddi riskler taşımaktadır.",
                    ExtraTitle = "Zero Trust Yaklaşımı",
                    ExtraDescription = "Kullanıcılar ve cihazlar sürekli doğrulanır, hiçbir şeye otomatik güven duyulmaz. Bu yaklaşım güvenlik risklerini önemli ölçüde azaltır.",
                    Quote = "En zayıf halka genellikle insan faktörüdür.",
                    QuoteSource = "Bruce Schneier",
                    MainImagePath = "/img/blog/default-image10.jpg",
                    ContentImage1Path = "/img/blog/default-image11.jpg",
                    ContentImage2Path = "/img/blog/default-image12.jpg",
                    YoutubeVideoUrl = "https://www.youtube.com/watch?v=inWWhr5tnEA",
                    CategoryId = 4
                },
                new Blog
                {
                    Id = 5,
                    CreatedAt = new DateTime(2025, 9, 18, 16, 45, 0),
                    FullName = "Admin User",
                    Title = "Bulut Bilişim ve DevOps Kültürü",
                    Subtitle = "Sürekli Entegrasyon ve Sürekli Teslimat (CI/CD)",
                    Description = "Bulut teknolojileri ve DevOps uygulamaları, yazılım geliştirme süreçlerinde esneklik, hız ve güvenilirlik sağlamaktadır. CI/CD boru hatları sayesinde ekipler daha kısa sürede kaliteli ürünler çıkarabilmektedir.",
                    EntryTitle = "DevOps Neden Tercih Ediliyor?",
                    EntryDescription = "Geliştirme ve operasyon ekipleri arasındaki iş birliğini artırır, yazılım teslimat süreçlerini hızlandırır.",
                    ExtraTitle = "Bulutun Gücü",
                    ExtraDescription = "AWS, Azure ve Google Cloud gibi bulut servisleri, ölçeklenebilir ve güvenilir altyapılar sunarak şirketlere büyük avantaj sağlamaktadır.",
                    Quote = "Otomasyon, modern yazılım geliştirmede en büyük müttefiktir.",
                    QuoteSource = "Gene Kim",
                    MainImagePath = "/img/blog/default-image13.jpg",
                    ContentImage1Path = "/img/blog/default-image14.jpg",
                    ContentImage2Path = "/img/blog/default-image15.jpg",
                    YoutubeVideoUrl = "https://www.youtube.com/watch?v=scEDHsr3APg",
                    CategoryId = 5
                },
                new Blog
                {
                    Id = 6,
                    CreatedAt = new DateTime(2025, 9, 20, 13, 0, 0),
                    FullName = "Admin User",
                    Title = "Yazılımda Yapısal Tasarım Kalıpları",
                    Subtitle = "Singleton, Factory, Observer ve Daha Fazlası",
                    Description = "Tasarım kalıpları, yazılım geliştiricilerin tekrar eden problemleri daha kolay ve düzenli bir şekilde çözmesine yardımcı olur. Bu kalıplar, yazılım projelerinin daha esnek ve sürdürülebilir olmasını sağlar.",
                    EntryTitle = "Tasarım Kalıpları Neden Kullanılır?",
                    EntryDescription = "Kodun okunabilirliğini artırır, bakım sürecini kolaylaştırır ve ekip içi standartlaşmayı sağlar.",
                    ExtraTitle = "En Yaygın Kalıplar",
                    ExtraDescription = "Singleton, Factory Method, Observer ve Strategy kalıpları yazılım projelerinde sıkça kullanılan örneklerdendir.",
                    Quote = "İyi bir yazılım tasarımı, kötü kodu bile taşıyabilir.",
                    QuoteSource = "Erich Gamma (Gang of Four)",
                    MainImagePath = "/img/blog/default-image16.jpg",
                    ContentImage1Path = "/img/blog/default-image17.jpg",
                    ContentImage2Path = "/img/blog/default-image18.jpg",
                    YoutubeVideoUrl = "https://www.youtube.com/watch?v=NU_1StN5Tkk",
                    CategoryId = 6
                }
            );
        }
    }
}
