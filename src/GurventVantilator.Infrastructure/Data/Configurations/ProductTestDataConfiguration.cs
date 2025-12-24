using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProductTestDataConfiguration
    : IEntityTypeConfiguration<ProductTestData>
{
    public void Configure(EntityTypeBuilder<ProductTestData> builder)
    {
        builder.ToTable("ProductTestDatas");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.TestName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Diameter)
            .HasPrecision(10, 2);

        builder.Property(x => x.SourceFileName)
            .HasMaxLength(255);

        // ===== SANAL / META DEĞERLER =====
        builder.Property(x => x.Ps).HasPrecision(10, 2);
        builder.Property(x => x.Pd).HasPrecision(10, 2);
        builder.Property(x => x.Current).HasPrecision(10, 2);
        builder.Property(x => x.Pt).HasPrecision(10, 2);
        builder.Property(x => x.Speed).HasPrecision(10, 2);
        builder.Property(x => x.Q).HasPrecision(10, 2);

        builder.Property(x => x.AirPower).HasPrecision(10, 2);
        builder.Property(x => x.CalculatedPower).HasPrecision(10, 2);

        builder.Property(x => x.TotalEfficiency).HasPrecision(5, 2);
        builder.Property(x => x.MechanicalEfficiency).HasPrecision(5, 2);

        builder.Property(x => x.IsActive)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        // 🔗 Product (1) → TestData (N)
        builder.HasOne(x => x.Product)
            .WithMany(x => x.TestData)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        // 🔗 TestData → TestPoints
        builder.HasMany(x => x.Points)
            .WithOne(x => x.ProductTestData)
            .HasForeignKey(x => x.ProductTestDataId)
            .OnDelete(DeleteBehavior.Cascade);

        // ⚠️ Performans
        builder.HasIndex(x => new { x.ProductId, x.IsActive });
    }
}
