using GurventVantilator.Application.DTOs;

public static class ProductContentFeatureViewModelExtensions
{
    public static ProductContentFeatureDto ToDto(this ProductContentFeatureViewModel vm)
    {
        return new ProductContentFeatureDto
        {
            Id = vm.Id,
            Key = vm.Key,
            Value = vm.Value,
            Order = vm.Order,
            ProductId = 0 // Model tarafında set edilecek
        };
    }
}
