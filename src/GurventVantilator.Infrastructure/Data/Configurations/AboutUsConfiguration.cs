using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class AboutUsConfiguration : IEntityTypeConfiguration<AboutUs>
    {
        public void Configure(EntityTypeBuilder<AboutUs> builder)
        {
            builder.HasData(
                new AboutUs
                {
                    Id = 1,
                    Title = "Hakkımızda",
                    ExtraTitle = "40 Yıllık Deneyim, Güçlü Çözümler",
                    Description = "Gurvent Vantilatör, endüstriyel fan ve havalandırma sistemleri alanında uzmanlaşmış bir mühendislik firmasıdır. 1984 yılından bu yana sanayi tesislerinden sağlık kurumlarına kadar birçok sektöre yenilikçi ve güvenilir çözümler sunmaktayız.",
                    ExtraDescription = "Kaliteli üretim, mühendislik tecrübesi ve müşteri memnuniyetine dayalı yaklaşımımızla, Türkiye'nin önde gelen endüstriyel fan üreticilerinden biriyiz. Ürünlerimiz CE ve ISO 9001 kalite standartlarına uygun olarak üretilmektedir.",
                    ExperienceYear = 40,
                    HappyClients = 1200,
                    CompletedProjects = 750,
                    Awards = 8,
                    ImagePath = "/img/about-us/factory-team.jpg"
                }
            );
        }
    }
}
