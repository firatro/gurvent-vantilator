using GurventVantilator.Application.DTOs.Charts;

public interface IFanChartService
{
    Task<FanChartDto> GetChartByProductIdAsync(int productId);
}
