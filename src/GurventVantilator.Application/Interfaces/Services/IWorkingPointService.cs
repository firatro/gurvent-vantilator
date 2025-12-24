using GurventVantilator.Application.DTOs.WorkingPoint;

public interface IWorkingPointService
{
    Task<WorkingPointResultDto?> CalculateAsync(
        int productId,
        WorkingPointRequestDto request);
}
