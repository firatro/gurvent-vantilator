using GurventVantilator.Application.DTOs;

public class ProductPageViewModel
{
    public List<ProductUsageTypeDto> UsageTypes { get; set; }
    public List<ProductWorkingConditionDto> WorkingConditions { get; set; }
    public List<ProductSeriesDto> Series { get; set; }

    public int? SelectedUsageId { get; set; }
    public int? SelectedWorkingId { get; set; }
    public string? ErrorMessage { get; set; }
    public int? SelectedSeriesId { get; set; }
    public int? SelectedModelId { get; set; }
    public List<ProductModelDto> Models { get; set; } = new();
    public List<ProductDto> Products { get; set; } = new();
    public string SelectedSeriesName { get; set; }
    public string SelectedModelName { get; set; }
    public string ViewMode { get; set; } = "category";

    public bool HasUsageOrWorking => SelectedUsageId.HasValue || SelectedWorkingId.HasValue;
    public bool HasSeries => SelectedSeriesId.HasValue;
    public bool HasModel => SelectedModelId.HasValue;


}
