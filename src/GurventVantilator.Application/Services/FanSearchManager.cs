using System.Globalization;
using GurventVantilator.Application.Interfaces.Repositories;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Domain.Interfaces.Repositories;

public class FanSearchManager : IFanSearchService
{
    private readonly IProductTestDataPointRepository _testPointRepository;
    private readonly IProductRepository _productRepository;

    public FanSearchManager(
        IProductTestDataPointRepository testPointRepository,
        IProductRepository productRepository)
    {
        _testPointRepository = testPointRepository;
        _productRepository = productRepository;
    }

    public async Task<List<FanSearchResultDto>> SearchByAirFlowAsync(
    double airFlow,
    double? totalPressure,
    int tolerancePercent,
    SpeedControlType speedControl,
    int? usageId,
    int? workingId)
    {
        // 1️⃣ Tolerans hesabı (% → mutlak)
        double toleranceQ = airFlow * tolerancePercent / 100.0;

        double? tolerancePt = null;
        if (totalPressure.HasValue)
            tolerancePt = totalPressure.Value * tolerancePercent / 100.0;

        // 2️⃣ SpeedControl → Q indexleri
        int[] qIndexes = speedControl switch
        {
            SpeedControlType.DirectCoupled => new[] { 3, 6, 9 },
            _ => Enumerable.Range(1, 12).ToArray()
        };

        // 3️⃣ AirFlow / AirFlow+TotalPressure’a göre ProductId’leri bul
        List<int> productIds;

        if (!totalPressure.HasValue)
        {
            productIds = await _testPointRepository
                .GetProductIdsByAirFlowAsync(
                    airFlow,
                    toleranceQ,
                    qIndexes
                );
        }
        else
        {
            productIds = await _testPointRepository
                .GetProductIdsByAirFlowAndPressureAsync(
                    airFlow,
                    totalPressure.Value,
                    toleranceQ,
                    tolerancePt!.Value,
                    qIndexes
                );
        }

        if (!productIds.Any())
            return new List<FanSearchResultDto>();

        // 4️⃣ Ürünleri Model + Usage + Working filtreleriyle getir
        var products = await _productRepository
            .GetByIdsWithModelFiltersAsync(
                productIds,
                usageId,
                workingId
            );

        // 5️⃣ DTO (SADECE Product tablosu alanları)
        return products.Select(p => new FanSearchResultDto
        {
            ProductId = p.Id,
            ProductName = p.Name,

            AirFlow = p.AirFlow,
            TotalPressure = p.TotalPressure,

            // ⚠️ Product entity’de hangi alanlar varsa ona göre doldur
            RPM = p.Speed,          // eğer alan adı farklıysa düzelt
            Power = double.TryParse(
                p.Power?.Replace(",", "."),
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out var power)
                ? power
                : null,        // yoksa null kalır
            Sound = p.SoundLevel    // yoksa null kalır
        }).ToList();
    }



}
