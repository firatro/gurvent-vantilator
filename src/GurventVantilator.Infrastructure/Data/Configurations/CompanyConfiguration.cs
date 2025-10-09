using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData(
                new Company
                {
                    Id = 1,
                    Name = "Gurvent Vantilatör",
                    LogoPath = "/img/company/gurvent-logo.png"
                },
                new Company
                {
                    Id = 2,
                    Name = "VentPro Teknik",
                    LogoPath = "/img/company/ventpro-logo.png"
                },
                new Company
                {
                    Id = 3,
                    Name = "AirFlow Engineering",
                    LogoPath = "/img/company/airflow-logo.png"
                }
            );
        }
    }
}
