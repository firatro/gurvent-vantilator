namespace GurventVantilator.Application.DTOs
{
    public class ProductModelFilterRequest
    {
        public int? SeriesId { get; set; }
        public string? Name { get; set; }
        public List<int>? UsageTypeIds { get; set; }
        public List<int>? WorkingConditionIds { get; set; }
        public bool? IsActive { get; set; }
    }
}
