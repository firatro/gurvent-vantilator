using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class TeamMemberConfiguration : IEntityTypeConfiguration<TeamMember>
    {
        public void Configure(EntityTypeBuilder<TeamMember> builder)
        {
            builder.HasData(
                 new TeamMember
                 {
                     Id = 1,
                     Title = "Kurucu & Genel Müdür",
                     FullName = "Gürbüz Yılmaz",
                     Biography = "Makine mühendisi olarak 30 yılı aşkın süredir endüstriyel fan tasarımı ve üretimi alanında faaliyet göstermektedir. Enerji verimli sistemler konusunda uzmandır.",
                     Phone = "+90 532 600 44 11",
                     Email = "gurbuz.yilmaz@gurvent.com.tr",
                     Website = "https://www.gurvent.com.tr",
                     Facebook = "https://facebook.com/gurventvantilator",
                     Twitter = "https://x.com/gurventfan",
                     Youtube = "https://youtube.com/@gurventvantilator",
                     Linkedin = "https://linkedin.com/in/gurbuzyilmaz",
                     Instagram = "https://instagram.com/gurventvantilator",
                     Experience = "30+ yıl endüstriyel fan üretimi ve mühendislik tecrübesi.",
                     Skills = "[\"Mekanik Tasarım\", \"Fan Mühendisliği\", \"Proje Yönetimi\", \"Üretim Süreçleri\"]",
                     ImagePath = "/img/team-member/gurbuz-yilmaz.jpg"
                 }
            );
        }
    }
}
