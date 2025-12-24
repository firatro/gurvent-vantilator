using GurventVantilator.Domain.Entities;

public class ProductTestData
{
    public int Id { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }
    public string? SourceFileName { get; set; }
    public string TestName { get; set; }
    public double? Diameter { get; set; }
    public DateTime? TestDate { get; set; }

    // === SANAL / META DEĞERLER ===
    public double? Ps { get; set; }
    public double? Pd { get; set; }
    public double? Current { get; set; }
    public double? Pt { get; set; }
    public double? Speed { get; set; }
    public double? Q { get; set; }
    public double? AirPower { get; set; }
    public double? CalculatedPower { get; set; }
    public double? TotalEfficiency { get; set; }
    public double? MechanicalEfficiency { get; set; }

    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<ProductTestDataPoint> Points { get; set; }
}
