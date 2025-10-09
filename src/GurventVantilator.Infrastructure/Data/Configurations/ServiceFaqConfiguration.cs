using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class ServiceFaqConfiguration : IEntityTypeConfiguration<ServiceFaq>
    {
        public void Configure(EntityTypeBuilder<ServiceFaq> builder)
        {
            builder.HasData(
                // 1️⃣ Endüstriyel Fan Üretimi
                new ServiceFaq { Id = 1, ServiceId = 1, Question = "Fanlarınız hangi türlerde üretiliyor?", Answer = "Santrifüj, aksiyel, çatı tipi, kanal tipi ve özel amaçlı fanlar üretiyoruz." },
                new ServiceFaq { Id = 2, ServiceId = 1, Question = "Fan üretiminde hangi malzemeleri kullanıyorsunuz?", Answer = "Galvaniz, alüminyum ve paslanmaz çelik gövdeli modellerimiz bulunmaktadır. Kullanım alanına göre özel kaplama seçenekleri sunuyoruz." },
                new ServiceFaq { Id = 3, ServiceId = 1, Question = "Fanlarınız sessiz çalışıyor mu?", Answer = "Tüm fanlarımız balans testlerinden geçirilir ve düşük gürültü seviyesiyle çalışacak şekilde tasarlanır." },
                new ServiceFaq { Id = 4, ServiceId = 1, Question = "Fanlarınızın garanti süresi nedir?", Answer = "Tüm ürünlerimiz 2 yıl üretim hatalarına karşı garanti kapsamındadır." },

                // 2️⃣ Havalandırma Sistemleri Tasarımı ve Montajı
                new ServiceFaq { Id = 5, ServiceId = 2, Question = "Hangi alanlara havalandırma sistemi kuruyorsunuz?", Answer = "Fabrikalar, otoparklar, restoranlar, hastaneler, atölyeler ve AVM’ler için sistem tasarımı ve montajı yapıyoruz." },
                new ServiceFaq { Id = 6, ServiceId = 2, Question = "Proje öncesi keşif hizmetiniz var mı?", Answer = "Evet, mühendis ekibimiz ücretsiz keşif ve debi hesabı hizmeti sunmaktadır." },
                new ServiceFaq { Id = 7, ServiceId = 2, Question = "Havalandırma sistemi enerji verimli mi?", Answer = "Sistemlerimizi enerji tasarrufu sağlayacak şekilde mühendislik hesaplarıyla optimize ediyoruz." },
                new ServiceFaq { Id = 8, ServiceId = 2, Question = "Montaj süresi ne kadar sürer?", Answer = "Proje büyüklüğüne göre değişmekle birlikte ortalama 3 ila 10 iş günü arasında tamamlanır." },

                // 3️⃣ Fan Bakım ve Onarım
                new ServiceFaq { Id = 9, ServiceId = 3, Question = "Tüm marka fanlara bakım yapıyor musunuz?", Answer = "Evet, marka bağımsız olarak tüm endüstriyel fanların bakım ve onarımını yapıyoruz." },
                new ServiceFaq { Id = 10, ServiceId = 3, Question = "Fan balans ayarı nasıl yapılır?", Answer = "Özel balans cihazlarımızla fanlar yerinde veya atölyemizde dengelenir." },
                new ServiceFaq { Id = 11, ServiceId = 3, Question = "Periyodik bakım hizmeti sunuyor musunuz?", Answer = "Evet, işletmelere özel yıllık bakım sözleşmeleri sunuyoruz." },
                new ServiceFaq { Id = 12, ServiceId = 3, Question = "Arızalı fan ne kadar sürede onarılır?", Answer = "Genellikle 1-3 iş günü içinde bakım ve test süreci tamamlanır." },

                // 4️⃣ Filtrasyon ve Toz Toplama
                new ServiceFaq { Id = 13, ServiceId = 4, Question = "Filtrasyon sisteminiz hangi partikül boyutlarını tutar?", Answer = "0.3 mikrona kadar olan partikülleri yüksek verimli filtrelerle tutabiliyoruz." },
                new ServiceFaq { Id = 14, ServiceId = 4, Question = "Filtre değişim sıklığı nedir?", Answer = "Kullanım yoğunluğuna bağlı olarak genellikle 3 ila 6 ayda bir değişim önerilmektedir." },
                new ServiceFaq { Id = 15, ServiceId = 4, Question = "Toz toplama sistemleri enerji tasarruflu mu?", Answer = "Evet, düşük basınç kayıplı tasarımlar sayesinde enerji verimliliği sağlıyoruz." },
                new ServiceFaq { Id = 16, ServiceId = 4, Question = "Kurulum süreci nasıl ilerliyor?", Answer = "Keşif sonrası mühendislik çizimleri yapılır, ardından üretim ve montaj aşamasına geçilir." },

                // 5️⃣ Ar-Ge ve Özel Üretim
                new ServiceFaq { Id = 17, ServiceId = 5, Question = "Özel boyutlarda fan üretimi yapıyor musunuz?", Answer = "Evet, proje ihtiyaçlarına göre özel çap, debi ve motor güçlerinde fan üretimi yapabiliyoruz." },
                new ServiceFaq { Id = 18, ServiceId = 5, Question = "Yüksek sıcaklığa dayanıklı fanlarınız var mı?", Answer = "Evet, 300°C’ye kadar dayanıklı fan çözümlerimiz mevcuttur." },
                new ServiceFaq { Id = 19, ServiceId = 5, Question = "ATEX sertifikalı fan üretiyor musunuz?", Answer = "Patlayıcı ortamlarda kullanılabilecek ATEX standartlarına uygun fan üretimi yapıyoruz." },
                new ServiceFaq { Id = 20, ServiceId = 5, Question = "Ar-Ge sürecinde hangi testler yapılıyor?", Answer = "Hava debisi, statik basınç, gürültü ve titreşim testleri düzenli olarak gerçekleştirilmektedir." }
            );
        }
    }
}
