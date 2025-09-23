using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class VisionMissionConfiguration : IEntityTypeConfiguration<VisionMission>
    {
        public void Configure(EntityTypeBuilder<VisionMission> builder)
        {
            builder.HasData(
                new VisionMission
                {
                    Id = 1,
                    VisionTitle = "Vizyonumuz",
                    VisionDescription = "Fırat Ramazano Software olarak vizyonumuz; yazılım geliştirme alanında ulusal ve uluslararası ölçekte güvenilir, yenilikçi ve tercih edilen bir teknoloji firması haline gelmektir. Amacımız, modern teknolojileri takip ederek işletmelere en güncel ve etkili çözümleri sunmak, aynı zamanda sektöre yön veren projeler geliştirmektir. Gelecek yıllarda etik değerlerden ödün vermeden sunduğumuz kaliteli hizmetlerle yazılım dünyasında öncü bir rol üstlenmek en büyük hedefimizdir.",
                    MissionTitle = "Misyonumuz",
                    MissionDescription = "Misyonumuz; işletmelerin dijital dönüşüm süreçlerinde güvenilir, ölçeklenebilir ve kullanıcı dostu yazılım çözümleri geliştirmektir. Kişiye özel yaklaşımlar, uzman ekip ve modern teknolojilerle her müşterimizin ihtiyaçlarına uygun çözümler üretiyoruz. Etik kurallar çerçevesinde sunduğumuz hizmetlerle yalnızca teknoloji geliştirmek değil, aynı zamanda iş süreçlerine değer katmayı hedefliyoruz. Müşterilerimize güven veren, şeffaf ve sürdürülebilir bir hizmet anlayışıyla uzun vadeli başarılar yaratmak en büyük önceliğimizdir.",
                    VisionImagePath = "/img/vision-mission/default-image1.jpg",
                    MissionImagePath = "/img/vision-mission/default-image2.jpg"
                }
            );
        }
    }
}
