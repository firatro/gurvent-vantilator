using GurventVantilator.Application.DTOs;

namespace GurventVantilator.WebUI.Models
{
    public class ContactPageViewModel
    {
        public ContactDto Contact { get; set; } = new ContactDto();
        public SiteInfoDto? SiteInfo { get; set; }
    }
}
