using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

public interface IProductTestDataService
{
    Task<List<ProductTestCurveDto>> GetCurvesByProductIdsAsync(List<int> productIds);
    Task<List<ProductTestCurveDto>> GetCurvesByProductIds_Q1Pt1_OnlyAsync(List<int> productIds);
    Task<Result<List<PointDto>>> GetCurvePointsByProductIdAsync(int productId);
}
