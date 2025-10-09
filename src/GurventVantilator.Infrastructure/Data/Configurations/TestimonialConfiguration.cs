using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class TestimonialConfiguration : IEntityTypeConfiguration<Testimonial>
    {
        public void Configure(EntityTypeBuilder<Testimonial> builder)
        {
            builder.HasData(
                new Testimonial { Id = 1, FullName = "Mehmet Koç", Title = "Fabrika Müdürü", Comment = "Yeni fan sistemimiz sayesinde üretim alanımızdaki hava kalitesi belirgin şekilde arttı. Montaj ekibi profesyonel çalıştı.", ImagePath = "/img/testimonial/client1.jpg", Rating = 5 },
                new Testimonial { Id = 2, FullName = "Ayşe Güler", Title = "Proje Mühendisi", Comment = "Projeye özel fan tasarımı istedik, kısa sürede üretildi ve tam istediğimiz performansı sağladı.", ImagePath = "/img/testimonial/client2.jpg", Rating = 5 },
                new Testimonial { Id = 3, FullName = "Serkan Demirtaş", Title = "Tesis Sorumlusu", Comment = "Fan bakım hizmetleri hızlı ve güvenilir. Arızalı fanlarımız 2 gün içinde teslim edildi.", ImagePath = "/img/testimonial/client3.jpg", Rating = 4 },
                new Testimonial { Id = 4, FullName = "Derya Akın", Title = "Endüstriyel Tesis Yöneticisi", Comment = "Filtrasyon sistemi kurulumu çok başarılı oldu. Artık toz oranı minimuma indi.", ImagePath = "/img/testimonial/client4.jpg", Rating = 5 },
                new Testimonial { Id = 5, FullName = "Kemal Aydın", Title = "Makine Bakım Müdürü", Comment = "Yüksek sıcaklık fanları projemizde kullanıldı. Dayanıklılığı ve sessiz çalışması bizi etkiledi.", ImagePath = "/img/testimonial/client5.jpg", Rating = 5 }
            );
        }
    }
}
