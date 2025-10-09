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
                    VisionDescription = "Enerji verimliliği yüksek, çevreye duyarlı fan sistemleriyle Türkiye’nin ve dünyanın lider havalandırma çözümleri üreticisi olmak.",
                    MissionTitle = "Misyonumuz",
                    MissionDescription = "Müşterilerimize güvenilir, yenilikçi ve mühendislik odaklı havalandırma çözümleri sunmak; üretim kalitemizi sürekli geliştirerek endüstriye değer katmak.",
                    VisionImagePath = "/img/vision-mission/factory-vision.jpg",
                    MissionImagePath = "/img/vision-mission/factory-mission.jpg"
                }
            );
        }
    }
}
