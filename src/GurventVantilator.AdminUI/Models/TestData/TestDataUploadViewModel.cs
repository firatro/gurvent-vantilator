public class TestDataUploadViewModel
{
    public int ProductId { get; set; }

    public string? TestName { get; set; }
    public double? Diameter { get; set; }
    public DateTime? TestDate { get; set; }

    public IFormFile? ExcelFile { get; set; }
}
