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
                    Name = "Promed Clinic",
                    LogoPath = "img/company/default-image.png"
                },
                new Company
                {
                    Id = 2,
                    Name = "Gürvent Vantilatör",
                    LogoPath = "img/company/default-image.png"
                }
            );
        }
    }
}
