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
                     Title = "Kurucu & CEO",
                     FullName = "Fırat Ramazano",
                     Biography = "15 yılı aşkın süredir yazılım geliştirme ve teknoloji girişimciliği alanında deneyime sahip. Modern yazılım mimarileri, yapay zeka ve bulut tabanlı çözümler konusunda uzman.",
                     Phone = "+90-532-111-2233",
                     Email = "firat.ramazano@company.com",
                     Website = "https://www.firatramazano.com",
                     Facebook = "https://facebook.com/firatro",
                     Twitter = "https://twitter.com/_firatro",
                     Youtube = "https://youtube.com/@firatro",
                     Linkedin = "https://linkedin.com/in/firatro",
                     Instagram = "https://instagram.com/firatro",
                     Experience = "15+ yıl yazılım geliştirme, girişimcilik ve uluslararası teknoloji konferanslarında konuşmacı.",
                     Skills = "[\"Liderlik\", \"Yazılım Mimarisi\", \"İş Stratejisi\", \"Bulut Teknolojileri\"]",
                     ImagePath = "/img/team-member/default-image1.jpg"
                 }
            );
        }
    }
}
