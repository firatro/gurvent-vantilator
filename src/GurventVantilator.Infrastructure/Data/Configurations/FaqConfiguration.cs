using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class FaqConfiguration : IEntityTypeConfiguration<Faq>
    {
        public void Configure(EntityTypeBuilder<Faq> builder)
        {
            builder.HasData(
                new Faq
                {
                    Id = 1,
                    Question = "Hangi hizmetleri sunuyorsunuz?",
                    Answer = "Web ve mobil uygulama geliştirme, yapay zeka çözümleri, siber güvenlik danışmanlığı, bulut ve DevOps hizmetleri, yazılım bakım ve destek hizmetleri sunuyoruz.",
                    CreatedAt = new DateTime(2025, 9, 5, 9, 0, 0)
                },
                new Faq
                {
                    Id = 2,
                    Question = "Nasıl proje talebi oluşturabilirim?",
                    Answer = "Web sitemizdeki iletişim formunu doldurarak veya doğrudan bize e-posta/telefon yoluyla ulaşarak proje talebinizi iletebilirsiniz.",
                    CreatedAt = new DateTime(2025, 9, 5, 9, 10, 0)
                },
                new Faq
                {
                    Id = 3,
                    Question = "Uzaktan çalışma veya online toplantı imkanınız var mı?",
                    Answer = "Evet, tüm proje süreçlerimizi online toplantılarla yönetebiliyor ve müşterilerimizle uzaktan iş birliği yapabiliyoruz.",
                    CreatedAt = new DateTime(2025, 9, 5, 9, 20, 0)
                },
                new Faq
                {
                    Id = 4,
                    Question = "Bir yazılım projesi ne kadar sürede tamamlanır?",
                    Answer = "Projenin kapsamına bağlıdır. Küçük projeler ortalama 1-2 ay, orta ölçekli projeler 3-6 ay, büyük ölçekli projeler ise daha uzun sürede tamamlanabilmektedir.",
                    CreatedAt = new DateTime(2025, 9, 5, 9, 30, 0)
                },
                new Faq
                {
                    Id = 5,
                    Question = "Mobil uygulama geliştirme süreci nasıl ilerliyor?",
                    Answer = "İhtiyaç analizi, tasarım, geliştirme, test ve yayınlama aşamalarından oluşmaktadır. Ayrıca yayın sonrası bakım ve destek de sağlıyoruz.",
                    CreatedAt = new DateTime(2025, 9, 5, 9, 40, 0)
                },
                new Faq
                {
                    Id = 6,
                    Question = "Destek ve bakım hizmeti veriyor musunuz?",
                    Answer = "Evet, projeler tamamlandıktan sonra güncelleme, hata düzeltme ve performans optimizasyonu için destek ve bakım hizmeti sunuyoruz.",
                    CreatedAt = new DateTime(2025, 9, 5, 9, 50, 0)
                },
                new Faq
                {
                    Id = 7,
                    Question = "Yapay zeka ve makine öğrenmesi çözümleri geliştiriyor musunuz?",
                    Answer = "Evet, veri analizi, öneri sistemleri, doğal dil işleme ve görüntü işleme alanlarında yapay zeka çözümleri sunuyoruz.",
                    CreatedAt = new DateTime(2025, 9, 5, 10, 0, 0)
                },
                new Faq
                {
                    Id = 8,
                    Question = "Bulut çözümleriniz hangi platformlarda?",
                    Answer = "AWS, Azure ve Google Cloud üzerinde ölçeklenebilir ve güvenilir bulut çözümleri geliştiriyoruz.",
                    CreatedAt = new DateTime(2025, 9, 5, 10, 10, 0)
                },
                new Faq
                {
                    Id = 9,
                    Question = "Siber güvenlik hizmetleriniz neleri kapsıyor?",
                    Answer = "Penetrasyon testleri, güvenlik açığı analizi, ağ güvenliği, Zero Trust mimarisi danışmanlığı ve güvenlik farkındalık eğitimleri sunuyoruz.",
                    CreatedAt = new DateTime(2025, 9, 5, 10, 20, 0)
                },
                new Faq
                {
                    Id = 10,
                    Question = "Projeleriniz güvenli midir?",
                    Answer = "Tüm projelerimiz güvenlik standartlarına uygun geliştirilmekte, düzenli testlerden geçirilmekte ve uluslararası en iyi uygulamalar temel alınmaktadır.",
                    CreatedAt = new DateTime(2025, 9, 5, 10, 30, 0)
                }
            );
        }
    }
}
