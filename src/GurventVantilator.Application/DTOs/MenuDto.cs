using GurventVantilator.Application.Enums;

namespace GurventVantilator.Application.DTOs
{
    public class MenuDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public MenuLinkTypeDto LinkType { get; set; } 
        public string? ContentHtml { get; set; }
        public int? ServiceId { get; set; }
        public int? ProjectId { get; set; }
        public int? BlogId { get; set; }
        public int? ParentId { get; set; }
        public string? ParentTitle { get; set; }
        public List<MenuDto> SubMenus { get; set; } = new();
        public int Order { get; set; }
        public bool IsActive { get; set; }
    }
}
