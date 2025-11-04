using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GurventVantilator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RoleManagement : Migration
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
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: true),
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
                name: "ProductApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductApplications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: true),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategories_ProductCategories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
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
                    WaSupportNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Tiktok = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Linkedin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vimeo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vk = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ContentTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diameter = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: true),
                    DiameterUnit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    AirFlow = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: true),
                    AirFlowUnit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Pressure = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: true),
                    PressureUnit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Power = table.Column<double>(type: "float(10)", precision: 10, scale: 3, nullable: true),
                    PowerUnit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Voltage = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: true),
                    Frequency = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: true),
                    Speed = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: true),
                    SpeedUnit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    NoiseLevel = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: true),
                    NoiseLevelUnit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SpeedControl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image1Path = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Image2Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image3Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image4Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image5Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataSheetPath = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Model3DPath = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    TestDataPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScaleImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
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
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
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

            migrationBuilder.CreateTable(
                name: "ProductContentFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductContentFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductContentFeatures_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductProductApplications",
                columns: table => new
                {
                    ApplicationsId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductApplications", x => new { x.ApplicationsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_ProductProductApplications_ProductApplications_ApplicationsId",
                        column: x => x.ApplicationsId,
                        principalTable: "ProductApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductApplications_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTestData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Pt1 = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Pt2 = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Pt3 = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Pt4 = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Pt5 = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Pt6 = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Pt7 = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Pt8 = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Pt9 = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Pt10 = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Pt11 = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Pt12 = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Q1 = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Q2 = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Q3 = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Q4 = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Q5 = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Q6 = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Q7 = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Q8 = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Q9 = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Q10 = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Q11 = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Q12 = table.Column<decimal>(type: "decimal(18,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTestData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTestData_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AboutUs",
                columns: new[] { "Id", "Awards", "CompletedProjects", "Description", "ExperienceYear", "ExtraDescription", "ExtraTitle", "HappyClients", "ImagePath", "Title", "YoutubeVideoUrl" },
                values: new object[] { 1, 8, 750, "Gurvent Vantilatör, endüstriyel fan ve havalandırma sistemleri alanında uzmanlaşmış bir mühendislik firmasıdır. 1984 yılından bu yana sanayi tesislerinden sağlık kurumlarına kadar birçok sektöre yenilikçi ve güvenilir çözümler sunmaktayız.", 40, "Kaliteli üretim, mühendislik tecrübesi ve müşteri memnuniyetine dayalı yaklaşımımızla, Türkiye'nin önde gelen endüstriyel fan üreticilerinden biriyiz. Ürünlerimiz CE ve ISO 9001 kalite standartlarına uygun olarak üretilmektedir.", "40 Yıllık Deneyim, Güçlü Çözümler", 1200, "/img/about-us/factory-team.jpg", "Hakkımızda", null });

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
                    { 1, "Enerji Verimliliği" },
                    { 2, "ATEX ve Güvenlik" },
                    { 3, "Filtrasyon ve Toz Kontrolü" },
                    { 4, "Havalandırma Sistemleri" },
                    { 5, "Bakım ve Servis" }
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
                    { 1, "/img/company/gurvent-logo.png", "Gurvent Vantilatör" },
                    { 2, "/img/company/ventpro-logo.png", "VentPro Teknik" },
                    { 3, "/img/company/airflow-logo.png", "AirFlow Engineering" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "Message", "Notes", "Phone", "Subject" },
                values: new object[] { 1, new DateTime(2025, 9, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), "ali.korkmaz@example.com", "Ali Korkmaz", "Fabrikamız için yüksek debili santrifüj fan ihtiyacımız bulunmaktadır. Ürün kataloğu ve fiyat teklifi rica ediyorum.", "Teklif gönderilecek müşteri.", "+90 533 222 33 44", "Endüstriyel fan teklifi hakkında bilgi" });

            migrationBuilder.InsertData(
                table: "Faqs",
                columns: new[] { "Id", "Answer", "CreatedAt", "Question" },
                values: new object[,]
                {
                    { 1, "Santrifüj, aksiyel, çatı tipi, kanal tipi ve özel proje fanları üretiyoruz.", new DateTime(2025, 9, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Hangi tür fanları üretiyorsunuz?" },
                    { 2, "Alan ölçüsü, debi ihtiyacı, statik basınç ve kullanım amacına göre mühendis ekibimiz fan seçimini yapmaktadır.", new DateTime(2025, 9, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Fan seçimi nasıl yapılır?" },
                    { 3, "Evet, patlayıcı ortamlarda kullanılmak üzere ATEX standartlarına uygun fan üretimi yapıyoruz.", new DateTime(2025, 9, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "ATEX sertifikalı fanlarınız var mı?" },
                    { 4, "Kullanım yoğunluğuna göre yılda en az bir kez periyodik bakım öneriyoruz.", new DateTime(2025, 9, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Fan bakımı ne sıklıkla yapılmalı?" },
                    { 5, "Standart ürünlerde 10-15 iş günü, özel üretimlerde 20-30 iş günü aralığındadır.", new DateTime(2025, 9, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Teslimat süreniz ne kadar?" }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "BlogId", "ContentHtml", "IsActive", "LinkType", "Order", "ParentId", "ProductCategoryId", "ProductId", "ProjectId", "ServiceId", "Slug", "Title", "Url" },
                values: new object[,]
                {
                    { 1, null, null, true, 6, 1, null, null, null, null, null, "anasayfa", "Ana Sayfa", "/" },
                    { 2, null, null, true, 5, 2, null, null, null, null, null, "hakkimizda", "Kurumsal", "/hakkimizda" },
                    { 3, null, null, true, 8, 3, null, null, null, null, null, "urunler", "Ürünler", "/urunler" },
                    { 7, null, null, true, 4, 7, null, null, null, null, null, "iletisim", "İletişim", "/iletisim" }
                });

            migrationBuilder.InsertData(
                table: "PageImages",
                columns: new[] { "Id", "ImagePath", "ImageType", "PageKey" },
                values: new object[,]
                {
                    { 1, "/img/page-image/aboutus-factory.jpg", "Breadcrumb", "AboutUs" },
                    { 2, "/img/page-image/contact-office.jpg", "Breadcrumb", "Contact" },
                    { 3, "/img/page-image/blog-industrial.jpg", "Breadcrumb", "Blog" },
                    { 4, "/img/page-image/project-site.jpg", "Breadcrumb", "Project" },
                    { 5, "/img/page-image/service-production.jpg", "Breadcrumb", "Service" },
                    { 6, "/img/page-image/product-line.jpg", "Breadcrumb", "Product" },
                    { 7, "/img/page-image/home-header.jpg", "Breadcrumb", "Home" }
                });

            migrationBuilder.InsertData(
                table: "ProductApplications",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Endüstriyel Havalandırma" },
                    { 2, "Tarım ve Seracılık" },
                    { 3, "Gıda Üretimi" },
                    { 4, "Tünel ve Otopark Havalandırma" },
                    { 5, "Laboratuvar ve Kimya" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedAt", "Description", "ImagePath", "IsActive", "Name", "Order", "ParentCategoryId", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, "Santrifuj Fanlar", 1, null, null });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "ContentImage1Path", "ContentImage2Path", "CreatedAt", "CustomerInfo", "Description", "ExtraDescription", "ExtraTitle", "IntroText", "MainImagePath", "ProjectDate", "Subtitle", "Title" },
                values: new object[,]
                {
                    { 1, "/img/project/factory2.jpg", "/img/project/factory3.jpg", new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "XYZ Otomotiv A.Ş.", "Toplam 24 adet endüstriyel fan üretimi, montajı ve devreye alma süreci 45 gün içinde tamamlandı. Sistem, otomasyon paneline entegre çalışmaktadır.", "Yeni sistem sayesinde enerji tüketiminde %18 tasarruf sağlandı.", "Enerji Verimliliği", "Fabrikanın üretim alanları için yüksek debili, düşük ses seviyeli santrifüj fanlar tasarlandı.", "/img/project/factory1.jpg", new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Santrifüj Fan Sistemleri", "Otomotiv Fabrikası Havalandırma Projesi" },
                    { 2, "/img/project/hospital2.jpg", "/img/project/hospital3.jpg", new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sağlık Grup Hastanesi", "HEPA filtreli havalandırma sistemi ile temiz hava sirkülasyonu sağlanarak uluslararası standartlara uygun hale getirildi.", "Fanlar 24 saat kesintisiz çalışmada dahi düşük gürültü seviyesini koruyor.", "Sessiz ve Güvenli Çalışma", "Steril ortamlarda kullanılmak üzere özel filtreli ve sessiz aksiyel fanlar tasarlandı.", "/img/project/hospital1.jpg", new DateTime(2023, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hijyenik Aksiyel Fan Sistemleri", "Hastane Ameliyathane Havalandırma Projesi" },
                    { 3, "/img/project/mine2.jpg", "/img/project/mine3.jpg", new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delta Madencilik Ltd.", "Fanlar yüksek toz, nem ve sıcaklık koşullarına dayanıklı olacak şekilde özel malzemelerden imal edilmiştir.", "Sistem uluslararası patlama koruma standartlarına uygun şekilde devreye alınmıştır.", "ATEX Güvenliği", "Zorlu çalışma koşullarında güvenli hava dolaşımı sağlamak için ATEX sertifikalı fanlar üretildi.", "/img/project/mine1.jpg", new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patlamaya Dayanıklı Fan Çözümü", "Maden Ocağı Hava Sirkülasyon Sistemi" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Tüm yetkilere sahip geliştirici", "DevAdmin", "DEVADMIN" },
                    { 2, null, "Yönetim paneli yöneticisi", "Admin", "ADMIN" },
                    { 3, null, "WebUI kullanıcıları", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "SeoSettings",
                columns: new[] { "Id", "DefaultMetaDescription", "DefaultMetaKeywords", "DefaultOgImagePath", "DefaultTitle", "FacebookPixelId", "GoogleAnalyticsId", "GoogleTagManagerId", "RobotsTxtContent", "SiteName" },
                values: new object[] { 1, "Gurvent, santrifüj, aksiyel ve ATEX sertifikalı endüstriyel fan üretiminde liderdir. Enerji verimli ve uzun ömürlü çözümler için doğru adres.", "endüstriyel fan, havalandırma, santrifüj fan, ATEX, filtrasyon, toz toplama, enerji verimliliği, gurvent", "/img/seo/default-image.jpg", "Gurvent Vantilatör | Endüstriyel Fan ve Havalandırma Sistemleri", "999888777", "G-GURVENT1234", "GTM-GURVENT01", "User-agent: *\nAllow: /", "Gurvent Vantilatör" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "ContentImage1Path", "ContentImage2Path", "Description", "ExtraDescription", "ExtraTitle", "LogoPath", "MainImagePath", "Name", "Title" },
                values: new object[,]
                {
                    { 1, "/img/service/fan-uretim2.jpg", "/img/service/fan-uretim3.jpg", "Gurvent, endüstriyel ihtiyaçlara özel olarak santrifüj, aksiyel, kanal tipi ve çatı tipi fan üretimi yapmaktadır. Üretim sürecinde yüksek verimli motorlar, kaliteli malzeme ve modern üretim teknolojileri kullanılmaktadır.", "Tüm fanlarımız uluslararası standartlara uygun olarak test edilmekte, uzun ömürlü ve sessiz çalışma prensipleriyle üretilmektedir. Müşteri taleplerine göre özel boyut ve kapasitede üretim yapılabilmektedir.", "Kalite ve Güvenilirlik Odaklı Üretim", "/img/service/fan-logo1.png", "/img/service/fan-uretim1.jpg", "Endüstriyel Fan Üretimi", "Yüksek Performanslı Endüstriyel Fan Sistemleri" },
                    { 2, "/img/service/havalandirma2.jpg", "/img/service/havalandirma3.jpg", "Endüstriyel tesisler, otoparklar, restoranlar ve üretim alanları için havalandırma sistemlerinin mühendislik hesapları, proje tasarımı ve montaj süreçlerini anahtar teslim gerçekleştiriyoruz.", "Hava debisi, statik basınç ve ses seviyesi kriterlerine uygun sistem tasarımları yaparak işletmelerde maksimum enerji verimliliği sağlıyoruz.", "Mühendislik Odaklı Yaklaşım", "/img/service/havalandirma-logo.png", "/img/service/havalandirma1.jpg", "Havalandırma Sistemleri Tasarımı ve Montajı", "Verimli ve Sessiz Havalandırma Çözümleri" },
                    { 3, "/img/service/fan-uretim2.jpg", "/img/service/fan-uretim3.jpg", "Deneyimli teknik ekibimiz, arızalı veya performansı düşen fanların bakım ve onarımını orijinal yedek parçalarla gerçekleştirir. Dengeleme, rulman değişimi ve balans ayarları yapılmaktadır.", "Türkiye genelinde yerinde servis hizmeti sunuyor, fanlarınızın uzun ömürlü çalışmasını garanti altına alıyoruz.", "Yerinde Servis Desteği", "/img/service/bakim-logo.png", "/img/service/fan-uretim1.jpg", "Fan Bakım ve Onarım Hizmetleri", "Tüm Marka Fanlarda Profesyonel Bakım ve Onarım" },
                    { 4, "/img/service/havalandirma2.jpg", "/img/service/havalandirma3.jpg", "Üretim tesislerinde oluşan toz, duman ve partikül kirliliğini minimize etmek için gelişmiş filtrasyon sistemleri tasarlayıp kuruyoruz.", "Kompakt tasarımlar, yüksek filtrasyon verimi ve kolay bakım özellikleriyle işletmelerde hijyen ve güvenliği artırıyoruz.", "Enerji Verimli Filtrasyon Teknolojisi", "/img/service/filtrasyon-logo.png", "/img/service/havalandirma1.jpg", "Hava Filtrasyon ve Toz Toplama Sistemleri", "Temiz ve Sağlıklı Çalışma Ortamları İçin Filtrasyon Çözümleri" },
                    { 5, "/img/service/fan-uretim2.jpg", "/img/service/fan-uretim3.jpg", "Müşterilerimizin özel ihtiyaçlarına yönelik fan ve havalandırma sistemleri geliştiriyoruz. Yüksek sıcaklık, korozyon veya patlama riski gibi özel çalışma koşullarına uygun çözümler üretiyoruz.", "Ar-Ge ekibimiz, aerodinamik verimlilik, enerji tasarrufu ve sessiz çalışma için sürekli olarak yeni teknolojiler üzerinde çalışmaktadır.", "Mühendislikte Yenilikçi Yaklaşım", "/img/service/arge-logo.png", "/img/service/fan-uretim1.jpg", "Ar-Ge ve Özel Üretim Çözümleri", "İhtiyaca Özel Fan ve Havalandırma Sistemleri" }
                });

            migrationBuilder.InsertData(
                table: "SiteInfo",
                columns: new[] { "Id", "Address", "CompanyName", "CompanyOwner", "Email1", "Email2", "Fax1", "Fax2", "GoogleMapsApi", "LogoPath", "Phone1", "Phone2", "SiteInformation", "SiteName", "SiteOwner", "TNumber", "TaxNumber", "TaxOffice", "WaNumber", "WaSupportNumber", "WorkingHours" },
                values: new object[] { 1, "Atatürk Organize Sanayi Bölgesi, 10032 Sokak No:15, Çiğli / İzmir", "Gurvent Vantilatör ve Mühendislik A.Ş.", "Gürbüz Teknik", "info@gurvent.com.tr", "teknik@gurvent.com.tr", "+90 232 400 55 23", null, "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3000.458293!2d27.133!3d38.435!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14b970a6d8!2sGurvent%20Vantilatör!5e0!3m2!1str!2str!4v1712345678901!5m2!1str!2str", "/img/site-info/gurvent-logo.png", "+90 232 400 55 22", "+90 532 600 44 11", "Gurvent, endüstriyel fan ve havalandırma sistemleri alanında yenilikçi, enerji verimli ve yüksek performanslı çözümler sunar.", "Gurvent Vantilatör", "Gurvent Mühendislik A.Ş.", "+90 532 600 44 11", "4567891230", "İzmir Vergi Dairesi", "+90 532 600 44 11", "", "Hafta içi: 08:30 - 18:00, Cumartesi: 08:30 - 13:00" });

            migrationBuilder.InsertData(
                table: "Sliders",
                columns: new[] { "Id", "ImagePath", "Subtitle", "Tag", "Title" },
                values: new object[,]
                {
                    { 1, "/img/slider/factory1.jpg", "Güçlü mühendislik, kaliteli üretim, maksimum verim.", "Üretim", "Endüstriyel Fan Üretiminde 40 Yıllık Tecrübe" },
                    { 2, "/img/slider/ventilation1.jpg", "Enerji verimli, sessiz ve güvenilir sistemler.", "Havalandırma", "Havalandırma Sistemlerinde Profesyonel Çözümler" },
                    { 3, "/img/slider/filtration1.jpg", "Toz toplama ve hava filtrasyon sistemlerinde lider marka.", "Filtrasyon", "Temiz Hava, Sağlıklı Çalışma Ortamı" },
                    { 4, "/img/slider/service1.jpg", "Her marka fan için profesyonel servis desteği.", "Servis", "Bakım ve Onarımda Güvenilir Hizmet" }
                });

            migrationBuilder.InsertData(
                table: "SocialMediaInfo",
                columns: new[] { "Id", "Facebook", "Instagram", "Linkedin", "Tiktok", "Vimeo", "Vk", "X", "Youtube" },
                values: new object[] { 1, "https://facebook.com/gurventvantilator", "https://instagram.com/gurventvantilator", null, "https://tiktok.com/@gurventvantilator", null, null, "https://x.com/gurventfan", "https://youtube.com/@gurventvantilator" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Enerji Verimli Fan" },
                    { 2, "ATEX Sertifikalı" },
                    { 3, "Santrifüj Fan" },
                    { 4, "Filtrasyon" },
                    { 5, "Hava Kalitesi" },
                    { 6, "Bakım ve Servis" }
                });

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "Id", "Biography", "Email", "Experience", "Facebook", "FullName", "ImagePath", "Instagram", "Linkedin", "Phone", "Skills", "Title", "Twitter", "Website", "Youtube" },
                values: new object[] { 1, "Makine mühendisi olarak 30 yılı aşkın süredir endüstriyel fan tasarımı ve üretimi alanında faaliyet göstermektedir. Enerji verimli sistemler konusunda uzmandır.", "gurbuz.yilmaz@gurvent.com.tr", "30+ yıl endüstriyel fan üretimi ve mühendislik tecrübesi.", "https://facebook.com/gurventvantilator", "Gürbüz Yılmaz", "/img/team-member/gurbuz-yilmaz.jpg", "https://instagram.com/gurventvantilator", "https://linkedin.com/in/gurbuzyilmaz", "+90 532 600 44 11", "[\"Mekanik Tasarım\", \"Fan Mühendisliği\", \"Proje Yönetimi\", \"Üretim Süreçleri\"]", "Kurucu & Genel Müdür", "https://x.com/gurventfan", "https://www.gurvent.com.tr", "https://youtube.com/@gurventvantilator" });

            migrationBuilder.InsertData(
                table: "Testimonials",
                columns: new[] { "Id", "Comment", "FullName", "ImagePath", "Rating", "Title" },
                values: new object[,]
                {
                    { 1, "Yeni fan sistemimiz sayesinde üretim alanımızdaki hava kalitesi belirgin şekilde arttı. Montaj ekibi profesyonel çalıştı.", "Mehmet Koç", "/img/testimonial/client1.jpg", 5, "Fabrika Müdürü" },
                    { 2, "Projeye özel fan tasarımı istedik, kısa sürede üretildi ve tam istediğimiz performansı sağladı.", "Ayşe Güler", "/img/testimonial/client2.jpg", 5, "Proje Mühendisi" },
                    { 3, "Fan bakım hizmetleri hızlı ve güvenilir. Arızalı fanlarımız 2 gün içinde teslim edildi.", "Serkan Demirtaş", "/img/testimonial/client3.jpg", 4, "Tesis Sorumlusu" },
                    { 4, "Filtrasyon sistemi kurulumu çok başarılı oldu. Artık toz oranı minimuma indi.", "Derya Akın", "/img/testimonial/client4.jpg", 5, "Endüstriyel Tesis Yöneticisi" },
                    { 5, "Yüksek sıcaklık fanları projemizde kullanıldı. Dayanıklılığı ve sessiz çalışması bizi etkiledi.", "Kemal Aydın", "/img/testimonial/client5.jpg", 5, "Makine Bakım Müdürü" }
                });

            migrationBuilder.InsertData(
                table: "VisionMission",
                columns: new[] { "Id", "MissionDescription", "MissionImagePath", "MissionTitle", "VisionDescription", "VisionImagePath", "VisionTitle" },
                values: new object[] { 1, "Müşterilerimize güvenilir, yenilikçi ve mühendislik odaklı havalandırma çözümleri sunmak; üretim kalitemizi sürekli geliştirerek endüstriye değer katmak.", "/img/vision-mission/factory-mission.jpg", "Misyonumuz", "Enerji verimliliği yüksek, çevreye duyarlı fan sistemleriyle Türkiye’nin ve dünyanın lider havalandırma çözümleri üreticisi olmak.", "/img/vision-mission/factory-vision.jpg", "Vizyonumuz" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "CategoryId", "ContentImage1Path", "ContentImage2Path", "CreatedAt", "Description", "EntryDescription", "EntryTitle", "ExtraDescription", "ExtraTitle", "FullName", "MainImagePath", "Quote", "QuoteSource", "Subtitle", "Title", "YoutubeVideoUrl" },
                values: new object[,]
                {
                    { 1, 1, "/img/blog/energy2.jpg", "/img/blog/energy3.jpg", new DateTime(2025, 9, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Enerji verimliliği, modern fan sistemlerinin en kritik tasarım kriterlerinden biridir. Gurvent olarak yüksek verimli motorlar, optimize edilmiş fan kanatları ve akıllı kontrol sistemleri kullanıyoruz.", "Yüksek verimli fan sistemleri, düşük enerji tüketimiyle maksimum hava debisi sağlar.", "Enerji Verimli Fan Nedir?", "Motor verimi, aerodinamik kanat tasarımı ve frekans invertörü kullanımı ile sistemlerde %30’a kadar enerji tasarrufu sağlanabilir.", "Verimliliği Artıran Faktörler", "Gurvent Editör", "/img/blog/energy1.jpg", "Verimlilik, sürdürülebilir üretimin temelidir.", "Gürbüz Yılmaz", "Daha az enerjiyle daha fazla performans", "Endüstriyel Fanlarda Enerji Verimliliği", "https://www.youtube.com/watch?v=aKx3Wxz3E5M" },
                    { 2, 2, "/img/blog/atex2.jpg", "/img/blog/atex3.jpg", new DateTime(2025, 9, 10, 11, 30, 0, 0, DateTimeKind.Unspecified), "ATEX standartları, yanıcı ve patlayıcı gazların bulunduğu ortamlarda fanların güvenli çalışmasını sağlar. Gurvent, ATEX direktiflerine uygun fan üretiminde uzmanlaşmıştır.", "Avrupa Birliği tarafından belirlenen ATEX standardı, patlayıcı ortamlarda kullanılan ekipmanların güvenliğini tanımlar.", "ATEX Standardı Nedir?", "Yüksek güvenlik seviyesi, uzun ömür ve uluslararası uyumluluk sağlar.", "ATEX Fanların Avantajları", "Gurvent Editör", "/img/blog/atex1.jpg", "Güvenlik, verimlilik kadar önemlidir.", "Gurvent Ar-Ge Ekibi", "Patlayıcı ortamlarda güvenli hava akışı", "ATEX Sertifikalı Fanlar Hakkında Bilmeniz Gerekenler", "https://www.youtube.com/watch?v=r9C6n3lM1Ck" },
                    { 3, 3, "/img/blog/filter2.jpg", "/img/blog/filter3.jpg", new DateTime(2025, 9, 15, 14, 15, 0, 0, DateTimeKind.Unspecified), "Toz toplama ve filtrasyon sistemleri, endüstriyel tesislerde hava kalitesini korur. Gurvent, kompakt ve yüksek verimli sistemlerle çevre dostu çözümler sunar.", "Üretim alanında toz yoğunluğu, çalışan sağlığı ve ekipman ömrünü doğrudan etkiler.", "Toz Kontrolünün Önemi", "Yüksek kaliteli filtre malzemeleri ve doğru sistem tasarımı ile %99’a varan filtrasyon oranı elde edilir.", "Filtrasyon Verimini Artırma Yöntemleri", "Gurvent Editör", "/img/blog/filter1.jpg", "Temiz hava, üretkenliğin temelidir.", "Gurvent Filtrasyon Ekibi", "Sağlıklı çalışma alanları için etkili çözümler", "Filtrasyon Sistemlerinde Toz Kontrolü", "https://www.youtube.com/watch?v=yPD7kBfxEZM" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedAt", "Description", "ImagePath", "IsActive", "Name", "Order", "ParentCategoryId", "UpdatedAt" },
                values: new object[,]
                {
                    { 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, "Metal Fanlar", 1, 1, null },
                    { 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, "Plastik Fanlar", 2, 1, null }
                });

            migrationBuilder.InsertData(
                table: "ProjectFeatures",
                columns: new[] { "Id", "Name", "ProjectId" },
                values: new object[,]
                {
                    { 1, "Yüksek debili santrifüj fanlar", 1 },
                    { 2, "Enerji verimli motor sistemi", 1 },
                    { 3, "Otomasyon kontrol paneli", 1 },
                    { 4, "Sessiz çalışma standardı", 1 },
                    { 5, "HEPA filtre entegrasyonu", 2 },
                    { 6, "Hijyenik paslanmaz fan gövdesi", 2 },
                    { 7, "Sürekli çalışma için optimize motor", 2 },
                    { 8, "Düşük gürültü seviyesi (<45 dB)", 2 },
                    { 9, "ATEX sertifikalı fan üretimi", 3 },
                    { 10, "Korozyona dayanıklı malzeme", 3 },
                    { 11, "Yüksek sıcaklığa dayanıklı yataklama", 3 },
                    { 12, "Basınç kontrollü hava akışı", 3 }
                });

            migrationBuilder.InsertData(
                table: "ServiceFaqs",
                columns: new[] { "Id", "Answer", "Question", "ServiceId" },
                values: new object[,]
                {
                    { 1, "Santrifüj, aksiyel, çatı tipi, kanal tipi ve özel amaçlı fanlar üretiyoruz.", "Fanlarınız hangi türlerde üretiliyor?", 1 },
                    { 2, "Galvaniz, alüminyum ve paslanmaz çelik gövdeli modellerimiz bulunmaktadır. Kullanım alanına göre özel kaplama seçenekleri sunuyoruz.", "Fan üretiminde hangi malzemeleri kullanıyorsunuz?", 1 },
                    { 3, "Tüm fanlarımız balans testlerinden geçirilir ve düşük gürültü seviyesiyle çalışacak şekilde tasarlanır.", "Fanlarınız sessiz çalışıyor mu?", 1 },
                    { 4, "Tüm ürünlerimiz 2 yıl üretim hatalarına karşı garanti kapsamındadır.", "Fanlarınızın garanti süresi nedir?", 1 },
                    { 5, "Fabrikalar, otoparklar, restoranlar, hastaneler, atölyeler ve AVM’ler için sistem tasarımı ve montajı yapıyoruz.", "Hangi alanlara havalandırma sistemi kuruyorsunuz?", 2 },
                    { 6, "Evet, mühendis ekibimiz ücretsiz keşif ve debi hesabı hizmeti sunmaktadır.", "Proje öncesi keşif hizmetiniz var mı?", 2 },
                    { 7, "Sistemlerimizi enerji tasarrufu sağlayacak şekilde mühendislik hesaplarıyla optimize ediyoruz.", "Havalandırma sistemi enerji verimli mi?", 2 },
                    { 8, "Proje büyüklüğüne göre değişmekle birlikte ortalama 3 ila 10 iş günü arasında tamamlanır.", "Montaj süresi ne kadar sürer?", 2 },
                    { 9, "Evet, marka bağımsız olarak tüm endüstriyel fanların bakım ve onarımını yapıyoruz.", "Tüm marka fanlara bakım yapıyor musunuz?", 3 },
                    { 10, "Özel balans cihazlarımızla fanlar yerinde veya atölyemizde dengelenir.", "Fan balans ayarı nasıl yapılır?", 3 },
                    { 11, "Evet, işletmelere özel yıllık bakım sözleşmeleri sunuyoruz.", "Periyodik bakım hizmeti sunuyor musunuz?", 3 },
                    { 12, "Genellikle 1-3 iş günü içinde bakım ve test süreci tamamlanır.", "Arızalı fan ne kadar sürede onarılır?", 3 },
                    { 13, "0.3 mikrona kadar olan partikülleri yüksek verimli filtrelerle tutabiliyoruz.", "Filtrasyon sisteminiz hangi partikül boyutlarını tutar?", 4 },
                    { 14, "Kullanım yoğunluğuna bağlı olarak genellikle 3 ila 6 ayda bir değişim önerilmektedir.", "Filtre değişim sıklığı nedir?", 4 },
                    { 15, "Evet, düşük basınç kayıplı tasarımlar sayesinde enerji verimliliği sağlıyoruz.", "Toz toplama sistemleri enerji tasarruflu mu?", 4 },
                    { 16, "Keşif sonrası mühendislik çizimleri yapılır, ardından üretim ve montaj aşamasına geçilir.", "Kurulum süreci nasıl ilerliyor?", 4 },
                    { 17, "Evet, proje ihtiyaçlarına göre özel çap, debi ve motor güçlerinde fan üretimi yapabiliyoruz.", "Özel boyutlarda fan üretimi yapıyor musunuz?", 5 },
                    { 18, "Evet, 300°C’ye kadar dayanıklı fan çözümlerimiz mevcuttur.", "Yüksek sıcaklığa dayanıklı fanlarınız var mı?", 5 },
                    { 19, "Patlayıcı ortamlarda kullanılabilecek ATEX standartlarına uygun fan üretimi yapıyoruz.", "ATEX sertifikalı fan üretiyor musunuz?", 5 },
                    { 20, "Hava debisi, statik basınç, gürültü ve titreşim testleri düzenli olarak gerçekleştirilmektedir.", "Ar-Ge sürecinde hangi testler yapılıyor?", 5 }
                });

            migrationBuilder.InsertData(
                table: "ServiceFeatures",
                columns: new[] { "Id", "Name", "ServiceId", "Value" },
                values: new object[,]
                {
                    { 1, "Yüksek verimli motor teknolojisi", 1, null },
                    { 2, "Sessiz çalışma prensibi", 1, null },
                    { 3, "Uzun ömürlü rulman sistemi", 1, null },
                    { 4, "Farklı kapasite ve ölçü seçenekleri", 1, null },
                    { 5, "Enerji verimli sistem tasarımı", 2, null },
                    { 6, "Projeye özel mühendislik hesapları", 2, null },
                    { 7, "Profesyonel montaj ekibi", 2, null },
                    { 8, "Bina otomasyon sistemleri entegrasyonu", 2, null },
                    { 9, "Yerinde servis hizmeti", 3, null },
                    { 10, "Balans ve titreşim kontrolü", 3, null },
                    { 11, "Rulman ve kayış değişimi", 3, null },
                    { 12, "Periyodik bakım sözleşmesi imkanı", 3, null },
                    { 13, "Yüksek filtrasyon verimliliği", 4, null },
                    { 14, "Düşük enerji tüketimi", 4, null },
                    { 15, "Kompakt ve modüler tasarım", 4, null },
                    { 16, "Kolay bakım ve temizlik", 4, null },
                    { 17, "Yüksek sıcaklığa dayanıklı fan tasarımları", 5, null },
                    { 18, "Korozyona dayanıklı malzeme kullanımı", 5, null },
                    { 19, "Sessiz çalışma optimizasyonu", 5, null },
                    { 20, "Prototip geliştirme ve performans testleri", 5, null }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BlogId", "CreatedAt", "FullName", "IsApproved", "Text" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 9, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Mehmet Akın", true, "Enerji verimliliği konusunda çok bilgilendirici bir içerik, teşekkürler!" },
                    { 2, 2, new DateTime(2025, 9, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Selin Yılmaz", true, "ATEX hakkında net bilgiler bulmak zordu, bu makale çok yardımcı oldu." },
                    { 3, 3, new DateTime(2025, 9, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Ali Demirtaş", true, "Filtrasyon sistemlerinin bu kadar etkili olabileceğini bilmiyordum." }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AirFlow", "AirFlowUnit", "Code", "ContentDescription", "ContentTitle", "CreatedAt", "DataSheetPath", "Description", "Diameter", "DiameterUnit", "Frequency", "Image1Path", "Image2Path", "Image3Path", "Image4Path", "Image5Path", "IsActive", "Model3DPath", "Name", "NoiseLevel", "NoiseLevelUnit", "Order", "Power", "PowerUnit", "Pressure", "PressureUnit", "ProductCategoryId", "ScaleImagePath", "Speed", "SpeedControl", "SpeedUnit", "TestDataPath", "UpdatedAt", "Voltage" },
                values: new object[,]
                {
                    { 1, 200.0, "m³/h", "25", "RSD serisi fanlar, gelişmiş kanat geometrisi sayesinde düşük enerji tüketimiyle maksimum hava debisi sağlar. Bu tasarım, sessiz ve verimli çalışma performansı sunar.", "Yüksek Verimli Fan Teknolojisi", new DateTime(2025, 9, 10, 14, 30, 0, 0, DateTimeKind.Unspecified), "/datasheet/product/RSD25.pdf", "Tek emişli Santrifuj gövdeye direk akuple bağlanmış geriye eğik seyrek aerofoil kanatlıdır. 80⁰C de daimi çalışmaya uygundur. Hafif hizmet modelidir. Gövde 4 değişik açıda çalışmaya uygun yapıya sahiptir ( 90⁰ - 180⁰ – 270 ⁰ – 360⁰ ). Detaylar Data-sheet sayfasında belirtilmiştir.", 100.0, "mm", 50.0, "/img/product/product1.webp", "/img/product/product1.webp", "/img/product/product1.webp", "/img/product/product1.webp", "/img/product/product1.webp", true, "/model/product/RSD25.glb", "RSD25", 65.0, "dB(A)", 1, 0.25, "kW", 50.0, "Pa", 2, "img/product/product1.webp", 2800.0, "Hz - Frequency", "rpm", "/test-data/product/RSD25.xslx", null, 220.0 },
                    { 2, 200.0, "m³/h", "22P2", "Galvaniz kaplama çelik gövde yapısı sayesinde uzun ömürlü kullanım sunar. Korozyon ve dış etkenlere karşı yüksek direnç gösterir, bakım ihtiyacını en aza indirir.", "Dayanıklı Gövde Yapısı", new DateTime(2025, 9, 10, 14, 30, 0, 0, DateTimeKind.Unspecified), "/datasheet/product/RSD22P2.pdf", "Tek emişli Santrifuj gövdeye direk akuple bağlanmış geriye eğik seyrek aerofoil kanatlıdır. 80⁰C de daimi çalışmaya uygundur. Hafif hizmet modelidir. Gövde 4 değişik açıda çalışmaya uygun yapıya sahiptir ( 90⁰ - 180⁰ – 270 ⁰ – 360⁰ ). Detaylar Data-sheet sayfasında belirtilmiştir.", 100.0, "mm", 50.0, "/img/product/product2.webp", "/img/product/product2.webp", "/img/product/product2.webp", "/img/product/product2.webp", "/img/product/product2.webp", true, "/model/product/RSD22P2.glb", "RSD 22P2", 65.0, "dB(A)", 2, 0.25, "kW", 50.0, "Pa", 3, "img/product/product1.webp", 2800.0, "Hz - Frequency", "rpm", "/test-data/product/RSD22P2.xslx", null, 220.0 },
                    { 3, 200.0, "m³/h", "20B2", "IE2 verimlilik sınıfına sahip motor, 80°C’de sürekli çalışmaya uygundur. Titreşim seviyesi minimize edilmiştir ve sessiz çalışma için özel dengeleme sistemi bulunur.", "Motor Performansı ve Güvenilirlik", new DateTime(2025, 9, 10, 14, 30, 0, 0, DateTimeKind.Unspecified), "/datasheet/product/RSD20B2.pdf", "Tek emişli Santrifuj gövdeye direk akuple bağlanmış geriye eğik seyrek aerofoil kanatlıdır. 80⁰C de daimi çalışmaya uygundur. Hafif hizmet modelidir. Gövde 4 değişik açıda çalışmaya uygun yapıya sahiptir ( 90⁰ - 180⁰ – 270 ⁰ – 360⁰ ). Detaylar Data-sheet sayfasında belirtilmiştir.", 100.0, "mm", 50.0, "/img/product/product3.webp", "/img/product/product3.webp", "/img/product/product3.webp", "/img/product/product3.webp", "/img/product/product3.webp", true, "/model/product/RSD20B2.glb", "RSD 20B2", 65.0, "dB(A)", 3, 0.25, "kW", 50.0, "Pa", 3, "img/product/product1.webp", 2800.0, "Hz - Frequency", "rpm", "/test-data/product/RSD20B2.xslx", null, 220.0 },
                    { 4, 200.0, "m³/h", "18B2", "Fan gövdesi, 90°, 180°, 270° ve 360° açılarda çalışmaya uygun şekilde tasarlanmıştır. Bu özellik, farklı uygulama senaryolarında kolay montaj ve kurulum avantajı sağlar.", "Kolay Montaj ve Esnek Kullanım", new DateTime(2025, 9, 10, 14, 30, 0, 0, DateTimeKind.Unspecified), "/datasheet/product/RSD18B2.pdf", "Tek emişli Santrifuj gövdeye direk akuple bağlanmış geriye eğik seyrek aerofoil kanatlıdır. 80⁰C de daimi çalışmaya uygundur. Hafif hizmet modelidir. Gövde 4 değişik açıda çalışmaya uygun yapıya sahiptir ( 90⁰ - 180⁰ – 270 ⁰ – 360⁰ ). Detaylar Data-sheet sayfasında belirtilmiştir.", 100.0, "mm", 50.0, "/img/product/product4.webp", "/img/product/product4.webp", "/img/product/product4.webp", "/img/product/product4.webp", "/img/product/product4.webp", true, "/model/product/RSD18B2.glb", "RSD 18B2", 65.0, "dB(A)", 4, 0.25, "kW", 50.0, "Pa", 3, "img/product/product1.webp", 2800.0, "Hz - Frequency", "rpm", "/test-data/product/RSD18B2.xslx", null, 220.0 }
                });

            migrationBuilder.InsertData(
                table: "ProductContentFeatures",
                columns: new[] { "Id", "Key", "Order", "ProductId", "Value" },
                values: new object[,]
                {
                    { 1, "Fan Tipi", 1, 1, "Santrifüj Geriye Eğik Kanatlı" },
                    { 2, "Gövde Yapısı", 2, 1, "Galvaniz kaplama çelik gövde" },
                    { 3, "Motor Tipi", 3, 1, "Direk akuple, 80°C sürekli çalışma" },
                    { 4, "Fan Tipi", 1, 2, "Geriye eğik seyrek aerofoil kanatlı" },
                    { 5, "Malzeme", 2, 2, "Alüminyum pervane, çelik gövde" },
                    { 6, "Kullanım Alanı", 3, 2, "Havalandırma ve soğutma sistemleri" },
                    { 7, "Fan Tipi", 1, 3, "Tek emişli santrifüj fan" },
                    { 8, "Montaj Açısı", 2, 3, "4 farklı açıda çalışmaya uygun (90°,180°,270°,360°)" },
                    { 9, "Verimlilik", 3, 3, "Yüksek statik basınç ve düşük gürültü" },
                    { 10, "Fan Tipi", 1, 4, "Geriye eğik seyrek aerofoil kanatlı" },
                    { 11, "Motor Sınıfı", 2, 4, "IP55 koruma sınıfı, IE2 verimlilik" },
                    { 12, "Uygulama", 3, 4, "Hafif hizmet tipi sanayi havalandırması" }
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
                name: "IX_ProductCategories_ParentCategoryId",
                table: "ProductCategories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductContentFeatures_ProductId",
                table: "ProductContentFeatures",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductApplications_ProductsId",
                table: "ProductProductApplications",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTestData_ProductId",
                table: "ProductTestData",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFeatures_ProjectId",
                table: "ProjectFeatures",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceFaqs_ServiceId",
                table: "ServiceFaqs",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceFeatures_ServiceId",
                table: "ServiceFeatures",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
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
                name: "ProductContentFeatures");

            migrationBuilder.DropTable(
                name: "ProductProductApplications");

            migrationBuilder.DropTable(
                name: "ProductTestData");

            migrationBuilder.DropTable(
                name: "ProjectFeatures");

            migrationBuilder.DropTable(
                name: "RoleClaims");

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
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "VersionInfos");

            migrationBuilder.DropTable(
                name: "VisionMission");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "ProductApplications");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}
