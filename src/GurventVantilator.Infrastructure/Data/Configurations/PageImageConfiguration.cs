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
                    ImagePath = "/img/page-image/aboutus-factory.jpg"
                },
                new PageImage
                {
                    Id = 2,
                    PageKey = "Contact",
                    ImageType = "Breadcrumb",
                    ImagePath = "/img/page-image/contact-office.jpg"
                },
                new PageImage
                {
                    Id = 3,
                    PageKey = "Blog",
                    ImageType = "Breadcrumb",
                    ImagePath = "/img/page-image/blog-industrial.jpg"
                },
                new PageImage
                {
                    Id = 4,
                    PageKey = "Project",
                    ImageType = "Breadcrumb",
                    ImagePath = "/img/page-image/project-site.jpg"
                },
                new PageImage
                {
                    Id = 5,
                    PageKey = "Service",
                    ImageType = "Breadcrumb",
                    ImagePath = "/img/page-image/service-production.jpg"
                },
                new PageImage
                {
                    Id = 6,
                    PageKey = "Product",
                    ImageType = "Breadcrumb",
                    ImagePath = "/img/page-image/product-line.jpg"
                },
                new PageImage
                {
                    Id = 7,
                    PageKey = "Home",
                    ImageType = "Breadcrumb",
                    ImagePath = "/img/page-image/home-header.jpg"
                }
            );
        }
    }
}
