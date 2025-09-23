using System.ComponentModel.DataAnnotations;

namespace GurventVantilator.Application.Enums
{
    public enum MenuLinkTypeDto
    {
        [Display(Name = "Özel Sayfa")]
        CustomPage = 0,

        [Display(Name = "Hizmet")]
        Service = 1,

        [Display(Name = "Proje")]
        Project = 2,

        [Display(Name = "Blog")]
        Blog = 3,

        [Display(Name = "İletişim")]
        Contact = 4,

        [Display(Name = "Hakkımızda")]
        AboutUs = 5,

        [Display(Name = "HomePage")]
        HomePage = 6
    }
}
