using GurventVantilator.Application.Interfaces;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Application.Services;
using GurventVantilator.Application.Services.GurventVantilator.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GurventVantilator.Application.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IServiceService, ServiceManager>();
            services.AddScoped<IServiceFeatureService, ServiceFeatureManager>();
            services.AddScoped<IServiceFaqService, ServiceFaqManager>();
            services.AddScoped<ITestimonialService, TestimonialManager>();
            services.AddScoped<IProjectService, ProjectManager>();
            services.AddScoped<IProjectFeatureService, ProjectFeatureManager>();
            services.AddScoped<IAboutUsService, AboutUsManager>();
            services.AddScoped<ISiteInfoService, SiteInfoManager>();
            services.AddScoped<ISocialMediaInfoService, SocialMediaInfoManager>();
            services.AddScoped<ICompanyService, CompanyManager>();
            services.AddScoped<ISliderService, SliderManager>();
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IFaqService, FaqManager>();
            services.AddScoped<IVisionMissionService, VisionMissionManager>();
            services.AddScoped<ITeamMemberService, TeamMemberManager>();
            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ITagService, TagManager>();
            services.AddScoped<IMenuService, MenuManager>();
            services.AddScoped<IBeforeAfterService, BeforeAfterManager>();
            services.AddScoped<ISeoSettingService, SeoSettingManager>();
            services.AddScoped<IChatBotQAService, ChatBotQAManager>();
            services.AddScoped<IDashboardService, DashboardManager>();
            services.AddScoped<IPageImageService, PageImageManager>();
            services.AddScoped<IVersionInfoService, VersionInfoManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductSeriesService, ProductSeriesManager>();
            services.AddScoped<IProductModelService, ProductModelManager>();
            services.AddScoped<IProductUsageTypeService, ProductUsageTypeManager>();
            services.AddScoped<IProductWorkingConditionService, ProductWorkingConditionManager>();
            services.AddScoped<IProductTestDataService, ProductTestDataManager>();
            services.AddScoped<IProductContentFeatureService, ProductContentFeatureManager>();
            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IProductModelDocumentService, ProductModelDocumentManager>();
            services.AddScoped<IFanChartService, FanChartManager>();
            services.AddScoped<IWorkingPointService, WorkingPointManager>();
            services.AddScoped<IFanSearchService, FanSearchManager>();
            services.AddScoped<IProductAccessoryService, ProductAccessoryManager>();

            return services;
        }
    }
}
