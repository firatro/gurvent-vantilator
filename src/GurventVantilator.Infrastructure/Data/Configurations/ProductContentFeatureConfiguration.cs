using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class ProductContentFeatureConfiguration : IEntityTypeConfiguration<ProductContentFeature>
    {
        public void Configure(EntityTypeBuilder<ProductContentFeature> builder)
        {
            builder.ToTable("ProductContentFeatures");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Key)
                   .HasMaxLength(150)
                   .IsRequired();

            builder.Property(x => x.Value)
                   .HasMaxLength(500)
                   .IsRequired();

            builder.HasOne(x => x.Product)
                   .WithMany(p => p.ContentFeatures)
                   .HasForeignKey(x => x.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            // 🔹 Seed Data
            builder.HasData(
                // --- RSD25 ---
                new ProductContentFeature { Id = 1, ProductId = 1, Key = "Fan Tipi", Value = "Santrifüj Geriye Eğik Kanatlı", Order = 1 },
                new ProductContentFeature { Id = 2, ProductId = 1, Key = "Gövde Yapısı", Value = "Galvaniz kaplama çelik gövde", Order = 2 },
                new ProductContentFeature { Id = 3, ProductId = 1, Key = "Motor Tipi", Value = "Direk akuple, 80°C sürekli çalışma", Order = 3 },

                // --- RSD 22P2 ---
                new ProductContentFeature { Id = 4, ProductId = 2, Key = "Fan Tipi", Value = "Geriye eğik seyrek aerofoil kanatlı", Order = 1 },
                new ProductContentFeature { Id = 5, ProductId = 2, Key = "Malzeme", Value = "Alüminyum pervane, çelik gövde", Order = 2 },
                new ProductContentFeature { Id = 6, ProductId = 2, Key = "Kullanım Alanı", Value = "Havalandırma ve soğutma sistemleri", Order = 3 },

                // --- RSD 20B2 ---
                new ProductContentFeature { Id = 7, ProductId = 3, Key = "Fan Tipi", Value = "Tek emişli santrifüj fan", Order = 1 },
                new ProductContentFeature { Id = 8, ProductId = 3, Key = "Montaj Açısı", Value = "4 farklı açıda çalışmaya uygun (90°,180°,270°,360°)", Order = 2 },
                new ProductContentFeature { Id = 9, ProductId = 3, Key = "Verimlilik", Value = "Yüksek statik basınç ve düşük gürültü", Order = 3 },

                // --- RSD 18B2 ---
                new ProductContentFeature { Id = 10, ProductId = 4, Key = "Fan Tipi", Value = "Geriye eğik seyrek aerofoil kanatlı", Order = 1 },
                new ProductContentFeature { Id = 11, ProductId = 4, Key = "Motor Sınıfı", Value = "IP55 koruma sınıfı, IE2 verimlilik", Order = 2 },
                new ProductContentFeature { Id = 12, ProductId = 4, Key = "Uygulama", Value = "Hafif hizmet tipi sanayi havalandırması", Order = 3 }
            );
        }
    }
}
