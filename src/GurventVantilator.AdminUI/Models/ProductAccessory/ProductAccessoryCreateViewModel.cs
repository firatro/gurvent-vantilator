using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace GurventVantilator.AdminUI.Models.ProductAccessory
{
    public class ProductAccessoryCreateViewModel
    {
        [Required]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Accessory name zorunludur.")]
        [StringLength(150)]
        public string AccessoryName { get; set; } = string.Empty;
        public string ArticleNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Type zorunludur.")]
        [StringLength(100)]
        public string Type { get; set; } = string.Empty;

        public IFormFile? ImageFile { get; set; }
    }
}
