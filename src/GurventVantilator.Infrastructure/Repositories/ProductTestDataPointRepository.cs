using GurventVantilator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class ProductTestDataPointRepository : IProductTestDataPointRepository
{
    private readonly AppDbContext _context;

    public ProductTestDataPointRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<int>> GetProductIdsByAirFlowAsync(
    double airFlow,
    double tolerance,
    int[] qIndexes)
    {
        return await _context.ProductTestPoints
            .Where(p =>
                (qIndexes.Contains(3) && p.Q3.HasValue && Math.Abs(p.Q3.Value - airFlow) <= tolerance) ||
                (qIndexes.Contains(6) && p.Q6.HasValue && Math.Abs(p.Q6.Value - airFlow) <= tolerance) ||
                (qIndexes.Contains(9) && p.Q9.HasValue && Math.Abs(p.Q9.Value - airFlow) <= tolerance) ||

                (qIndexes.Length == 12 &&
                    (
                        (p.Q1.HasValue && Math.Abs(p.Q1.Value - airFlow) <= tolerance) ||
                        (p.Q2.HasValue && Math.Abs(p.Q2.Value - airFlow) <= tolerance) ||
                        (p.Q4.HasValue && Math.Abs(p.Q4.Value - airFlow) <= tolerance) ||
                        (p.Q5.HasValue && Math.Abs(p.Q5.Value - airFlow) <= tolerance) ||
                        (p.Q7.HasValue && Math.Abs(p.Q7.Value - airFlow) <= tolerance) ||
                        (p.Q8.HasValue && Math.Abs(p.Q8.Value - airFlow) <= tolerance) ||
                        (p.Q10.HasValue && Math.Abs(p.Q10.Value - airFlow) <= tolerance) ||
                        (p.Q11.HasValue && Math.Abs(p.Q11.Value - airFlow) <= tolerance) ||
                        (p.Q12.HasValue && Math.Abs(p.Q12.Value - airFlow) <= tolerance)
                    )
                )
            )
            .Select(p => p.ProductTestData.ProductId)
            .Distinct()
            .ToListAsync();
    }


    public async Task<List<int>> GetProductIdsByAirFlowAndPressureAsync(
    double airFlow,
    double totalPressure,
    double toleranceQ,
    double tolerancePt,
    int[] qIndexes)
    {
        return await _context.ProductTestPoints
            .Where(p =>
                (qIndexes.Contains(3) && p.Q3.HasValue && p.Pt3.HasValue &&
                 Math.Abs(p.Q3.Value - airFlow) <= toleranceQ &&
                 Math.Abs(p.Pt3.Value - totalPressure) <= tolerancePt)

                || (qIndexes.Contains(6) && p.Q6.HasValue && p.Pt6.HasValue &&
                    Math.Abs(p.Q6.Value - airFlow) <= toleranceQ &&
                    Math.Abs(p.Pt6.Value - totalPressure) <= tolerancePt)

                || (qIndexes.Contains(9) && p.Q9.HasValue && p.Pt9.HasValue &&
                    Math.Abs(p.Q9.Value - airFlow) <= toleranceQ &&
                    Math.Abs(p.Pt9.Value - totalPressure) <= tolerancePt)

                || (qIndexes.Length == 12 &&
                    (
                        (p.Q1.HasValue && p.Pt1.HasValue &&
                         Math.Abs(p.Q1.Value - airFlow) <= toleranceQ &&
                         Math.Abs(p.Pt1.Value - totalPressure) <= tolerancePt)

                        || (p.Q2.HasValue && p.Pt2.HasValue &&
                            Math.Abs(p.Q2.Value - airFlow) <= toleranceQ &&
                            Math.Abs(p.Pt2.Value - totalPressure) <= tolerancePt)

                        || (p.Q4.HasValue && p.Pt4.HasValue &&
                            Math.Abs(p.Q4.Value - airFlow) <= toleranceQ &&
                            Math.Abs(p.Pt4.Value - totalPressure) <= tolerancePt)

                        || (p.Q5.HasValue && p.Pt5.HasValue &&
                            Math.Abs(p.Q5.Value - airFlow) <= toleranceQ &&
                            Math.Abs(p.Pt5.Value - totalPressure) <= tolerancePt)

                        || (p.Q7.HasValue && p.Pt7.HasValue &&
                            Math.Abs(p.Q7.Value - airFlow) <= toleranceQ &&
                            Math.Abs(p.Pt7.Value - totalPressure) <= tolerancePt)

                        || (p.Q8.HasValue && p.Pt8.HasValue &&
                            Math.Abs(p.Q8.Value - airFlow) <= toleranceQ &&
                            Math.Abs(p.Pt8.Value - totalPressure) <= tolerancePt)

                        || (p.Q10.HasValue && p.Pt10.HasValue &&
                            Math.Abs(p.Q10.Value - airFlow) <= toleranceQ &&
                            Math.Abs(p.Pt10.Value - totalPressure) <= tolerancePt)

                        || (p.Q11.HasValue && p.Pt11.HasValue &&
                            Math.Abs(p.Q11.Value - airFlow) <= toleranceQ &&
                            Math.Abs(p.Pt11.Value - totalPressure) <= tolerancePt)

                        || (p.Q12.HasValue && p.Pt12.HasValue &&
                            Math.Abs(p.Q12.Value - airFlow) <= toleranceQ &&
                            Math.Abs(p.Pt12.Value - totalPressure) <= tolerancePt)
                    )
                )
            )
            .Select(p => p.ProductTestData.ProductId)
            .Distinct()
            .ToListAsync();
    }


    private static bool Match(
    double? q,
    double airflow,
    double tolQ,
    double? pt,
    double? pressure,
    double tolPt)
    {
        if (!q.HasValue) return false;
        if (Math.Abs(q.Value - airflow) > tolQ) return false;

        if (pressure.HasValue)
        {
            if (!pt.HasValue) return false;
            if (Math.Abs(pt.Value - pressure.Value) > tolPt) return false;
        }

        return true;
    }


}
