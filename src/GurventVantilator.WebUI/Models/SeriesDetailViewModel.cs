using GurventVantilator.Application.DTOs;

public class SeriesDetailViewModel
{
    public ProductSeriesDto Series { get; set; }
    public List<ProductModelDto> Models { get; set; } = new();
}
