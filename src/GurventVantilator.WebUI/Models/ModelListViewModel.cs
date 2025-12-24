using GurventVantilator.Application.DTOs;

public class ModelListViewModel
{
    public List<ProductModelDto> Models { get; set; } = new();
    public int? SelectedUsageId { get; set; }
    public int? SelectedWorkingId { get; set; }
    public int? SelectedSeriesId { get; set; }
    public string? SelectedSeriesName { get; set; }

}
