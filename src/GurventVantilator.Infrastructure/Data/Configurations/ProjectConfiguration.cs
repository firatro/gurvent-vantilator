using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasData(
                new Project
                {
                    Id = 1,
                    MainImagePath = "/img/project/factory1.jpg",
                    ContentImage1Path = "/img/project/factory2.jpg",
                    ContentImage2Path = "/img/project/factory3.jpg",
                    Title = "Otomotiv Fabrikası Havalandırma Projesi",
                    Subtitle = "Santrifüj Fan Sistemleri",
                    IntroText = "Fabrikanın üretim alanları için yüksek debili, düşük ses seviyeli santrifüj fanlar tasarlandı.",
                    Description = "Toplam 24 adet endüstriyel fan üretimi, montajı ve devreye alma süreci 45 gün içinde tamamlandı. Sistem, otomasyon paneline entegre çalışmaktadır.",
                    CustomerInfo = "XYZ Otomotiv A.Ş.",
                    ExtraTitle = "Enerji Verimliliği",
                    ExtraDescription = "Yeni sistem sayesinde enerji tüketiminde %18 tasarruf sağlandı.",
                    ProjectDate = new DateTime(2024, 5, 10),
                    CreatedAt = new DateTime(2025, 9, 5)
                },
                new Project
                {
                    Id = 2,
                    MainImagePath = "/img/project/hospital1.jpg",
                    ContentImage1Path = "/img/project/hospital2.jpg",
                    ContentImage2Path = "/img/project/hospital3.jpg",
                    Title = "Hastane Ameliyathane Havalandırma Projesi",
                    Subtitle = "Hijyenik Aksiyel Fan Sistemleri",
                    IntroText = "Steril ortamlarda kullanılmak üzere özel filtreli ve sessiz aksiyel fanlar tasarlandı.",
                    Description = "HEPA filtreli havalandırma sistemi ile temiz hava sirkülasyonu sağlanarak uluslararası standartlara uygun hale getirildi.",
                    CustomerInfo = "Sağlık Grup Hastanesi",
                    ExtraTitle = "Sessiz ve Güvenli Çalışma",
                    ExtraDescription = "Fanlar 24 saat kesintisiz çalışmada dahi düşük gürültü seviyesini koruyor.",
                    ProjectDate = new DateTime(2023, 11, 20),
                    CreatedAt = new DateTime(2025, 9, 5)
                },
                new Project
                {
                    Id = 3,
                    MainImagePath = "/img/project/mine1.jpg",
                    ContentImage1Path = "/img/project/mine2.jpg",
                    ContentImage2Path = "/img/project/mine3.jpg",
                    Title = "Maden Ocağı Hava Sirkülasyon Sistemi",
                    Subtitle = "Patlamaya Dayanıklı Fan Çözümü",
                    IntroText = "Zorlu çalışma koşullarında güvenli hava dolaşımı sağlamak için ATEX sertifikalı fanlar üretildi.",
                    Description = "Fanlar yüksek toz, nem ve sıcaklık koşullarına dayanıklı olacak şekilde özel malzemelerden imal edilmiştir.",
                    CustomerInfo = "Delta Madencilik Ltd.",
                    ExtraTitle = "ATEX Güvenliği",
                    ExtraDescription = "Sistem uluslararası patlama koruma standartlarına uygun şekilde devreye alınmıştır.",
                    ProjectDate = new DateTime(2023, 9, 15),
                    CreatedAt = new DateTime(2025, 9, 5)
                }
            );
        }
    }
}
