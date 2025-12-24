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
                new Menu { Id = 1, Title = "Ana Sayfa", Slug = "anasayfa", LinkType = MenuLinkType.HomePage, Url = "/", Order = 1, IsActive = true },
                new Menu { Id = 2, Title = "Kurumsal", Slug = "hakkimizda", LinkType = MenuLinkType.AboutUs, Url = "/hakkimizda", Order = 2, IsActive = true },
                new Menu { Id = 3, Title = "Ürünler", Slug = "urunler", LinkType = MenuLinkType.ProductCategory, Url = "/urunler", Order = 3, IsActive = true },
                new Menu { Id = 7, Title = "İletişim", Slug = "iletisim", LinkType = MenuLinkType.Contact, Url = "/iletisim", Order = 7, IsActive = true },
                new Menu { Id = 8, Title = "Konfigüratör", Slug = "konfigurator", LinkType = MenuLinkType.FanSelector, Url = "/fanselector", Order = 8, IsActive = true }
            );
        }
    }
}
