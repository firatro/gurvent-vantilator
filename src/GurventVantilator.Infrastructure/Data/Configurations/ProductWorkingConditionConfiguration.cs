using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class ProductWorkingConditionConfiguration : IEntityTypeConfiguration<ProductWorkingCondition>
    {
        public void Configure(EntityTypeBuilder<ProductWorkingCondition> builder)
        {
            builder.ToTable("ProductWorkingConditions");

            builder.HasKey(w => w.Id);

            builder.Property(w => w.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(w => w.Description)
                .HasMaxLength(300);

            // 🔹 Many-to-Many ilişki
            builder.HasMany(w => w.Products)
                   .WithMany(p => p.WorkingConditions)
                   .UsingEntity(j => j.ToTable("ProductWorkingConditionProducts"));
        }
    }
}
