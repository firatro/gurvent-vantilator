using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Enums;
using GurventVantilator.Domain.Entities;

namespace GurventVantilator.Application.Extensions
{
    public static class MenuMapping
    {
        public static MenuDto MapToDto(this Menu entity)
        {
            return new MenuDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Slug = entity.Slug,
                LinkType = (MenuLinkTypeDto)entity.LinkType,
                ContentHtml = entity.ContentHtml,
                ServiceId = entity.ServiceId,
                ProjectId = entity.ProjectId,
                ParentId = entity.ParentId,
                ParentTitle = entity.Parent?.Title,
                SubMenus = entity.Children?.Select(c => c.MapToDto()).ToList() ?? new List<MenuDto>(),
                Order = entity.Order,
                IsActive = entity.IsActive
            };
        }

        public static Menu MapToEntity(this MenuDto dto)
        {
            return new Menu
            {
                Id = dto.Id,
                Title = dto.Title,
                Slug = dto.Slug,
                LinkType = (MenuLinkType)dto.LinkType,
                ContentHtml = dto.ContentHtml,
                ServiceId = dto.ServiceId,
                ProjectId = dto.ProjectId,
                ParentId = dto.ParentId,
                Order = dto.Order,
                IsActive = dto.IsActive
            };
        }
    }

}
