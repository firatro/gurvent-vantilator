

using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Domain.Interfaces.Repositories;

namespace GurventVantilator.Application.Services
{

    public class ProductTestDataManager : IProductTestDataService
    {
        private readonly IProductTestDataRepository _repository;

        public ProductTestDataManager(IProductTestDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductTestCurveDto>> GetCurvesByProductIdsAsync(List<int> productIds)
        {
            var list = await _repository.GetByProductIdsAsync(productIds);
            var result = new List<ProductTestCurveDto>();

            foreach (var group in list.GroupBy(x => x.Product))
            {
                var dto = new ProductTestCurveDto
                {
                    ProductId = group.Key.Id,
                    ProductName = group.Key.Name,
                    Points = new List<PointDto>()
                };

                foreach (var row in group)
                {
                    for (int i = 1; i <= 12; i++)
                    {
                        var qVal = row.GetType().GetProperty($"Q{i}")?.GetValue(row);
                        var ptVal = row.GetType().GetProperty($"Pt{i}")?.GetValue(row);

                        double q = qVal == null ? 0 : Convert.ToDouble(qVal);
                        double pt = ptVal == null ? 0 : Convert.ToDouble(ptVal);

                        if (q > 0 && pt > 0)
                            dto.Points.Add(new PointDto { Q = q, Pt = pt });
                    }
                }

                result.Add(dto);
            }

            return result;
        }

        public async Task<List<ProductTestCurveDto>> GetCurvesByProductIds_Q1Pt1_OnlyAsync(List<int> productIds)
        {
            var rows = await _repository.GetQ1Pt1ByProductIdsAsync(productIds);

            // Product bazında grupla
            var list = rows
                .GroupBy(r => new { r.ProductId, r.ProductName })
                .Select(g => new ProductTestCurveDto
                {
                    ProductId = g.Key.ProductId,
                    ProductName = g.Key.ProductName,
                    Points = g
                        .Select(r => new PointDto
                        {
                            Q = r.Q1.HasValue ? Convert.ToDouble(r.Q1.Value) : 0d,
                            Pt = r.Pt1.HasValue ? Convert.ToDouble(r.Pt1.Value) : 0d
                        })
                        .Where(p => p.Q > 0 && p.Pt > 0)
                        .ToList()
                })
                .ToList();

            return list;
        }

        public async Task<Result<List<PointDto>>> GetCurvePointsByProductIdAsync(int productId)
        {
            // Veritabanından o ürüne ait tüm satırları çek
            var rows = await _repository.GetAllByProductIdAsync(productId);

            if (rows == null || !rows.Any())
                return Result<List<PointDto>>.Fail("Test verisi bulunamadı.");

            // 🔹 Her satırın Pt1 ve Q1 değerlerinden nokta oluştur
            var points = rows
                .Where(r => r.Pt1 > 0 && r.Q1 > 0)
                .OrderBy(r => r.Pt1) // X ekseni sıralaması
                .Select(r => new PointDto
                {
                    Q = (double)r.Pt1, // X ekseni (Basınç)
                    Pt = (double)r.Q1  // Y ekseni (Debi)
                })
                .ToList();

            return Result<List<PointDto>>.Ok(points);
        }


    }

}