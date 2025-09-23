using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class ServiceFaqConfiguration : IEntityTypeConfiguration<ServiceFaq>
    {
        public void Configure(EntityTypeBuilder<ServiceFaq> builder)
        {
            builder.HasData(new ServiceFaq { Id = 1, ServiceId = 1, Question = "Web uygulamalarınız hangi teknolojilerle geliştiriliyor?", Answer = "ASP.NET Core, Node.js, React, Angular ve Vue.js gibi modern teknolojilerle güvenli ve ölçeklenebilir web uygulamaları geliştiriyoruz." },
                new ServiceFaq { Id = 2, ServiceId = 1, Question = "Web projelerinin teslim süresi ne kadar?", Answer = "Projenin kapsamına göre değişmekle birlikte, küçük projeler 1-2 ayda, daha kapsamlı projeler 3-6 ayda teslim edilebilmektedir." },
                new ServiceFaq { Id = 3, ServiceId = 1, Question = "Web uygulamalarınız mobil uyumlu mu?", Answer = "Evet, tüm web projelerimiz responsive (mobil uyumlu) olarak tasarlanmakta ve farklı cihazlarda sorunsuz çalışmaktadır." },
                new ServiceFaq { Id = 4, ServiceId = 1, Question = "Bakım ve destek hizmeti veriyor musunuz?", Answer = "Evet, projeler teslim edildikten sonra bakım, güvenlik güncellemeleri ve teknik destek hizmetleri sunuyoruz." },
                new ServiceFaq { Id = 5, ServiceId = 2, Question = "Mobil uygulamalarınız hangi platformlarda çalışıyor?", Answer = "Flutter ve React Native ile geliştirdiğimiz uygulamalar hem iOS hem Android cihazlarda sorunsuz çalışmaktadır." },
                new ServiceFaq { Id = 6, ServiceId = 2, Question = "Native mi yoksa cross-platform mu tercih ediyorsunuz?", Answer = "Projenin ihtiyaçlarına göre karar veriyoruz. Performans kritikse native, bütçe ve hız öncelikliyse cross-platform tercih ediyoruz." },
                new ServiceFaq { Id = 7, ServiceId = 2, Question = "Mobil uygulamalarda güvenlik nasıl sağlanıyor?", Answer = "SSL, veri şifreleme, 2FA ve güvenlik testleri kullanarak uygulamalarımızın güvenliğini sağlıyoruz." },
                new ServiceFaq { Id = 8, ServiceId = 2, Question = "Uygulama mağazalarına yükleme desteğiniz var mı?", Answer = "Evet, hem App Store hem de Google Play’e yükleme ve yayın sürecinde destek sağlıyoruz." },
                new ServiceFaq { Id = 9, ServiceId = 3, Question = "Masaüstü uygulamalar hangi platformlarda çalışıyor?", Answer = "Windows, macOS ve Linux için masaüstü çözümleri geliştiriyoruz." },
                new ServiceFaq { Id = 10, ServiceId = 3, Question = "Masaüstü yazılımlarınız offline çalışabilir mi?", Answer = "Evet, ihtiyaç halinde internet bağlantısı olmadan da çalışan offline çözümler geliştiriyoruz." },
                new ServiceFaq { Id = 11, ServiceId = 3, Question = "Masaüstü yazılımlar bulut ile entegre edilebilir mi?", Answer = "Evet, masaüstü uygulamalarımız bulut servisleri ve API’lerle entegre çalışacak şekilde tasarlanabilmektedir." },
                new ServiceFaq { Id = 12, ServiceId = 3, Question = "Bakım ve güncellemeler nasıl yapılıyor?", Answer = "Uzaktan bağlantı ve düzenli sürüm güncellemeleriyle bakım hizmeti veriyoruz." },
                new ServiceFaq { Id = 13, ServiceId = 4, Question = "E-ticaret siteniz hangi özellikleri içeriyor?", Answer = "Ürün yönetimi, güvenli ödeme, stok takibi, kargo entegrasyonu ve kullanıcı dostu arayüzler temel özelliklerimizdir." },
                new ServiceFaq { Id = 14, ServiceId = 4, Question = "E-ticaret siteleriniz SEO uyumlu mu?", Answer = "Evet, tüm e-ticaret çözümlerimiz SEO uyumlu geliştirilmekte ve Google’da daha iyi sıralamalar almanıza yardımcı olmaktadır." },
                new ServiceFaq { Id = 15, ServiceId = 4, Question = "E-ticaret siteleriniz mobil uyumlu mu?", Answer = "Evet, tüm e-ticaret projelerimiz responsive tasarıma sahiptir." },
                new ServiceFaq { Id = 16, ServiceId = 4, Question = "Hangi ödeme yöntemleri entegre edilebiliyor?", Answer = "Kredi kartı, banka transferi, PayPal, iyzico ve Stripe gibi popüler ödeme yöntemlerini entegre ediyoruz." },
                new ServiceFaq { Id = 17, ServiceId = 5, Question = "SEO çalışmalarınız neleri kapsıyor?", Answer = "Teknik SEO, içerik optimizasyonu, backlink çalışmaları ve hız iyileştirmelerini kapsıyoruz." },
                new ServiceFaq { Id = 18, ServiceId = 5, Question = "SEO çalışmalarının etkisi ne zaman görülür?", Answer = "Genellikle 3-6 ay içinde gözle görülür sonuçlar alınmaya başlanır." },
                new ServiceFaq { Id = 19, ServiceId = 5, Question = "Anahtar kelime analizi yapıyor musunuz?", Answer = "Evet, proje başlangıcında detaylı anahtar kelime ve rakip analizi yapıyoruz." },
                new ServiceFaq { Id = 20, ServiceId = 5, Question = "SEO çalışmalarınız kalıcı mıdır?", Answer = "SEO uzun vadeli bir süreçtir, düzenli optimizasyon ve içerik güncellemeleri ile kalıcı başarı sağlıyoruz." }
            );
        }
    }
}
