namespace GurventVantilator.AdminUI.Models.ProductContentFeature
{
    public class ProductContentFeatureViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }  
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public int? Order { get; set; }
    }
}
