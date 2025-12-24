public class TestDataListItemViewModel
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public string? TestName { get; set; }
    public double? Diameter { get; set; }
    public DateTime? TestDate { get; set; }

    public bool IsActive { get; set; }
}
