using ClosedXML.Excel;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using System.Globalization;

namespace GurventVantilator.Infrastructure.Services
{
    public class ProductTestDataImportService : IProductTestDataImportService
    {
        private readonly IProductTestDataRepository _repo;

        public ProductTestDataImportService(IProductTestDataRepository repo)
        {
            _repo = repo;
        }

        public async Task ImportAsync(int productId, string excelFilePath, CancellationToken ct = default)
        {
            // 🔹 Relative path'i fiziksel tam yola dönüştür
            var absolutePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", excelFilePath.TrimStart('/', '\\'));

            if (!File.Exists(absolutePath))
                throw new FileNotFoundException("Excel file not found.", absolutePath);

            var list = new List<ProductTestData>();

            using var wb = new XLWorkbook(absolutePath);
            var ws = wb.Worksheet(1);
            var range = ws.RangeUsed();
            if (range is null)
                return;

            // 🔹 1. satır başlık satırı, veriler 2. satırdan itibaren
            foreach (var row in range.RowsUsed().Skip(1))
            {
                var r = new ProductTestData
                {
                    ProductId = productId,
                    Pt1 = ParseDecimal(row.Cell(1)),
                    Pt2 = ParseDecimal(row.Cell(2)),
                    Pt3 = ParseDecimal(row.Cell(3)),
                    Pt4 = ParseDecimal(row.Cell(4)),
                    Pt5 = ParseDecimal(row.Cell(5)),
                    Pt6 = ParseDecimal(row.Cell(6)),
                    Pt7 = ParseDecimal(row.Cell(7)),
                    Pt8 = ParseDecimal(row.Cell(8)),
                    Pt9 = ParseDecimal(row.Cell(9)),
                    Pt10 = ParseDecimal(row.Cell(10)),
                    Pt11 = ParseDecimal(row.Cell(11)),
                    Pt12 = ParseDecimal(row.Cell(12)),
                    Q1 = ParseDecimal(row.Cell(13)),
                    Q2 = ParseDecimal(row.Cell(14)),
                    Q3 = ParseDecimal(row.Cell(15)),
                    Q4 = ParseDecimal(row.Cell(16)),
                    Q5 = ParseDecimal(row.Cell(17)),
                    Q6 = ParseDecimal(row.Cell(18)),
                    Q7 = ParseDecimal(row.Cell(19)),
                    Q8 = ParseDecimal(row.Cell(20)),
                    Q9 = ParseDecimal(row.Cell(21)),
                    Q10 = ParseDecimal(row.Cell(22)),
                    Q11 = ParseDecimal(row.Cell(23)),
                    Q12 = ParseDecimal(row.Cell(24))
                };

                list.Add(r);
            }

            // 🔹 Eski test verilerini temizle ve yenilerini ekle
            await _repo.DeleteByProductIdAsync(productId, ct);
            await _repo.AddRangeAsync(list, ct);
        }

        // 🔹 Hücre değerini güvenli şekilde decimal'e çevir
        private static decimal ParseDecimal(IXLCell cell)
        {
            var str = cell.GetString()?.Trim();

            if (string.IsNullOrWhiteSpace(str))
                return 0;

            // Hem Türkçe (virgül) hem İngilizce (nokta) ondalık ayırıcıyı destekle
            str = str.Replace(",", ".");

            return decimal.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out var val)
                ? val
                : 0;
        }
    }
}
