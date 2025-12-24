namespace GurventVantilator.AdminUI.Models.ProductModel
{
    public class ProductModelFeatureViewModel
    {
        public int Id { get; set; }  // Edit sırasında kullanılacak, Create'de 0 gider.

        public string FeatureName { get; set; } = string.Empty;

        public string? StandardValue { get; set; }

        public string? OptionalValue { get; set; }

        public int Order { get; set; } = 0; // Sıralama istersen Drag&Drop için hazır.
    }
}
