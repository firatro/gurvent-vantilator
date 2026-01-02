

using GurventVantilator.Application.Interfaces.Repositories;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Domain.Interfaces.Repositories;
using GurventVantilator.Infrastructure.Data;
using GurventVantilator.Infrastructure.Data.Repositories;
using GurventVantilator.Infrastructure.Identity;
using GurventVantilator.Infrastructure.Persistence.Repositories;
using GurventVantilator.Infrastructure.Repositories;
using GurventVantilator.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GurventVantilator.Infrastructure.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // DbContext kaydı
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Repository kayıtları
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IServiceFeatureRepository, FeatureRepository>();
            services.AddScoped<IServiceFaqRepository, ServiceFaqRepository>();
            services.AddScoped<ITestimonialRepository, TestimonialRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectFeatureRepository, ProjectFeatureRepository>();
            services.AddScoped<IAboutUsRepository, AboutUsRepository>();
            services.AddScoped<ISiteInfoRepository, SiteInfoRepository>();
            services.AddScoped<ISocialMediaInfoRepository, SocialMediaInfoRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ISliderRepository, SliderRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IFaqRepository, FaqRepository>();
            services.AddScoped<IVisionMissionRepository, VisionMissionRepository>();
            services.AddScoped<ITeamMemberRepository, TeamMemberRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IBeforeAfterRepository, BeforeAfterRepository>();
            services.AddScoped<ISeoSettingRepository, SeoSettingRepository>();
            services.AddScoped<IChatBotQARepository, ChatBotQARepository>();
            services.AddScoped<IPageImageRepository, PageImageRepository>();
            services.AddScoped<IVersionInfoRepository, VersionInfoRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductUsageTypeRepository, ProductUsageTypeRepository>();
            services.AddScoped<IProductWorkingConditionRepository, ProductWorkingConditionRepository>();
            services.AddScoped<IProductModelRepository, ProductModelRepository>();
            services.AddScoped<IProductSeriesRepository, ProductSeriesRepository>();
            services.AddScoped<IProductTestDataRepository, ProductTestDataRepository>();
            services.AddScoped<IProductContentFeatureRepository, ProductContentFeatureRepository>();
            services.AddScoped<IProductModelDocumentRepository, ProductModelDocumentRepository>();
            services.AddScoped<IProductTestDataPointRepository, ProductTestDataPointRepository>();
            services.AddScoped<IProductAccessoryRepository, ProductAccessoryRepository>();

            // File Upload
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IFileValidator, FileValidator>();

            // Authentication Kayıtları
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services
                .AddIdentity<ApplicationUser, ApplicationRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredLength = 6;
                    options.User.RequireUniqueEmail = true;
                    options.SignIn.RequireConfirmedAccount = false;
                })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/AccessDenied";

                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromHours(8);

            });

            return services;
        }
    }
}
