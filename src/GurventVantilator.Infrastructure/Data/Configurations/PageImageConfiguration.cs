
using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class PageImageConfiguration : IEntityTypeConfiguration<PageImage>
    {
        public void Configure(EntityTypeBuilder<PageImage> builder)
        {
            builder.HasData(
                new PageImage
                {
                    Id = 1,
                    PageKey = "AboutUs",
                    ImageType = "Breadcrumb",
                    ImagePath = "img/page-image/default-image.jpg"
                },
                new PageImage
                {
                    Id = 2,
                    PageKey = "Contact",
                    ImageType = "Breadcrumb",
                    ImagePath = "img/page-image/default-image.jpg"
                },
                new PageImage
                {
                    Id = 3,
                    PageKey = "Blog",
                    ImageType = "Breadcrumb",
                    ImagePath = "img/page-image/default-image.jpg"
                },
                new PageImage
                {
                    Id = 4,
                    PageKey = "Project",
                    ImageType = "Breadcrumb",
                    ImagePath = "img/page-image/default-image.jpg"
                },
                new PageImage
                {
                    Id = 5,
                    PageKey = "Service",
                    ImageType = "Breadcrumb",
                    ImagePath = "img/page-image/default-image.jpg"
                },
                new PageImage
                {
                    Id = 6,
                    PageKey = "Page",
                    ImageType = "Breadcrumb",
                    ImagePath = "img/page-image/default-image.jpg"
                }
            );
        }
    }
}