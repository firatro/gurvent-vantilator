using GurventVantilator.Application.DTOs;

public class SeriesListViewModel
{
    public List<ProductSeriesDto> Series { get; set; } = new();
    public int? SelectedUsageId { get; set; }
    public int? SelectedWorkingId { get; set; }
}
