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
                    Title = "Ben Kimim?",
                    ExtraTitle = "Özgür Ruh, Yaratıcı Çözümler",
                    Description = "Yazılım geliştirme alanında freelance olarak uzun süredir hizmet veriyorum. Amacım yalnızca kod yazmak değil, her müşterime özel, esnek ve yenilikçi çözümler üretmektir. Bugüne kadar farklı sektörlerden bireyler ve işletmeler için web, mobil ve özel yazılım projeleri geliştirdim. Projelerde sadece teknik değil, kullanıcı dostu ve sürdürülebilir çözümler üretmeye odaklanıyorum.",
                    ExtraDescription = "Misyonum, müşterilerime ihtiyaçlarına uygun, hızlı ve güvenilir yazılım çözümleri sunmaktır. Vizyonum ise, freelance yazılım geliştirme alanında global ölçekte tanınan ve tercih edilen bir çözüm ortağı olmaktır. Esnek çalışma tarzım, güncel teknolojileri yakından takip eden yaklaşımım ve müşteri odaklı bakış açımla her zaman yanınızdayım. Projelerinize değer katmak için çevik, yaratıcı ve yenilikçi yöntemler kullanıyorum.",
                    ExperienceYear = 7,
                    HappyClients = 120,
                    CompletedProjects = 85,
                    Awards = 1,
                    ImagePath = "img/about-us/default-image.jpg"
                }
            );
        }
    }
}
