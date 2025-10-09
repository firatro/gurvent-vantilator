using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasData(
                new Contact
                {
                    Id = 1,
                    FullName = "Ali Korkmaz",
                    Email = "ali.korkmaz@example.com",
                    Phone = "+90 533 222 33 44",
                    Subject = "Endüstriyel fan teklifi hakkında bilgi",
                    Message = "Fabrikamız için yüksek debili santrifüj fan ihtiyacımız bulunmaktadır. Ürün kataloğu ve fiyat teklifi rica ediyorum.",
                    Notes = "Teklif gönderilecek müşteri.",
                    CreatedAt = new DateTime(2025, 9, 10, 9, 0, 0)
                }
            );
        }
    }
}
