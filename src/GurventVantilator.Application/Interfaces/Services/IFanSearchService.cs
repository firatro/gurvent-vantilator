
namespace GurventVantilator.Application.Interfaces.Services
{
    public interface IFanSearchService
    {
        Task<List<FanSearchResultDto>> SearchByAirFlowAsync(
      double airFlow,
      double? totalPressure,
      int tolerancePercent,
      SpeedControlType speedControl,
      int? usageId,
      int? workingId
  );


    }
}
