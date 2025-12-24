
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.AdminUI.Models.TestData
{
    public class TestDataIndexViewModel
    {
        public List<TestDataListItemViewModel> TestDatas { get; set; } = new();

        public List<ProductDto> Products { get; set; } = new();
    }
}
