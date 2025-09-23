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
                new Testimonial
                {
                    Id = 1,
                    FullName = "Elif Yılmaz",
                    Title = "E-Ticaret Projesi Müşterisi",
                    Comment = "E-ticaret platformumuzu Fırat Ramazano Software ekibi geliştirdi. Kullanıcı dostu arayüz ve güvenli ödeme altyapısı sayesinde satışlarımız ciddi şekilde arttı. Profesyonel ve güvenilir bir ekip.",
                    ImagePath = "/img/testimonial/default-image1.jpg",
                    Rating = 5
                },
                new Testimonial
                {
                    Id = 2,
                    FullName = "Mehmet Demir",
                    Title = "Mobil Uygulama Müşterisi",
                    Comment = "Uzun zamandır hayalini kurduğum mobil uygulamayı Flutter ile geliştirdiler. Hem iOS hem Android’de sorunsuz çalışıyor. Destek süreçleri de çok hızlı.",
                    ImagePath = "/img/testimonial/default-image1.jpg",
                    Rating = 5
                },
                new Testimonial
                {
                    Id = 3,
                    FullName = "Zeynep Kara",
                    Title = "Web Uygulama Müşterisi",
                    Comment = "Kurumsal web sitemizi yenilediler. Hızlı, modern ve SEO uyumlu bir site oldu. Süreç boyunca iletişimleri çok şeffaf ve profesyoneldi.",
                    ImagePath = "/img/testimonial/default-image1.jpg",
                    Rating = 4
                },
                new Testimonial
                {
                    Id = 4,
                    FullName = "Ahmet Çelik",
                    Title = "SEO Hizmeti Müşterisi",
                    Comment = "SEO çalışmaları sayesinde Google’da üst sıralara çıktık. Organik trafik ve müşteri dönüşüm oranlarımız gözle görülür şekilde arttı. Kesinlikle tavsiye ederim.",
                    ImagePath = "/img/testimonial/default-image1.jpg",
                    Rating = 5
                },
                new Testimonial
                {
                    Id = 5,
                    FullName = "Selin Arslan",
                    Title = "Masaüstü Yazılım Müşterisi",
                    Comment = "Üretim takip sürecimizi masaüstü yazılım ile dijitalleştirdiler. Artık tüm operasyonlarımızı çok daha kolay yönetiyoruz. İşimize büyük değer kattı.",
                    ImagePath = "/img/testimonial/default-image1.jpg",
                    Rating = 4
                }
            );
        }
    }
}
