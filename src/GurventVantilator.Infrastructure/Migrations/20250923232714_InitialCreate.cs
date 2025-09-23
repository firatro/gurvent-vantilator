using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GurventVantilator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExtraTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExtraDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YoutubeVideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExperienceYear = table.Column<int>(type: "int", nullable: false),
                    HappyClients = table.Column<int>(type: "int", nullable: false),
                    CompletedProjects = table.Column<int>(type: "int", nullable: false),
                    Awards = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeforeAfters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeforeImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AfterImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeforeAfters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatBotQAs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatBotQAs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faqs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faqs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkType = table.Column<int>(type: "int", nullable: false),
                    ContentHtml = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    BlogId = table.Column<int>(type: "int", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_Menus_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PageImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntroText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentImage1Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentImage2Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeoSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultMetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultMetaKeywords = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultOgImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RobotsTxtContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoogleAnalyticsId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoogleTagManagerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacebookPixelId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeoSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentImage1Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentImage2Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiteInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiteOwner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyOwner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoogleMapsApi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkingHours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxOffice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WaNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialMediaInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Youtube = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    X = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tiktok = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMediaInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Youtube = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Linkedin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skills = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Testimonials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VersionInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VersionNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VersionInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VisionMission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MissionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MissionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisionImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MissionImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisionMission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntryTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntryDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExtraTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuoteSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentImage1Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentImage2Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YoutubeVideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectFeatures_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceFaqs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceFaqs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceFaqs_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceFeatures_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogTags",
                columns: table => new
                {
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogTags", x => new { x.BlogId, x.TagId });
                    table.ForeignKey(
                        name: "FK_BlogTags_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AboutUs",
                columns: new[] { "Id", "Awards", "CompletedProjects", "Description", "ExperienceYear", "ExtraDescription", "ExtraTitle", "HappyClients", "ImagePath", "Title", "YoutubeVideoUrl" },
                values: new object[] { 1, 1, 85, "Yazılım geliştirme alanında freelance olarak uzun süredir hizmet veriyorum. Amacım yalnızca kod yazmak değil, her müşterime özel, esnek ve yenilikçi çözümler üretmektir. Bugüne kadar farklı sektörlerden bireyler ve işletmeler için web, mobil ve özel yazılım projeleri geliştirdim. Projelerde sadece teknik değil, kullanıcı dostu ve sürdürülebilir çözümler üretmeye odaklanıyorum.", 7, "Misyonum, müşterilerime ihtiyaçlarına uygun, hızlı ve güvenilir yazılım çözümleri sunmaktır. Vizyonum ise, freelance yazılım geliştirme alanında global ölçekte tanınan ve tercih edilen bir çözüm ortağı olmaktır. Esnek çalışma tarzım, güncel teknolojileri yakından takip eden yaklaşımım ve müşteri odaklı bakış açımla her zaman yanınızdayım. Projelerinize değer katmak için çevik, yaratıcı ve yenilikçi yöntemler kullanıyorum.", "Özgür Ruh, Yaratıcı Çözümler", 120, "img/about-us/default-image.jpg", "Ben Kimim?", null });

            migrationBuilder.InsertData(
                table: "BeforeAfters",
                columns: new[] { "Id", "AfterImagePath", "BeforeImagePath", "Description", "Subtitle", "Title" },
                values: new object[,]
                {
                    { 1, "img/before-after/default-image2.jpg", "img/before-after/default-image1.jpg", "Müşterimizin mevcut web sitesi, güncel tasarım trendleri ve kullanıcı deneyimi ilkeleri doğrultusunda yeniden tasarlandı. Yeni sürümde hız, mobil uyumluluk ve SEO performansı artırıldı.", "Modern ve Kullanıcı Dostu Arayüz", "Web Sitesi Yenileme Sonuçları" },
                    { 2, "img/before-after/default-image4.jpg", "img/before-after/default-image3.jpg", "Eski mobil uygulama, modern UI/UX prensipleriyle baştan tasarlandı. Yeni versiyonda performans iyileştirmeleri, sadeleştirilmiş arayüz ve gelişmiş kullanıcı deneyimi sunuldu.", "Hızlı, Şık ve Kullanıcı Odaklı", "Mobil Uygulama Dönüşümü" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Genel" },
                    { 2, "Yapay Zeka" },
                    { 3, "Mobil Geliştirme" },
                    { 4, "Siber Güvenlik" },
                    { 5, "Bulut ve DevOps" },
                    { 6, "Tasarım Kalıpları" }
                });

            migrationBuilder.InsertData(
                table: "ChatBotQAs",
                columns: new[] { "Id", "Answer", "IsActive", "LanguageCode", "Question" },
                values: new object[,]
                {
                    { 1, "Merhaba, size nasıl yardımcı olabilirim?", true, "tr", "Merhaba" },
                    { 2, "Randevu almak için iletişim sayfamızdan form doldurabilir veya bizi arayabilirsiniz.", true, "tr", "Randevu almak istiyorum" },
                    { 3, "Hello, how can I help you?", true, "en", "Hello" },
                    { 4, "You can book an appointment via our contact page or by calling us.", true, "en", "I want to make an appointment" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "LogoPath", "Name" },
                values: new object[,]
                {
                    { 1, "img/company/default-image.png", "Promed Clinic" },
                    { 2, "img/company/default-image.png", "Gürvent Vantilatör" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "Message", "Notes", "Phone", "Subject" },
                values: new object[] { 1, new DateTime(2025, 9, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), "ahmet.yilmaz@example.com", "Ahmet Yılmaz", "Merhaba, web tabanlı bir proje geliştirmeyi planlıyorum. Proje süresi, teknoloji seçimi ve maliyetlendirme hakkında detaylı bilgi verebilir misiniz?", "İlk kez iletişime geçti.", "+90 532 111 22 33", "Yazılım geliştirme hizmetleri hakkında bilgi" });

            migrationBuilder.InsertData(
                table: "Faqs",
                columns: new[] { "Id", "Answer", "CreatedAt", "Question" },
                values: new object[,]
                {
                    { 1, "Web ve mobil uygulama geliştirme, yapay zeka çözümleri, siber güvenlik danışmanlığı, bulut ve DevOps hizmetleri, yazılım bakım ve destek hizmetleri sunuyoruz.", new DateTime(2025, 9, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Hangi hizmetleri sunuyorsunuz?" },
                    { 2, "Web sitemizdeki iletişim formunu doldurarak veya doğrudan bize e-posta/telefon yoluyla ulaşarak proje talebinizi iletebilirsiniz.", new DateTime(2025, 9, 5, 9, 10, 0, 0, DateTimeKind.Unspecified), "Nasıl proje talebi oluşturabilirim?" },
                    { 3, "Evet, tüm proje süreçlerimizi online toplantılarla yönetebiliyor ve müşterilerimizle uzaktan iş birliği yapabiliyoruz.", new DateTime(2025, 9, 5, 9, 20, 0, 0, DateTimeKind.Unspecified), "Uzaktan çalışma veya online toplantı imkanınız var mı?" },
                    { 4, "Projenin kapsamına bağlıdır. Küçük projeler ortalama 1-2 ay, orta ölçekli projeler 3-6 ay, büyük ölçekli projeler ise daha uzun sürede tamamlanabilmektedir.", new DateTime(2025, 9, 5, 9, 30, 0, 0, DateTimeKind.Unspecified), "Bir yazılım projesi ne kadar sürede tamamlanır?" },
                    { 5, "İhtiyaç analizi, tasarım, geliştirme, test ve yayınlama aşamalarından oluşmaktadır. Ayrıca yayın sonrası bakım ve destek de sağlıyoruz.", new DateTime(2025, 9, 5, 9, 40, 0, 0, DateTimeKind.Unspecified), "Mobil uygulama geliştirme süreci nasıl ilerliyor?" },
                    { 6, "Evet, projeler tamamlandıktan sonra güncelleme, hata düzeltme ve performans optimizasyonu için destek ve bakım hizmeti sunuyoruz.", new DateTime(2025, 9, 5, 9, 50, 0, 0, DateTimeKind.Unspecified), "Destek ve bakım hizmeti veriyor musunuz?" },
                    { 7, "Evet, veri analizi, öneri sistemleri, doğal dil işleme ve görüntü işleme alanlarında yapay zeka çözümleri sunuyoruz.", new DateTime(2025, 9, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), "Yapay zeka ve makine öğrenmesi çözümleri geliştiriyor musunuz?" },
                    { 8, "AWS, Azure ve Google Cloud üzerinde ölçeklenebilir ve güvenilir bulut çözümleri geliştiriyoruz.", new DateTime(2025, 9, 5, 10, 10, 0, 0, DateTimeKind.Unspecified), "Bulut çözümleriniz hangi platformlarda?" },
                    { 9, "Penetrasyon testleri, güvenlik açığı analizi, ağ güvenliği, Zero Trust mimarisi danışmanlığı ve güvenlik farkındalık eğitimleri sunuyoruz.", new DateTime(2025, 9, 5, 10, 20, 0, 0, DateTimeKind.Unspecified), "Siber güvenlik hizmetleriniz neleri kapsıyor?" },
                    { 10, "Tüm projelerimiz güvenlik standartlarına uygun geliştirilmekte, düzenli testlerden geçirilmekte ve uluslararası en iyi uygulamalar temel alınmaktadır.", new DateTime(2025, 9, 5, 10, 30, 0, 0, DateTimeKind.Unspecified), "Projeleriniz güvenli midir?" }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "BlogId", "ContentHtml", "IsActive", "LinkType", "Order", "ParentId", "ProjectId", "ServiceId", "Slug", "Title", "Url" },
                values: new object[,]
                {
                    { 1, null, null, true, 6, 1, null, null, null, "anasayfa", "Ana Sayfa", "/" },
                    { 2, null, null, true, 5, 2, null, null, null, "hakkimizda", "Hakkımızda", "/hakkimizda" },
                    { 3, null, null, true, 1, 3, null, null, null, "hizmetler", "Hizmetler", "/hizmetler" },
                    { 4, null, null, true, 2, 4, null, null, null, "projeler", "Projeler", "/projeler" },
                    { 5, null, null, true, 3, 5, null, null, null, "blog", "Blog", "/blog" },
                    { 6, null, null, true, 4, 6, null, null, null, "iletisim", "İletişim", "/iletisim" }
                });

            migrationBuilder.InsertData(
                table: "PageImages",
                columns: new[] { "Id", "ImagePath", "ImageType", "PageKey" },
                values: new object[,]
                {
                    { 1, "img/page-image/default-image.jpg", "Breadcrumb", "AboutUs" },
                    { 2, "img/page-image/default-image.jpg", "Breadcrumb", "Contact" },
                    { 3, "img/page-image/default-image.jpg", "Breadcrumb", "Blog" },
                    { 4, "img/page-image/default-image.jpg", "Breadcrumb", "Project" },
                    { 5, "img/page-image/default-image.jpg", "Breadcrumb", "Service" },
                    { 6, "img/page-image/default-image.jpg", "Breadcrumb", "Page" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "ContentImage1Path", "ContentImage2Path", "CreatedAt", "CustomerInfo", "Description", "ExtraDescription", "ExtraTitle", "IntroText", "MainImagePath", "ProjectDate", "Subtitle", "Title" },
                values: new object[,]
                {
                    { 1, "/img/project/default-image2.jpg", "/img/project/default-image3.jpg", new DateTime(2025, 9, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Elif Yılmaz", "E-ticaret projesinde React tabanlı modern bir frontend, .NET Core tabanlı güçlü bir backend ve MSSQL veritabanı kullanıldı. Projede mikroservis mimarisi tercih edilerek ölçeklenebilirlik sağlandı. Ayrıca kullanıcı deneyimi için dinamik filtreleme, ürün öneri sistemi ve güvenli ödeme entegrasyonu geliştirildi. Bulut tabanlı dağıtım sayesinde sistem performansı ve güvenliği üst seviyeye çıkarıldı.", "Proje tamamlandıktan sonra CI/CD süreçleriyle canlıya alındı. Müşteriye eğitim verildi ve bakım-destek süreci başlatıldı. Kullanıcı geri bildirimlerine göre düzenli güncellemeler yapılmaktadır.", "Canlıya Alım ve Destek", "Proje başlangıcında müşterinin ihtiyaçları, hedef kitlesi ve iş modeli detaylı şekilde analiz edilerek yazılım mimarisi planlandı. Kullanıcı dostu arayüz, güvenli ödeme altyapısı ve hızlı ürün yönetimi ön planda tutuldu.", "/img/project/default-image1.jpg", new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ölçeklenebilir Web Uygulaması", "E-Ticaret Platformu" },
                    { 2, "/img/project/default-image5.jpg", "/img/project/default-image6.jpg", new DateTime(2025, 9, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Zeynep Kaya", "Flutter kullanılarak hem iOS hem Android platformlarında çalışan mobil uygulama geliştirildi. Uygulamada para transferi, fatura ödeme, QR ile işlem ve anlık bildirim gibi özellikler yer aldı. Güvenlik için çift faktörlü kimlik doğrulama ve SSL şifreleme entegre edildi. Backend kısmında .NET Core API kullanıldı ve yüksek trafik altında sorunsuz çalışması için bulut tabanlı servisler tercih edildi.", "Uygulama, farklı cihazlarda kapsamlı testlerden geçirildi. Yayın sürecinde App Store ve Google Play standartlarına uygun hale getirildi. Yayın sonrası müşteri destek ekibiyle birlikte kullanıcı geri bildirimleri sürekli olarak değerlendirilmektedir.", "Test ve Yayınlama", "Proje öncesinde müşterinin mevcut bankacılık altyapısı incelendi ve güvenlik, performans ve kullanıcı deneyimi açısından ihtiyaçlar belirlendi. Kullanıcıların hızlı ve güvenli bir şekilde finansal işlemler yapabilmesi hedeflendi.", "/img/project/default-image4.jpg", new DateTime(2023, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "iOS ve Android için Cross-Platform Çözüm", "Mobil Bankacılık Uygulaması" },
                    { 3, "/img/project/default-image8.jpg", "/img/project/default-image9.jpg", new DateTime(2025, 9, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Derya Demir", "Proje kapsamında .NET Core ile geliştirilen güçlü bir backend ve Angular tabanlı modern bir frontend tasarlandı. CRM sistemi; müşteri segmentasyonu, otomatik görev atamaları ve e-posta entegrasyonu özelliklerini içeriyor. Yapay zeka destekli tahminleme modülü sayesinde satış fırsatları önceden öngörülerek ekiplerin stratejileri optimize edildi.", "Sistem devreye alındıktan sonra satış ekibinin verimliliğinde %35 artış gözlemlendi. Düzenli güncellemelerle yeni özellikler eklenmeye devam ediliyor. Müşteri, uzun vadeli destek paketimizden faydalanıyor.", "Uygulama Sonrası", "Proje öncesinde satış ekiplerinin ihtiyaçları analiz edildi. Müşteri verilerinin daha verimli yönetilmesi, satış süreçlerinin hızlanması ve yapay zeka destekli tahminleme hedeflendi.", "/img/project/default-image7.jpg", new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Müşteri İlişkileri Yönetiminde Akıllı Çözümler", "Yapay Zeka Destekli CRM Sistemi" }
                });

            migrationBuilder.InsertData(
                table: "SeoSettings",
                columns: new[] { "Id", "DefaultMetaDescription", "DefaultMetaKeywords", "DefaultOgImagePath", "DefaultTitle", "FacebookPixelId", "GoogleAnalyticsId", "GoogleTagManagerId", "RobotsTxtContent", "SiteName" },
                values: new object[] { 1, "Fırat Ramazano, modern web, mobil ve yapay zeka tabanlı yazılım çözümleri geliştirir. Güvenli, ölçeklenebilir ve kullanıcı dostu uygulamalar için profesyonel destek sunar.", "yazılım geliştirme, web uygulamaları, mobil uygulama, yapay zeka, siber güvenlik, bulut, devops, firat ramazano", "/img/seo-setting/default-image.jpg", "Fırat Ramazano | Yazılım Geliştirme ve Teknoloji Çözümleri", "1234567890", "G-XXXXXXX", "GTM-XXXXXXX", "User-agent: *\nAllow: /", "Fırat Ramazano Software" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "ContentImage1Path", "ContentImage2Path", "Description", "ExtraDescription", "ExtraTitle", "LogoPath", "MainImagePath", "Name", "Title" },
                values: new object[,]
                {
                    { 1, "/img/service/default-image2.jpg", "/img/service/default-image3.jpg", "Web uygulama geliştirme, işletmelerin dijital dönüşüm süreçlerinde en önemli adımlardan biridir. .NET Core, Node.js ve modern frontend teknolojileri (React, Angular, Vue) kullanılarak geliştirilen web uygulamaları; güvenli, ölçeklenebilir ve kullanıcı dostu çözümler sunar. E-ticaret, CRM, ERP ve kurumsal portallar başta olmak üzere birçok alanda modern web çözümleri geliştiriyoruz. Tüm projelerimizde yüksek performans, güvenlik ve kullanıcı deneyimini önceliklendiriyoruz.", "Projelerimizde çevik (Agile) metodolojiler kullanarak müşterilerimizle sürekli iletişim halinde çalışıyoruz. Her aşamada şeffaflık ve kalite kontrolü sağlıyor, test odaklı geliştirme (TDD) ve otomasyon süreçleri ile hatasız ve sürdürülebilir çözümler üretiyoruz. Bu sayede müşterilerimiz, hızlı, güvenli ve uzun vadeli yazılım yatırımlarına sahip oluyor.", "Profesyonel Yazılım Geliştirme Yaklaşımı", "/img/service/default-image4.png", "/img/service/default-image1.jpg", "Web Uygulama Geliştirme", "Modern ve Ölçeklenebilir Web Uygulamaları" },
                    { 2, "/img/service/default-image6.jpg", "/img/service/default-image7.jpg", "Mobil uygulamalar günümüzün dijital dünyasında işletmeler için en önemli iletişim araçlarından biridir. Flutter, React Native ve Swift/Kotlin teknolojilerini kullanarak hem iOS hem Android cihazlarda sorunsuz çalışan, performanslı ve kullanıcı dostu mobil uygulamalar geliştiriyoruz. Müşteri ihtiyaçlarına göre özelleştirilmiş çözümler sunuyoruz.", "Hem native hem de cross-platform geliştirme tecrübemiz sayesinde projeleriniz için en uygun teknolojiyi seçiyoruz. Kullanıcı deneyimini en üst seviyeye çıkarırken bakım ve güncelleme maliyetlerini minimumda tutuyoruz.", "Çapraz Platform ve Yerel Uygulamalar", "/img/service/default-image8.png", "/img/service/default-image5.jpg", "Mobil Uygulama Geliştirme", "iOS ve Android için Profesyonel Mobil Çözümler" },
                    { 3, "/img/service/default-image10.jpg", "/img/service/default-image11.jpg", "Windows, macOS ve Linux platformları için performanslı ve güvenilir masaüstü yazılımlar geliştiriyoruz. .NET, WPF, Electron ve Java teknolojilerini kullanarak işletmelerin özel ihtiyaçlarına uygun ERP, CRM ve üretim takip sistemleri tasarlıyoruz.", "Masaüstü yazılımlarımız offline çalışma imkanı, güvenli veri yönetimi ve kullanıcı dostu arayüzleri ile şirketlerin iş süreçlerini hızlandırır. Ayrıca bulut ve API entegrasyonları ile modern altyapılarla uyumlu çalışır.", "Dayanıklı ve Güvenli Masaüstü Çözümler", "/img/service/default-image12.png", "/img/service/default-image9.jpg", "Masaüstü Yazılım Geliştirme", "Kurumsal Çözümler İçin Güçlü Masaüstü Uygulamaları" },
                    { 4, "/img/service/default-image14.jpg", "/img/service/default-image15.jpg", "KOBİ’lerden büyük ölçekli işletmelere kadar her seviyede e-ticaret çözümleri sunuyoruz. ASP.NET Core, Shopify, WooCommerce ve özel yazılım altyapılarıyla hızlı, güvenli ve kullanıcı dostu e-ticaret platformları geliştiriyoruz.", "Ürün yönetimi, güvenli ödeme sistemleri, stok takibi, kargo entegrasyonları ve kullanıcı deneyimi odaklı arayüzler ile müşterilerinize en iyi alışveriş deneyimini sunmanıza yardımcı oluyoruz.", "Modern E-Ticaret Deneyimi", "/img/service/default-image16.png", "/img/service/default-image13.jpg", "E-Ticaret Çözümleri", "Ölçeklenebilir ve Güvenli E-Ticaret Platformları" },
                    { 5, "/img/service/default-image18.jpg", "/img/service/default-image19.jpg", "SEO hizmetlerimiz ile web sitenizin Google ve diğer arama motorlarında üst sıralarda yer almasını sağlıyoruz. Teknik SEO, içerik optimizasyonu ve backlink çalışmaları ile markanızın dijital görünürlüğünü artırıyoruz.", "Anahtar kelime analizi, rakip araştırması, performans raporları ve sürekli iyileştirme adımları ile uzun vadeli başarı hedefliyoruz. Dijital pazarlama stratejilerimizle organik trafiğinizi ve müşteri dönüşüm oranlarınızı yükseltiyoruz.", "Stratejik SEO Yaklaşımı", "/img/service/default-image20.png", "/img/service/default-image17.jpg", "SEO ve Dijital Pazarlama", "Arama Motoru Optimizasyonu ve Görünürlük Artırma" }
                });

            migrationBuilder.InsertData(
                table: "SiteInfo",
                columns: new[] { "Id", "Address", "CompanyName", "CompanyOwner", "Email1", "Email2", "Fax1", "Fax2", "GoogleMapsApi", "LogoPath", "Phone1", "Phone2", "SiteInformation", "SiteName", "SiteOwner", "TNumber", "TaxNumber", "TaxOffice", "WaNumber", "WorkingHours" },
                values: new object[] { 1, "Demirköprü Mah. Karşıyaka/İstanbul.", "Fırat Ramazano", "Fırat Ramazano", "info@firatramazano.com", "firatro@outlook.com", "+90 232 000 0000", "+90 232 000 0000", "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d380.50129495713793!2d28.977997042359917!3d41.00806685326879!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14caa7040068086b%3A0xe1ccfe98bc01b0d0!2zxLBzdGFuYnVs!5e0!3m2!1str!2str!4v1758490039045!5m2!1str!2str", "/img/site-info/logo.png", "+90 535 630 5220", "+90 232 000 0000", "Modern teknolojileri yenilikçi yazılım çözümleriyle buluşturur. İşletmelerin dijital dönüşümünü hızlandırırken güvenilir, ölçeklenebilir ve kullanıcı dostu uygulamalar geliştirir.", "Fırat Ramazano", "Fırat Ramazano", "+90 535 630 5220", "1234567890", "İzmir Vergi Dairesi", "+90 535 630 5220", "Hafta içi: 09:00 - 18:00" });

            migrationBuilder.InsertData(
                table: "Sliders",
                columns: new[] { "Id", "ImagePath", "Subtitle", "Tag", "Title" },
                values: new object[,]
                {
                    { 1, "img/slider/default-image1.jpg", "Ölçeklenebilir ve güvenli çözümler", "Web", "Modern web uygulamaları" },
                    { 2, "img/slider/default-image2.jpg", "iOS ve Android için performanslı çözümler", "Mobil", "Mobil dünyada güçlü uygulamalar" },
                    { 3, "img/slider/default-image3.jpg", "Güvenli ve kullanıcı dostu e-ticaret platformları", "E-Ticaret", "Dijital mağazanızı büyütün" },
                    { 4, "img/slider/default-image4.jpg", "SEO ve dijital pazarlama stratejileri", "SEO", "Google’da daha görünür olun" }
                });

            migrationBuilder.InsertData(
                table: "SocialMediaInfo",
                columns: new[] { "Id", "Facebook", "Instagram", "Tiktok", "X", "Youtube" },
                values: new object[] { 1, "https://facebook.com/firatro", "https://instagram.com/firatro", "https://tiktok.com/", "https://x.com/_firatro", "https://youtube.com/firatro" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Web Geliştirme" },
                    { 2, "Mobil Uygulama" },
                    { 3, "Yapay Zeka" },
                    { 4, "Siber Güvenlik" },
                    { 5, "E-Ticaret" },
                    { 6, "SEO ve Dijital Pazarlama" }
                });

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "Id", "Biography", "Email", "Experience", "Facebook", "FullName", "ImagePath", "Instagram", "Linkedin", "Phone", "Skills", "Title", "Twitter", "Website", "Youtube" },
                values: new object[] { 1, "15 yılı aşkın süredir yazılım geliştirme ve teknoloji girişimciliği alanında deneyime sahip. Modern yazılım mimarileri, yapay zeka ve bulut tabanlı çözümler konusunda uzman.", "firat.ramazano@company.com", "15+ yıl yazılım geliştirme, girişimcilik ve uluslararası teknoloji konferanslarında konuşmacı.", "https://facebook.com/firatro", "Fırat Ramazano", "/img/team-member/default-image1.jpg", "https://instagram.com/firatro", "https://linkedin.com/in/firatro", "+90-532-111-2233", "[\"Liderlik\", \"Yazılım Mimarisi\", \"İş Stratejisi\", \"Bulut Teknolojileri\"]", "Kurucu & CEO", "https://twitter.com/_firatro", "https://www.firatramazano.com", "https://youtube.com/@firatro" });

            migrationBuilder.InsertData(
                table: "Testimonials",
                columns: new[] { "Id", "Comment", "FullName", "ImagePath", "Rating", "Title" },
                values: new object[,]
                {
                    { 1, "E-ticaret platformumuzu Fırat Ramazano Software ekibi geliştirdi. Kullanıcı dostu arayüz ve güvenli ödeme altyapısı sayesinde satışlarımız ciddi şekilde arttı. Profesyonel ve güvenilir bir ekip.", "Elif Yılmaz", "/img/testimonial/default-image1.jpg", 5, "E-Ticaret Projesi Müşterisi" },
                    { 2, "Uzun zamandır hayalini kurduğum mobil uygulamayı Flutter ile geliştirdiler. Hem iOS hem Android’de sorunsuz çalışıyor. Destek süreçleri de çok hızlı.", "Mehmet Demir", "/img/testimonial/default-image1.jpg", 5, "Mobil Uygulama Müşterisi" },
                    { 3, "Kurumsal web sitemizi yenilediler. Hızlı, modern ve SEO uyumlu bir site oldu. Süreç boyunca iletişimleri çok şeffaf ve profesyoneldi.", "Zeynep Kara", "/img/testimonial/default-image1.jpg", 4, "Web Uygulama Müşterisi" },
                    { 4, "SEO çalışmaları sayesinde Google’da üst sıralara çıktık. Organik trafik ve müşteri dönüşüm oranlarımız gözle görülür şekilde arttı. Kesinlikle tavsiye ederim.", "Ahmet Çelik", "/img/testimonial/default-image1.jpg", 5, "SEO Hizmeti Müşterisi" },
                    { 5, "Üretim takip sürecimizi masaüstü yazılım ile dijitalleştirdiler. Artık tüm operasyonlarımızı çok daha kolay yönetiyoruz. İşimize büyük değer kattı.", "Selin Arslan", "/img/testimonial/default-image1.jpg", 4, "Masaüstü Yazılım Müşterisi" }
                });

            migrationBuilder.InsertData(
                table: "VisionMission",
                columns: new[] { "Id", "MissionDescription", "MissionImagePath", "MissionTitle", "VisionDescription", "VisionImagePath", "VisionTitle" },
                values: new object[] { 1, "Misyonumuz; işletmelerin dijital dönüşüm süreçlerinde güvenilir, ölçeklenebilir ve kullanıcı dostu yazılım çözümleri geliştirmektir. Kişiye özel yaklaşımlar, uzman ekip ve modern teknolojilerle her müşterimizin ihtiyaçlarına uygun çözümler üretiyoruz. Etik kurallar çerçevesinde sunduğumuz hizmetlerle yalnızca teknoloji geliştirmek değil, aynı zamanda iş süreçlerine değer katmayı hedefliyoruz. Müşterilerimize güven veren, şeffaf ve sürdürülebilir bir hizmet anlayışıyla uzun vadeli başarılar yaratmak en büyük önceliğimizdir.", "/img/vision-mission/default-image2.jpg", "Misyonumuz", "Fırat Ramazano Software olarak vizyonumuz; yazılım geliştirme alanında ulusal ve uluslararası ölçekte güvenilir, yenilikçi ve tercih edilen bir teknoloji firması haline gelmektir. Amacımız, modern teknolojileri takip ederek işletmelere en güncel ve etkili çözümleri sunmak, aynı zamanda sektöre yön veren projeler geliştirmektir. Gelecek yıllarda etik değerlerden ödün vermeden sunduğumuz kaliteli hizmetlerle yazılım dünyasında öncü bir rol üstlenmek en büyük hedefimizdir.", "/img/vision-mission/default-image1.jpg", "Vizyonumuz" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "CategoryId", "ContentImage1Path", "ContentImage2Path", "CreatedAt", "Description", "EntryDescription", "EntryTitle", "ExtraDescription", "ExtraTitle", "FullName", "MainImagePath", "Quote", "QuoteSource", "Subtitle", "Title", "YoutubeVideoUrl" },
                values: new object[,]
                {
                    { 1, 1, "/img/blog/default-image2.jpg", "/img/blog/default-image3.jpg", new DateTime(2025, 9, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Yazılım geliştirme, yalnızca kod yazmaktan ibaret değildir; sürdürülebilir, ölçeklenebilir ve kullanıcı odaklı çözümler üretmeyi hedefleyen kapsamlı bir süreçtir. Günümüzde modern yazılım mimarileri sayesinde daha çevik geliştirme süreçleri ve işlevsel açıdan tatmin edici sonuçlar elde edilmektedir.", "Monolitik yapılardan mikroservislere geçiş, DevOps kültürü ve otomasyon araçlarının yaygınlaşması yazılım ekiplerinin daha hızlı, güvenilir ve esnek ürünler geliştirmesine olanak sağlamaktadır.", "Neden Modern Yazılım Yaklaşımları Tercih Ediliyor?", "Proje öncesinde detaylı bir analiz ve planlama yapılır. Agile metodolojileri sayesinde değişen ihtiyaçlara hızlı şekilde uyum sağlanır. Temiz kod ve test odaklı geliştirme ise uzun vadede sürdürülebilirliği artırır.", "Geliştirme Süreci ve Sürdürülebilirlik", "Admin User", "/img/blog/default-image1.jpg", "Temiz kod, iyi bir yazılımcının en önemli imzasıdır.", "Robert C. Martin (Uncle Bob)", "Temiz Kod, Mikroservisler ve Bulut Tabanlı Çözümler", "Yazılım Geliştirmede Modern Yaklaşımlar", "https://www.youtube.com/watch?v=O8N1lvkYykg" },
                    { 2, 2, "/img/blog/default-image5.jpg", "/img/blog/default-image6.jpg", new DateTime(2025, 9, 10, 14, 30, 0, 0, DateTimeKind.Unspecified), "Yapay zeka ve makine öğrenmesi, günümüzde sağlık, finans, eğitim ve yazılım geliştirme dahil pek çok sektörde devrim yaratmaktadır. Otomasyon ve öngörü yetenekleri sayesinde iş süreçleri daha verimli hale gelmektedir.", "Veri odaklı karar verme süreçlerinde yapay zeka, hızlı ve doğru analiz yapabilme kapasitesi ile öne çıkmaktadır.", "Yapay Zeka Neden Önemli?", "Görüntü işleme, doğal dil işleme ve öneri sistemleri günümüzün en yaygın makine öğrenmesi uygulamaları arasında yer almaktadır.", "Makine Öğrenmesi Uygulamaları", "Admin User", "/img/blog/default-image4.jpg", "Yapay zeka, insanlığın yeni elektrik kaynağıdır.", "Andrew Ng", "Geleceği Şekillendiren Teknolojiler", "Yapay Zeka ve Makine Öğrenmesi", "https://www.youtube.com/watch?v=aircAruvnKk" },
                    { 3, 3, "/img/blog/default-image8.jpg", "/img/blog/default-image9.jpg", new DateTime(2025, 9, 12, 11, 15, 0, 0, DateTimeKind.Unspecified), "Mobil uygulamalar, dijital dönüşümün merkezinde yer almaktadır. Günümüzde cross-platform teknolojiler sayesinde tek kod tabanı ile hem iOS hem Android uygulamaları geliştirmek mümkün hale gelmiştir.", "Teknoloji maliyetleri azaltır, geliştirme sürecini hızlandırır ve bakım kolaylığı sağlar.", "Neden Cross-Platform?", "5G, artırılmış gerçeklik (AR) ve yapay zeka destekli uygulamalar mobil dünyayı yeniden şekillendirmektedir.", "Geleceğin Mobil Teknolojileri", "Admin User", "/img/blog/default-image7.jpg", "Mobil, insanın yeni uzvu haline geldi.", "Eric Schmidt", "Flutter, React Native ve Cross-Platform Çözümler", "Mobil Uygulama Geliştirmede Trendler", "https://www.youtube.com/watch?v=fq4N0hgOWzU" },
                    { 4, 4, "/img/blog/default-image11.jpg", "/img/blog/default-image12.jpg", new DateTime(2025, 9, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), "Siber saldırıların çeşitliliği ve şiddeti her geçen gün artıyor. Yeni nesil güvenlik çözümleri ise şirketlerin verilerini ve kullanıcılarını daha iyi korumayı amaçlıyor.", "Veri ihlalleri, kimlik avı saldırıları ve fidye yazılımları hem bireyler hem de kurumlar için ciddi riskler taşımaktadır.", "Neden Siber Güvenlik?", "Kullanıcılar ve cihazlar sürekli doğrulanır, hiçbir şeye otomatik güven duyulmaz. Bu yaklaşım güvenlik risklerini önemli ölçüde azaltır.", "Zero Trust Yaklaşımı", "Admin User", "/img/blog/default-image10.jpg", "En zayıf halka genellikle insan faktörüdür.", "Bruce Schneier", "Zero Trust, Ransomware ve Yapay Zeka Destekli Savunmalar", "Siber Güvenlikte Yeni Nesil Tehditler", "https://www.youtube.com/watch?v=inWWhr5tnEA" },
                    { 5, 5, "/img/blog/default-image14.jpg", "/img/blog/default-image15.jpg", new DateTime(2025, 9, 18, 16, 45, 0, 0, DateTimeKind.Unspecified), "Bulut teknolojileri ve DevOps uygulamaları, yazılım geliştirme süreçlerinde esneklik, hız ve güvenilirlik sağlamaktadır. CI/CD boru hatları sayesinde ekipler daha kısa sürede kaliteli ürünler çıkarabilmektedir.", "Geliştirme ve operasyon ekipleri arasındaki iş birliğini artırır, yazılım teslimat süreçlerini hızlandırır.", "DevOps Neden Tercih Ediliyor?", "AWS, Azure ve Google Cloud gibi bulut servisleri, ölçeklenebilir ve güvenilir altyapılar sunarak şirketlere büyük avantaj sağlamaktadır.", "Bulutun Gücü", "Admin User", "/img/blog/default-image13.jpg", "Otomasyon, modern yazılım geliştirmede en büyük müttefiktir.", "Gene Kim", "Sürekli Entegrasyon ve Sürekli Teslimat (CI/CD)", "Bulut Bilişim ve DevOps Kültürü", "https://www.youtube.com/watch?v=scEDHsr3APg" },
                    { 6, 6, "/img/blog/default-image17.jpg", "/img/blog/default-image18.jpg", new DateTime(2025, 9, 20, 13, 0, 0, 0, DateTimeKind.Unspecified), "Tasarım kalıpları, yazılım geliştiricilerin tekrar eden problemleri daha kolay ve düzenli bir şekilde çözmesine yardımcı olur. Bu kalıplar, yazılım projelerinin daha esnek ve sürdürülebilir olmasını sağlar.", "Kodun okunabilirliğini artırır, bakım sürecini kolaylaştırır ve ekip içi standartlaşmayı sağlar.", "Tasarım Kalıpları Neden Kullanılır?", "Singleton, Factory Method, Observer ve Strategy kalıpları yazılım projelerinde sıkça kullanılan örneklerdendir.", "En Yaygın Kalıplar", "Admin User", "/img/blog/default-image16.jpg", "İyi bir yazılım tasarımı, kötü kodu bile taşıyabilir.", "Erich Gamma (Gang of Four)", "Singleton, Factory, Observer ve Daha Fazlası", "Yazılımda Yapısal Tasarım Kalıpları", "https://www.youtube.com/watch?v=NU_1StN5Tkk" }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "BlogId", "ContentHtml", "IsActive", "LinkType", "Order", "ParentId", "ProjectId", "ServiceId", "Slug", "Title", "Url" },
                values: new object[,]
                {
                    { 7, null, null, true, 1, 1, 3, null, 1, "web", "Web Projeleri", "/hizmetler/web" },
                    { 8, null, null, true, 1, 2, 3, null, 2, "mobil", "Mobil Uygulamalar", "/hizmetler/mobil" },
                    { 9, null, null, true, 1, 3, 3, null, 3, "masaustu-yazilim", "Masaüstü Yazılım", "/hizmetler/dudak-dolgusu" },
                    { 10, null, null, true, 1, 4, 3, null, 4, "e-ticaret", "E-Ticaret", "/hizmetler/e-ticaret" },
                    { 11, null, null, true, 1, 4, 3, null, 4, "seo", "SEO Çalışması", "/hizmetler/seo" }
                });

            migrationBuilder.InsertData(
                table: "ProjectFeatures",
                columns: new[] { "Id", "Name", "ProjectId" },
                values: new object[,]
                {
                    { 1, "Ölçeklenebilir mimari", 1 },
                    { 2, "Güvenli ödeme altyapısı", 1 },
                    { 3, "Kullanıcı dostu arayüz", 1 },
                    { 4, "Mikroservis tabanlı yapı", 1 },
                    { 5, "Çift platform desteği (iOS & Android)", 2 },
                    { 6, "Yüksek güvenlik (2FA, SSL)", 2 },
                    { 7, "Gerçek zamanlı bildirimler", 2 },
                    { 8, "Kolay para transferi ve fatura ödeme", 2 },
                    { 9, "Yapay zeka destekli tahminleme", 3 },
                    { 10, "Müşteri segmentasyonu", 3 },
                    { 11, "Otomatik görev atama", 3 },
                    { 12, "Satış ekibi verimliliğini artıran çözümler", 3 }
                });

            migrationBuilder.InsertData(
                table: "ServiceFaqs",
                columns: new[] { "Id", "Answer", "Question", "ServiceId" },
                values: new object[,]
                {
                    { 1, "ASP.NET Core, Node.js, React, Angular ve Vue.js gibi modern teknolojilerle güvenli ve ölçeklenebilir web uygulamaları geliştiriyoruz.", "Web uygulamalarınız hangi teknolojilerle geliştiriliyor?", 1 },
                    { 2, "Projenin kapsamına göre değişmekle birlikte, küçük projeler 1-2 ayda, daha kapsamlı projeler 3-6 ayda teslim edilebilmektedir.", "Web projelerinin teslim süresi ne kadar?", 1 },
                    { 3, "Evet, tüm web projelerimiz responsive (mobil uyumlu) olarak tasarlanmakta ve farklı cihazlarda sorunsuz çalışmaktadır.", "Web uygulamalarınız mobil uyumlu mu?", 1 },
                    { 4, "Evet, projeler teslim edildikten sonra bakım, güvenlik güncellemeleri ve teknik destek hizmetleri sunuyoruz.", "Bakım ve destek hizmeti veriyor musunuz?", 1 },
                    { 5, "Flutter ve React Native ile geliştirdiğimiz uygulamalar hem iOS hem Android cihazlarda sorunsuz çalışmaktadır.", "Mobil uygulamalarınız hangi platformlarda çalışıyor?", 2 },
                    { 6, "Projenin ihtiyaçlarına göre karar veriyoruz. Performans kritikse native, bütçe ve hız öncelikliyse cross-platform tercih ediyoruz.", "Native mi yoksa cross-platform mu tercih ediyorsunuz?", 2 },
                    { 7, "SSL, veri şifreleme, 2FA ve güvenlik testleri kullanarak uygulamalarımızın güvenliğini sağlıyoruz.", "Mobil uygulamalarda güvenlik nasıl sağlanıyor?", 2 },
                    { 8, "Evet, hem App Store hem de Google Play’e yükleme ve yayın sürecinde destek sağlıyoruz.", "Uygulama mağazalarına yükleme desteğiniz var mı?", 2 },
                    { 9, "Windows, macOS ve Linux için masaüstü çözümleri geliştiriyoruz.", "Masaüstü uygulamalar hangi platformlarda çalışıyor?", 3 },
                    { 10, "Evet, ihtiyaç halinde internet bağlantısı olmadan da çalışan offline çözümler geliştiriyoruz.", "Masaüstü yazılımlarınız offline çalışabilir mi?", 3 },
                    { 11, "Evet, masaüstü uygulamalarımız bulut servisleri ve API’lerle entegre çalışacak şekilde tasarlanabilmektedir.", "Masaüstü yazılımlar bulut ile entegre edilebilir mi?", 3 },
                    { 12, "Uzaktan bağlantı ve düzenli sürüm güncellemeleriyle bakım hizmeti veriyoruz.", "Bakım ve güncellemeler nasıl yapılıyor?", 3 },
                    { 13, "Ürün yönetimi, güvenli ödeme, stok takibi, kargo entegrasyonu ve kullanıcı dostu arayüzler temel özelliklerimizdir.", "E-ticaret siteniz hangi özellikleri içeriyor?", 4 },
                    { 14, "Evet, tüm e-ticaret çözümlerimiz SEO uyumlu geliştirilmekte ve Google’da daha iyi sıralamalar almanıza yardımcı olmaktadır.", "E-ticaret siteleriniz SEO uyumlu mu?", 4 },
                    { 15, "Evet, tüm e-ticaret projelerimiz responsive tasarıma sahiptir.", "E-ticaret siteleriniz mobil uyumlu mu?", 4 },
                    { 16, "Kredi kartı, banka transferi, PayPal, iyzico ve Stripe gibi popüler ödeme yöntemlerini entegre ediyoruz.", "Hangi ödeme yöntemleri entegre edilebiliyor?", 4 },
                    { 17, "Teknik SEO, içerik optimizasyonu, backlink çalışmaları ve hız iyileştirmelerini kapsıyoruz.", "SEO çalışmalarınız neleri kapsıyor?", 5 },
                    { 18, "Genellikle 3-6 ay içinde gözle görülür sonuçlar alınmaya başlanır.", "SEO çalışmalarının etkisi ne zaman görülür?", 5 },
                    { 19, "Evet, proje başlangıcında detaylı anahtar kelime ve rakip analizi yapıyoruz.", "Anahtar kelime analizi yapıyor musunuz?", 5 },
                    { 20, "SEO uzun vadeli bir süreçtir, düzenli optimizasyon ve içerik güncellemeleri ile kalıcı başarı sağlıyoruz.", "SEO çalışmalarınız kalıcı mıdır?", 5 }
                });

            migrationBuilder.InsertData(
                table: "ServiceFeatures",
                columns: new[] { "Id", "Name", "ServiceId", "Value" },
                values: new object[,]
                {
                    { 1, "Ölçeklenebilir altyapı", 1, null },
                    { 2, "Modern frontend teknolojileri", 1, null },
                    { 3, "Yüksek güvenlik standartları", 1, null },
                    { 4, "Kullanıcı dostu arayüz tasarımı", 1, null },
                    { 5, "iOS ve Android uyumluluk", 2, null },
                    { 6, "Cross-platform geliştirme", 2, null },
                    { 7, "Gerçek zamanlı bildirimler", 2, null },
                    { 8, "Yüksek performanslı mobil deneyim", 2, null },
                    { 9, "Windows, macOS ve Linux desteği", 3, null },
                    { 10, "Offline çalışma imkanı", 3, null },
                    { 11, "Bulut entegrasyonu", 3, null },
                    { 12, "Kurumsal iş süreçlerine özel çözümler", 3, null },
                    { 13, "Güvenli ödeme sistemleri", 4, null },
                    { 14, "Stok ve sipariş yönetimi", 4, null },
                    { 15, "Kargo entegrasyonu", 4, null },
                    { 16, "Mobil uyumlu e-ticaret deneyimi", 4, null },
                    { 17, "Anahtar kelime analizi", 5, null },
                    { 18, "Teknik SEO optimizasyonu", 5, null },
                    { 19, "Backlink stratejileri", 5, null },
                    { 20, "Performans ve hız iyileştirmeleri", 5, null }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BlogId", "CreatedAt", "FullName", "IsApproved", "Text" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 9, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), "Ahmet Yılmaz", true, "Çok faydalı bir yazı olmuş, mikroservisler ve temiz kod bölümleri özellikle dikkat çekiciydi." },
                    { 2, 1, new DateTime(2025, 9, 5, 11, 0, 0, 0, DateTimeKind.Unspecified), "Ayşe Demir", true, "Agile metodolojiler konusunda kafamda soru işaretleri vardı, yazı çok net bir şekilde açıklamış." },
                    { 3, 2, new DateTime(2025, 9, 6, 9, 30, 0, 0, DateTimeKind.Unspecified), "Mehmet Aksoy", false, "Makine öğrenmesi örnekleri çok açıklayıcı olmuş, özellikle öneri sistemleri kısmı ilgimi çekti." },
                    { 4, 3, new DateTime(2025, 9, 7, 14, 15, 0, 0, DateTimeKind.Unspecified), "Zeynep Kaya", true, "React Native ve Flutter karşılaştırması çok işime yaradı, teşekkürler." },
                    { 5, 4, new DateTime(2025, 9, 8, 18, 45, 0, 0, DateTimeKind.Unspecified), "Selin Arslan", true, "Zero Trust yaklaşımı hakkında bu kadar detaylı bilgi bulmak çok güzel. Gerçekten açıklayıcı." },
                    { 6, 5, new DateTime(2025, 9, 9, 12, 20, 0, 0, DateTimeKind.Unspecified), "Can Demirtaş", false, "CI/CD süreci hakkında yanlış bildiklerim varmış, bu yazı gerçekten aydınlatıcı oldu." },
                    { 7, 6, new DateTime(2025, 9, 10, 15, 10, 0, 0, DateTimeKind.Unspecified), "Murat Özkan", true, "Observer ve Singleton örnekleri çok açıklayıcı, uygulamamda hemen deneyeceğim." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CategoryId",
                table: "Blogs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogTags_TagId",
                table: "BlogTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogId",
                table: "Comments",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_ParentId",
                table: "Menus",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFeatures_ProjectId",
                table: "ProjectFeatures",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceFaqs_ServiceId",
                table: "ServiceFaqs",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceFeatures_ServiceId",
                table: "ServiceFeatures",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutUs");

            migrationBuilder.DropTable(
                name: "BeforeAfters");

            migrationBuilder.DropTable(
                name: "BlogTags");

            migrationBuilder.DropTable(
                name: "ChatBotQAs");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Faqs");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "PageImages");

            migrationBuilder.DropTable(
                name: "ProjectFeatures");

            migrationBuilder.DropTable(
                name: "SeoSettings");

            migrationBuilder.DropTable(
                name: "ServiceFaqs");

            migrationBuilder.DropTable(
                name: "ServiceFeatures");

            migrationBuilder.DropTable(
                name: "SiteInfo");

            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.DropTable(
                name: "SocialMediaInfo");

            migrationBuilder.DropTable(
                name: "TeamMembers");

            migrationBuilder.DropTable(
                name: "Testimonials");

            migrationBuilder.DropTable(
                name: "VersionInfos");

            migrationBuilder.DropTable(
                name: "VisionMission");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
