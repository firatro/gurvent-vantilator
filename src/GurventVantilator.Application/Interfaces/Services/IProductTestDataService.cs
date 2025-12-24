using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs.TestData;
using GurventVantilator.Domain.Entities;
using Microsoft.AspNetCore.Http;

public interface IProductTestDataService
{
    Task<List<TestDataListItemDto>> GetListAsync();

    Task<Result<ProductTestData>> GetActiveByProductIdAsync(int productId);

    Task<Result> CreateAsync(ProductTestData testData);

    Task<Result> CreateFromExcelAsync(
        IFormFile file,
        int productId,
        string? testName,
        double? diameter,
        DateTime? testDate);
}
