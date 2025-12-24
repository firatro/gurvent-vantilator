using GurventVantilator.Application.DTOs;

public class ProductContentFeatureViewModel
{
    public int Id { get; set; }

    public int? ProductId { get; set; }          // ✔ Index methodunda kullanılıyor
    public string ProductName { get; set; } = "";  // ✔ Ürün adını göstermek için
    public int ProductModelId { get; set; }
    public string ProductModelName { get; set; } = "";
    public string Key { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;

    public int? Order { get; set; }
}
