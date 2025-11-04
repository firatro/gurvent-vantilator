namespace GurventVantilator.Application.Interfaces.Services;

public interface IProductTestDataImportService
{
    /// <summary>Verilen ürün için Excel’den test datasını içeri alır.</summary>
    Task ImportAsync(int productId, string excelFilePath, CancellationToken ct = default);
}
