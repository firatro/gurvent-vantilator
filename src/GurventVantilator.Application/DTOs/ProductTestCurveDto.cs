public class ProductTestCurveDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = "";
    public List<PointDto> Points { get; set; } = new();
}

public class PointDto
{
    public double Q { get; set; }   // x-axis (Hava akışı)
    public double Pt { get; set; }  // y-axis (Basınç)
}
