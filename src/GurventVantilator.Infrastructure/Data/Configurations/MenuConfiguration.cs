using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasData(
                // Ana Menü Öğeleri
                new Menu
                {
                    Id = 1,
                    Title = "Ana Sayfa",
                    Slug = "anasayfa",
                    LinkType = MenuLinkType.HomePage,
                    Url = "/",
                    Order = 1,
                    IsActive = true
                },
                new Menu
                {
                    Id = 2,
                    Title = "Hakkımızda",
                    Slug = "hakkimizda",
                    LinkType = MenuLinkType.AboutUs,
                    Url = "/hakkimizda",
                    Order = 2,
                    IsActive = true
                },
                new Menu
                {
                    Id = 3,
                    Title = "Hizmetler",
                    Slug = "hizmetler",
                    LinkType = MenuLinkType.Service,
                    Url = "/hizmetler",
                    Order = 3,
                    IsActive = true
                },
                new Menu
                {
                    Id = 4,
                    Title = "Projeler",
                    Slug = "projeler",
                    LinkType = MenuLinkType.Project,
                    Url = "/projeler",
                    Order = 4,
                    IsActive = true
                },
                new Menu
                {
                    Id = 5,
                    Title = "Blog",
                    Slug = "blog",
                    LinkType = MenuLinkType.Blog,
                    Url = "/blog",
                    Order = 5,
                    IsActive = true
                },
                new Menu
                {
                    Id = 6,
                    Title = "İletişim",
                    Slug = "iletisim",
                    LinkType = MenuLinkType.Contact,
                    Url = "/iletisim",
                    Order = 6,
                    IsActive = true
                },

                // Alt Menü Öğeleri (Hizmetler altında)
                new Menu
                {
                    Id = 7,
                    Title = "Web Projeleri",
                    Slug = "web",
                    LinkType = MenuLinkType.Service,
                    Url = "/hizmetler/web",
                    ServiceId = 1,
                    ParentId = 3,
                    Order = 1,
                    IsActive = true
                },
                new Menu
                {
                    Id = 8,
                    Title = "Mobil Uygulamalar",
                    Slug = "mobil",
                    LinkType = MenuLinkType.Service,
                    Url = "/hizmetler/mobil",
                    ServiceId = 2,
                    ParentId = 3,
                    Order = 2,
                    IsActive = true
                },
                new Menu
                {
                    Id = 9,
                    Title = "Masaüstü Yazılım",
                    Slug = "masaustu-yazilim",
                    LinkType = MenuLinkType.Service,
                    Url = "/hizmetler/dudak-dolgusu",
                    ServiceId = 3,
                    ParentId = 3,
                    Order = 3,
                    IsActive = true
                },
                new Menu
                {
                    Id = 10,
                    Title = "E-Ticaret",
                    Slug = "e-ticaret",
                    LinkType = MenuLinkType.Service,
                    Url = "/hizmetler/e-ticaret",
                    ServiceId = 4,
                    ParentId = 3,
                    Order = 4,
                    IsActive = true
                },
                new Menu
                {
                    Id = 11,
                    Title = "SEO Çalışması",
                    Slug = "seo",
                    LinkType = MenuLinkType.Service,
                    Url = "/hizmetler/seo",
                    ServiceId = 4,
                    ParentId = 3,
                    Order = 4,
                    IsActive = true
                }
            );
        }
    }
}
