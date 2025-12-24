using GurventVantilator.Application.DTOs.WorkingPoint;
using GurventVantilator.Domain.Interfaces.Repositories;

public class WorkingPointManager : IWorkingPointService
{
    private readonly IProductTestDataRepository _testDataRepository;

    public WorkingPointManager(IProductTestDataRepository testDataRepository)
    {
        _testDataRepository = testDataRepository;
    }

    public async Task<WorkingPointResultDto?> CalculateAsync(
        int productId,
        WorkingPointRequestDto request)
    {
        var testData = await _testDataRepository.GetActiveByProductIdAsync(productId);

        if (testData == null || testData.Points == null || !testData.Points.Any())
            return null;

        // =====================================================
        // 🔹 TÜM Q1–PT12 NOKTALARINI TEK LİSTEDE TOPLA
        // =====================================================
        var curvePoints = new List<CurvePoint>();

        foreach (var row in testData.Points)
        {
            for (int i = 1; i <= 12; i++)
            {
                var qProp = typeof(ProductTestDataPoint).GetProperty($"Q{i}");
                var ptProp = typeof(ProductTestDataPoint).GetProperty($"Pt{i}");

                if (qProp == null || ptProp == null)
                    continue;

                var q = qProp.GetValue(row) as double?;
                var pt = ptProp.GetValue(row) as double?;

                if (!q.HasValue || !pt.HasValue)
                    continue;

                curvePoints.Add(new CurvePoint
                {
                    Q = q.Value,
                    Pt = pt.Value,
                    RPM = row.RPM,
                    Power = row.Power ?? 0d
                });
            }
        }

        if (!curvePoints.Any())
            return null;

        // Q’ya göre sırala
        curvePoints = curvePoints
            .OrderBy(x => x.Q)
            .ToList();

        // =====================================================
        // 1️⃣ EN YAKIN NOKTA (ÖKLİD)
        // =====================================================
        var nearest = curvePoints
            .Select(p => new
            {
                Point = p,
                Distance = Math.Sqrt(
                    Math.Pow(p.Q - request.Q, 2) +
                    Math.Pow(p.Pt - request.Pt, 2))
            })
            .OrderBy(x => x.Distance)
            .First();

        // =====================================================
        // 2️⃣ INTERPOLASYON KOMŞULARI (Q BAZLI)
        // =====================================================
        var lower = curvePoints.LastOrDefault(p => p.Q <= request.Q);
        var upper = curvePoints.FirstOrDefault(p => p.Q >= request.Q);

        // ❗ Interpolasyon mümkün değil → nearest
        if (lower == null || upper == null || lower.Q == upper.Q)
        {
            return new WorkingPointResultDto
            {
                InputQ = request.Q,
                InputPt = request.Pt,

                CalculatedRPM = nearest.Point.RPM,
                CalculatedPower = nearest.Point.Power,

                NearestQ = nearest.Point.Q,
                NearestPt = nearest.Point.Pt,

                Distance = nearest.Distance
            };
        }

        // =====================================================
        // 3️⃣ LINEER INTERPOLASYON (Q)
        // =====================================================
        double ratio = (request.Q - lower.Q) / (upper.Q - lower.Q);

        double interpolatedRPM =
            lower.RPM + ratio * (upper.RPM - lower.RPM);

        double interpolatedPower =
            lower.Power + ratio * (upper.Power - lower.Power);

        return new WorkingPointResultDto
        {
            InputQ = request.Q,
            InputPt = request.Pt,

            CalculatedRPM = interpolatedRPM,
            CalculatedPower = interpolatedPower,

            NearestQ = nearest.Point.Q,
            NearestPt = nearest.Point.Pt,

            Distance = nearest.Distance
        };
    }

    // =====================================================
    // 🔹 INTERNAL HELPER MODEL
    // =====================================================
    private class CurvePoint
    {
        public double Q { get; set; }
        public double Pt { get; set; }
        public double RPM { get; set; }
        public double Power { get; set; }
    }
}
