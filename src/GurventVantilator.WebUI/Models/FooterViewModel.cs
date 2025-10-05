using GurventVantilator.Application.DTOs;

namespace GurventVantilator.WebUI.Models
{
    public class FooterViewModel
    {
        public SiteInfoDto SiteInfo { get; set; } = new SiteInfoDto();
        public SocialMediaInfoDto SocialMediaInfo { get; set; } = new SocialMediaInfoDto();
        public IEnumerable<MenuDto> Menus { get; set; } = new List<MenuDto>();
        public IEnumerable<ServiceDto> Services { get; set; } = new List<ServiceDto>();
    }
}
