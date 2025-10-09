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
                    Tag = "Üretim",
                    ImagePath = "/img/slider/factory1.jpg",
                    Title = "Endüstriyel Fan Üretiminde 40 Yıllık Tecrübe",
                    Subtitle = "Güçlü mühendislik, kaliteli üretim, maksimum verim."
                },
                new Slider
                {
                    Id = 2,
                    Tag = "Havalandırma",
                    ImagePath = "/img/slider/ventilation1.jpg",
                    Title = "Havalandırma Sistemlerinde Profesyonel Çözümler",
                    Subtitle = "Enerji verimli, sessiz ve güvenilir sistemler."
                },
                new Slider
                {
                    Id = 3,
                    Tag = "Filtrasyon",
                    ImagePath = "/img/slider/filtration1.jpg",
                    Title = "Temiz Hava, Sağlıklı Çalışma Ortamı",
                    Subtitle = "Toz toplama ve hava filtrasyon sistemlerinde lider marka."
                },
                new Slider
                {
                    Id = 4,
                    Tag = "Servis",
                    ImagePath = "/img/slider/service1.jpg",
                    Title = "Bakım ve Onarımda Güvenilir Hizmet",
                    Subtitle = "Her marka fan için profesyonel servis desteği."
                }
            );
        }
    }
}
