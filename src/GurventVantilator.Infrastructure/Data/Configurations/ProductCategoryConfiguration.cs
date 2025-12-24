// using GurventVantilator.Domain.Entities;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;

// namespace GurventVantilator.Infrastructure.Data.Configurations
// {
//     public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
//     {
//         public void Configure(EntityTypeBuilder<ProductCategory> builder)
//         {
//             // Bir kategorinin alt kategorileri olabileceğini tanımlar ve silme durumunda “cascade delete”i engeller.
//             builder.HasOne(c => c.ParentCategory)
//                 .WithMany(c => c.SubCategories)
//                 .HasForeignKey(c => c.ParentCategoryId)
//                 .OnDelete(DeleteBehavior.Restrict);

//             builder.HasData(
//                 new ProductCategory
//                 {
//                     Id = 1,
//                     Name = "Santrifuj Fanlar",
//                     ParentCategoryId = null,
//                     Order = 1,
//                     IsActive = true,
//                     CreatedAt = new DateTime(2025, 01, 01)
//                 },
//                 new ProductCategory
//                 {
//                     Id = 2,
//                     Name = "Metal Fanlar",
//                     ParentCategoryId = 1,
//                     Order = 1,
//                     IsActive = true,
//                     CreatedAt = new DateTime(2025, 01, 01)
//                 },
//                 new ProductCategory
//                 {
//                     Id = 3,
//                     Name = "Plastik Fanlar",
//                     ParentCategoryId = 1,
//                     Order = 2,
//                     IsActive = true,
//                     CreatedAt = new DateTime(2025, 01, 01)
//                 }
//             );
//         }
//     }
// }
