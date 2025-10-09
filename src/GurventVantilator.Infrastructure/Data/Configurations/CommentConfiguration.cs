using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasData(
                new Comment { Id = 1, BlogId = 1, FullName = "Mehmet Akın", Text = "Enerji verimliliği konusunda çok bilgilendirici bir içerik, teşekkürler!", CreatedAt = new DateTime(2025, 9, 5, 9, 0, 0), IsApproved = true },
                new Comment { Id = 2, BlogId = 2, FullName = "Selin Yılmaz", Text = "ATEX hakkında net bilgiler bulmak zordu, bu makale çok yardımcı oldu.", CreatedAt = new DateTime(2025, 9, 5, 9, 0, 0), IsApproved = true },
                new Comment { Id = 3, BlogId = 3, FullName = "Ali Demirtaş", Text = "Filtrasyon sistemlerinin bu kadar etkili olabileceğini bilmiyordum.", CreatedAt = new DateTime(2025, 9, 5, 9, 0, 0), IsApproved = true }
            );
        }
    }
}
