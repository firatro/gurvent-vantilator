using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class SliderConfiguration : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.HasData(
                new Slider
                {
                    Id = 1,
                    Tag = "Web",
                    ImagePath = "img/slider/default-image1.jpg",
                    Title = "Modern web uygulamaları",
                    Subtitle = "Ölçeklenebilir ve güvenli çözümler"
                },
                new Slider
                {
                    Id = 2,
                    Tag = "Mobil",
                    ImagePath = "img/slider/default-image2.jpg",
                    Title = "Mobil dünyada güçlü uygulamalar",
                    Subtitle = "iOS ve Android için performanslı çözümler"
                },
                new Slider
                {
                    Id = 3,
                    Tag = "E-Ticaret",
                    ImagePath = "img/slider/default-image3.jpg",
                    Title = "Dijital mağazanızı büyütün",
                    Subtitle = "Güvenli ve kullanıcı dostu e-ticaret platformları"
                },
                new Slider
                {
                    Id = 4,
                    Tag = "SEO",
                    ImagePath = "img/slider/default-image4.jpg",
                    Title = "Google’da daha görünür olun",
                    Subtitle = "SEO ve dijital pazarlama stratejileri"
                }
            );
        }
    }
}
