using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProductModelDocumentConfiguration : IEntityTypeConfiguration<ProductModelDocument>
{
    public void Configure(EntityTypeBuilder<ProductModelDocument> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.ProductModel)
            .WithMany(x => x.Documents)
            .HasForeignKey(x => x.ProductModelId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
        builder.Property(x => x.FilePath).IsRequired();
    }
}
