using GurventVantilator.Application.Common;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace GurventVantilator.Application.Services
{
    public class DashboardManager : IDashboardService
    {
        private readonly IContactService _contactService;
        private readonly IBlogService _blogService;
        private readonly IChatBotQAService _chatBotService;
        private readonly ITeamMemberService _teamService;
        private readonly IBeforeAfterService _beforeAfterService;
        private readonly IServiceService _serviceService;
        private readonly ILogger<DashboardManager> _logger;

        public DashboardManager(
            IContactService contactService,
            IBlogService blogService,
            IChatBotQAService chatBotService,
            ITeamMemberService teamService,
            IBeforeAfterService beforeAfterService,
            IServiceService serviceService,
            ILogger<DashboardManager> logger)
        {
            _contactService = contactService;
            _blogService = blogService;
            _chatBotService = chatBotService;
            _teamService = teamService;
            _beforeAfterService = beforeAfterService;
            _serviceService = serviceService;
            _logger = logger;
        }

        public async Task<Result<DashboardDto>> GetDashboardAsync()
        {
            try
            {
                // Servislerden verileri al
                var contacts = await _contactService.GetAllAsync();
                var blogs = await _blogService.GetAllAsync();
                var chatbotQAs = await _chatBotService.GetAllAsync();
                var teamMembers = await _teamService.GetAllAsync();
                var beforeAfters = await _beforeAfterService.GetAllAsync();
                var services = await _serviceService.GetAllAsync();

                // Başarısız bir çağrı olursa hata dön
                if (!contacts.Success || !blogs.Success || !chatbotQAs.Success ||
                    !teamMembers.Success || !beforeAfters.Success || !services.Success)
                {
                    return Result<DashboardDto>.Fail("Dashboard verileri alınamadı.");
                }

                var dto = new DashboardDto
                {
                    TotalContacts = contacts.Data.Count(),
                    TotalBlogs = blogs.Data.Count(),
                    TotalChatBotQnAs = chatbotQAs.Data.Count(),
                    TotalTeamMembers = teamMembers.Data.Count(),
                    TotalBeforeAfter = beforeAfters.Data.Count(),
                    TotalServices = services.Data.Count(),

                    LatestContacts = contacts.Data
                        .OrderByDescending(x => x.CreatedAt)
                        .Take(5).ToList(),

                    LatestBlogs = blogs.Data
                        .OrderByDescending(x => x.CreatedAt)
                        .Take(5).ToList(),

                    LatestTeamMembers = teamMembers.Data
                        .OrderByDescending(x => x.Id)
                        .Take(5).ToList(),

                    LatestServices = services.Data
                        .OrderByDescending(x => x.Id)
                        .Take(5).ToList()
                };

                return Result<DashboardDto>.Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Dashboard verileri alınırken hata oluştu.");
                return Result<DashboardDto>.Fail("Beklenmeyen bir hata oluştu.");
            }
        }
    }
}
