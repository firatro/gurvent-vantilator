using GurventVantilator.Application.DTOs.Charts;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;

public class FanChartManager : IFanChartService
{
    private readonly IProductTestDataRepository _testDataRepository;

    public FanChartManager(IProductTestDataRepository testDataRepository)
    {
        _testDataRepository = testDataRepository;
    }

    public async Task<FanChartDto> GetChartByProductIdAsync(int productId, string? speedControl, string? voltage)
    {
        var testData = await _testDataRepository.GetActiveByProductIdAsync(productId);

        if (testData == null || testData.Points == null || !testData.Points.Any())
            return new FanChartDto();

        int? targetHz = null;

        // 1️⃣ Voltage öncelikli
        if (!string.IsNullOrEmpty(voltage))
        {
            if (voltage.EndsWith("50Hz", StringComparison.OrdinalIgnoreCase))
                targetHz = 50;
            else if (voltage.EndsWith("60Hz", StringComparison.OrdinalIgnoreCase))
                targetHz = 60;
        }

        // 2️⃣ Voltage yoksa → DirectCoupled
        if (targetHz == null &&
            string.Equals(speedControl, "DirectCoupled", StringComparison.OrdinalIgnoreCase))
        {
            targetHz = 50;
        }


        var datasets = new List<FanChartDatasetDto>();

        for (int i = 2; i <= 12; i++)
        {
            string label = CurveLabels.ContainsKey(i)
                                        ? CurveLabels[i]
                                        : $"Q{i}";

            // 🔥 Hz FİLTRESİ
            if (targetHz != null && !label.EndsWith($"/{targetHz}"))
                continue;


            var data = new List<FanChartPointDto>();

            foreach (var p in testData.Points)
            {
                var q = typeof(ProductTestDataPoint)
                            .GetProperty($"Q{i}")?.GetValue(p) as double?;

                var pt = typeof(ProductTestDataPoint)
                            .GetProperty($"Pt{i}")?.GetValue(p) as double?;

                var db = typeof(ProductTestDataPoint)
                     .GetProperty($"Db{i}")?.GetValue(p) as double?;

                if (!q.HasValue || !pt.HasValue)
                    continue;

                data.Add(new FanChartPointDto
                {
                    X = q.Value,
                    Y = pt.Value,

                    Db = db,
                    RPM = p.RPM,
                    Power = p.Power ?? 0d,

                    Ps = p.Ps,
                    Pd = p.Pd,
                    Current = p.Current,
                    Speed = p.Speed,
                    AirPower = p.AirPower,
                    TotalEfficiency = p.TotalEfficiency,
                    MechanicalEfficiency = p.MechanicalEfficiency
                });
            }

            if (!data.Any())
                continue;



            datasets.Add(new FanChartDatasetDto
            {
                Label = CurveLabels.ContainsKey(i)
                ? CurveLabels[i]
                : $"Q{i}",
                Data = data.OrderBy(x => x.X).ToList(),
                HideLegend = i == 1
            });
        }

        return new FanChartDto
        {
            Title = "Fan Performans Eğrileri",
            XAxisLabel = "Debi (Q)",
            YAxisLabel = "Toplam Basınç (Pt)",
            Datasets = datasets
        };
    }

    private static readonly Dictionary<int, string> CurveLabels = new()
{
    { 1, "" },
    { 2, "/6/50" },
    { 3, "/6/60" },
    { 4, "/4/50" },
    { 5, "/4/60" },
    { 6, "/4/70" },
    { 7, "/4/74" },
    { 8, "/2/40" },
    { 9, "/2/50" },
    { 10, "/2/55" },
    { 11, "/2/60" },
    { 12, "/2/65" }
};

}
