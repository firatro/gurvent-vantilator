public class ProductContentFeatureDto
{
    public int Id { get; set; }

    public int? ProductId { get; set; }
    public int? ProductModelId { get; set; }

    public string Key { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public int? Order { get; set; }
}
