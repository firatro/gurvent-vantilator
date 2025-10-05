using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GurventVantilator.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSet'ler
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceFeature> ServiceFeatures { get; set; }
        public DbSet<ServiceFaq> ServiceFaqs { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectFeature> ProjectFeatures { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<SiteInfo> SiteInfo { get; set; }
        public DbSet<SocialMediaInfo> SocialMediaInfo { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<VisionMission> VisionMission { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BlogTag> BlogTags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<BeforeAfter> BeforeAfters { get; set; }
        public DbSet<SeoSetting> SeoSettings { get; set; }
        public DbSet<ChatBotQA> ChatBotQAs { get; set; }
        public DbSet<PageImage> PageImages { get; set; }
        public DbSet<VersionInfo> VersionInfos { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);

            // Service - Feature ilişki ayarı
            modelBuilder.Entity<Service>()
                .HasMany(s => s.Features)
                .WithOne(f => f.Service)
                .HasForeignKey(f => f.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            // Service - Faq ilişki ayarı
            modelBuilder.Entity<Service>()
                .HasMany(s => s.Faqs)
                .WithOne(f => f.Service)
                .HasForeignKey(f => f.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            // BlogTag (N:N) composite key
            modelBuilder.Entity<BlogTag>()
                .HasKey(bt => new { bt.BlogId, bt.TagId });

            modelBuilder.Entity<BlogTag>()
                .HasOne(bt => bt.Blog)
                .WithMany(b => b.BlogTags)
                .HasForeignKey(bt => bt.BlogId);

            modelBuilder.Entity<BlogTag>()
                .HasOne(bt => bt.Tag)
                .WithMany(t => t.BlogTags)
                .HasForeignKey(bt => bt.TagId);

            // Blog -> Category (1:N)
            modelBuilder.Entity<Blog>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Blogs)
                .HasForeignKey(b => b.CategoryId);

            // Blog -> Comment (1:N)
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Blog)
                .WithMany(b => b.Comments)
                .HasForeignKey(c => c.BlogId);

            modelBuilder.Entity<Menu>()
                .HasOne(m => m.Parent)
                .WithMany(m => m.Children)
                .HasForeignKey(m => m.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
