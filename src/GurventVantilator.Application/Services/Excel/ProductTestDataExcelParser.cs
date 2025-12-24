using ClosedXML.Excel;
using GurventVantilator.Domain.Entities;
using System.Globalization;
using System.Reflection;

public class ProductTestDataExcelParser
{
    // ================================
    // 🔹 Q HEADER MAP (YENİ FORMAT)
    // ================================
    private static readonly Dictionary<int, string> Q_HEADER_MAP = new()
    {
        { 1, "Q1" },
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

    // ================================
    // 🔹 HEADER ADIYLA DOUBLE OKU
    // ================================
    private double? GetDoubleByHeader(
        IXLWorksheet ws,
        int headerRow,
        int dataRow,
        string headerName)
    {
        var headerCell = ws.Row(headerRow)
            .CellsUsed()
            .FirstOrDefault(c =>
                c.GetString().Trim()
                 .Equals(headerName.Trim(), StringComparison.OrdinalIgnoreCase));

        if (headerCell == null)
            return null;

        var cell = ws.Cell(dataRow, headerCell.Address.ColumnNumber);

        if (cell.IsEmpty())
            return null;

        var raw = cell.GetString()
                      .Replace("%", "")
                      .Replace(",", ".")
                      .Trim();

        if (double.TryParse(
            raw,
            NumberStyles.Any,
            CultureInfo.InvariantCulture,
            out var result))
        {
            return result;
        }

        return null;
    }

    // ================================
    // 🔹 ANA PARSE METODU
    // ================================
    public ProductTestData Parse(
        Stream excelStream,
        int productId,
        string testName,
        double? diameter,
        DateTime? testDate,
        string sourceFileName)
    {
        using var workbook = new XLWorkbook(excelStream);
        var ws = workbook.Worksheet(1);

        int headerRow = 1;
        int lastRow = ws.LastRowUsed().RowNumber();

        var testData = new ProductTestData
        {
            ProductId = productId,
            TestName = testName,
            Diameter = diameter,
            TestDate = testDate,
            SourceFileName = sourceFileName,
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            Points = new List<ProductTestDataPoint>()
        };

        // ================================
        // 🔹 SATIR SATIR OKU
        // ================================
        for (int row = headerRow + 1; row <= lastRow; row++)
        {
            var point = new ProductTestDataPoint
            {
                RowNumber = row,

                RPM = GetDoubleByHeader(ws, headerRow, row, "RPM1") ?? 0d,
                Power = GetDoubleByHeader(ws, headerRow, row, "P1"),

                Ps = GetDoubleByHeader(ws, headerRow, row, "Ps-(Pa)_sanal"),
                Pd = GetDoubleByHeader(ws, headerRow, row, "Pd-(Pa)_sanal"),
                Current = GetDoubleByHeader(ws, headerRow, row, "Current(Amper)_sanal"),
                Speed = GetDoubleByHeader(ws, headerRow, row, "Hız(sanal)"),
                AirPower = GetDoubleByHeader(ws, headerRow, row, "Power(hesaplanan)"),
                TotalEfficiency = GetDoubleByHeader(ws, headerRow, row, "Toplam verim"),
                MechanicalEfficiency = GetDoubleByHeader(ws, headerRow, row, "Mekanik Verim")
            };

            bool hasAnyCurvePoint = false;

            // ================================
            // 🔹 Q / Pt / db (1–12)
            // ================================
            for (int i = 1; i <= 12; i++)
            {
                var qHeader = Q_HEADER_MAP[i];

                var q = GetDoubleByHeader(ws, headerRow, row, qHeader);
                var pt = GetDoubleByHeader(ws, headerRow, row, $"Pt{i}");
                var db = GetDoubleByHeader(ws, headerRow, row, $"db{i}");

                if (q.HasValue && pt.HasValue)
                    hasAnyCurvePoint = true;

                typeof(ProductTestDataPoint)
                    .GetProperty($"Q{i}")?.SetValue(point, q);

                typeof(ProductTestDataPoint)
                    .GetProperty($"Pt{i}")?.SetValue(point, pt);

                typeof(ProductTestDataPoint)
                    .GetProperty($"Db{i}")?.SetValue(point, db);
            }

            if (hasAnyCurvePoint)
                testData.Points.Add(point);
        }

        if (!testData.Points.Any())
            throw new Exception("Excel dosyasında geçerli Q–Pt test noktası bulunamadı.");

        return testData;
    }
}
