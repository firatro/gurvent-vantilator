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
                    Phone1 = "+90 232 400 55 22",
                    Phone2 = "+90 532 600 44 11",
                    Fax1 = "+90 232 400 55 23",
                    Fax2 = null,
                    WaNumber = "+90 532 600 44 11",
                    TNumber = "+90 532 600 44 11",
                    Email1 = "info@gurvent.com.tr",
                    Email2 = "teknik@gurvent.com.tr",
                    SiteName = "Gurvent Vantilatör",
                    SiteOwner = "Gurvent Mühendislik A.Ş.",
                    SiteInformation = "Gurvent, endüstriyel fan ve havalandırma sistemleri alanında yenilikçi, enerji verimli ve yüksek performanslı çözümler sunar.",
                    CompanyName = "Gurvent Vantilatör ve Mühendislik A.Ş.",
                    CompanyOwner = "Gürbüz Teknik",
                    GoogleMapsApi = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3000.458293!2d27.133!3d38.435!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14b970a6d8!2sGurvent%20Vantilatör!5e0!3m2!1str!2str!4v1712345678901!5m2!1str!2str",
                    Address = "Atatürk Organize Sanayi Bölgesi, 10032 Sokak No:15, Çiğli / İzmir",
                    WorkingHours = "Hafta içi: 08:30 - 18:00, Cumartesi: 08:30 - 13:00",
                    TaxNumber = "4567891230",
                    TaxOffice = "İzmir Vergi Dairesi",
                    LogoPath = "/img/site-info/gurvent-logo.png"
                }
            );
        }
    }
}
