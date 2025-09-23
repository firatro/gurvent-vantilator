using GurventVantilator.Application.Common;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface IDashboardService
    {
        Task<Result<DashboardDto>> GetDashboardAsync();
    }
}
