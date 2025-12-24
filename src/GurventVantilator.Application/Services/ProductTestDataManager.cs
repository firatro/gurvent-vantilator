using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs.TestData;
using GurventVantilator.Domain.Entities;
using Microsoft.AspNetCore.Http;

public class ProductTestDataManager : IProductTestDataService
{
    private readonly IProductTestDataRepository _repository;

    public ProductTestDataManager(IProductTestDataRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<TestDataListItemDto>> GetListAsync()
    {
        var entities = await _repository.GetListWithProductAsync();

        return entities.Select(x => new TestDataListItemDto
        {
            ProductId = x.ProductId,
            ProductName = x.Product.Name,
            TestName = x.TestName,
            Diameter = x.Diameter,
            TestDate = x.TestDate,
            IsActive = x.IsActive
        }).ToList();
    }


    public async Task<Result<ProductTestData>> GetActiveByProductIdAsync(int productId)
    {
        var data = await _repository.GetActiveByProductIdAsync(productId);

        if (data == null)
            return Result<ProductTestData>.Fail("Bu ürüne ait aktif test datası bulunamadı.");

        return Result<ProductTestData>.Ok(data);
    }

    public async Task<Result> CreateAsync(ProductTestData testData)
    {
        // 🔴 Business Rule
        var existing = await _repository.GetActiveByProductIdAsync(testData.ProductId);

        if (existing != null)
            return Result.Fail("Bu ürüne ait zaten aktif bir test datası mevcut.");

        await _repository.AddAsync(testData);
        return Result.Ok();
    }

    public async Task<Result> CreateFromExcelAsync(
    IFormFile file,
    int productId,
    string? testName,
    double? diameter,
    DateTime? testDate)
    {
        if (file == null || file.Length == 0)
            return Result.Fail("Excel dosyası seçilmedi.");

        var existing = await _repository.GetActiveByProductIdAsync(productId);
        if (existing != null)
            return Result.Fail("Bu ürüne ait aktif test datası zaten var.");

        using var stream = file.OpenReadStream();

        var parser = new ProductTestDataExcelParser();
        ProductTestData testData;

        try
        {
            // 🔥 SENİN FORMATIN
            testData = parser.Parse(
                stream,
                productId,
                testName,
                diameter,
                testDate,
                file.FileName
            );
        }
        catch (Exception ex)
        {
            return Result.Fail(ex.Message);
        }

        await _repository.AddAsync(testData);
        return Result.Ok();
    }

}
