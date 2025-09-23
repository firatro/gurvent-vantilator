using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class SiteInfoConfiguration : IEntityTypeConfiguration<SiteInfo>
    {
        public void Configure(EntityTypeBuilder<SiteInfo> builder)
        {
            builder.HasData(
                new SiteInfo
                {
                    Id = 1,
                    Phone1 = "+90 535 630 5220",
                    Phone2 = "+90 232 000 0000",
                    Fax1 = "+90 232 000 0000",
                    Fax2 = "+90 232 000 0000",
                    WaNumber = "+90 535 630 5220",
                    TNumber = "+90 535 630 5220",
                    Email1 = "info@firatramazano.com",
                    Email2 = "firatro@outlook.com",
                    SiteName = "Fırat Ramazano",
                    SiteOwner = "Fırat Ramazano",
                    SiteInformation = "Modern teknolojileri yenilikçi yazılım çözümleriyle buluşturur. İşletmelerin dijital dönüşümünü hızlandırırken güvenilir, ölçeklenebilir ve kullanıcı dostu uygulamalar geliştirir.",
                    CompanyName = "Fırat Ramazano",
                    CompanyOwner = "Fırat Ramazano",
                    GoogleMapsApi = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d380.50129495713793!2d28.977997042359917!3d41.00806685326879!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14caa7040068086b%3A0xe1ccfe98bc01b0d0!2zxLBzdGFuYnVs!5e0!3m2!1str!2str!4v1758490039045!5m2!1str!2str",
                    Address = "Demirköprü Mah. Karşıyaka/İstanbul.",
                    WorkingHours = "Hafta içi: 09:00 - 18:00",
                    TaxNumber = "1234567890",
                    TaxOffice = "İzmir Vergi Dairesi",
                    LogoPath = "/img/site-info/logo.png"
                }
            );
        }
    }
}
