using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = 1, Name = "Enerji Verimliliği" },
                new Category { Id = 2, Name = "ATEX ve Güvenlik" },
                new Category { Id = 3, Name = "Filtrasyon ve Toz Kontrolü" },
                new Category { Id = 4, Name = "Havalandırma Sistemleri" },
                new Category { Id = 5, Name = "Bakım ve Servis" }
            );
        }
    }
}
