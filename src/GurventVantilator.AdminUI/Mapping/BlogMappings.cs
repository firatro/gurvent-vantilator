using GurventVantilator.Application.DTOs;
using GurventVantilator.AdminUI.Models.Blog;

namespace GurventVantilator.AdminUI.Mappings
{
    public static class BlogMappings
    {
        public static BlogDto ToDto(this BlogCreateViewModel vm,
                                    string? mainImagePath,
                                    string? contentImage1Path,
                                    string? contentImage2Path)
        {
            return new BlogDto
            {
                FullName = vm.FullName,
                Title = vm.Title,
                Subtitle = vm.Subtitle ?? string.Empty,
                Description = vm.Description,
                EntryTitle = vm.EntryTitle ?? string.Empty,
                EntryDescription = vm.EntryDescription ?? string.Empty,
                ExtraTitle = vm.ExtraTitle,
                ExtraDescription = vm.ExtraDescription,
                Quote = vm.Quote,
                QuoteSource = vm.QuoteSource,
                YoutubeVideoUrl = vm.YoutubeVideoUrl,
                CategoryId = vm.CategoryId,

                MainImagePath = mainImagePath ?? string.Empty,
                ContentImage1Path = contentImage1Path ?? string.Empty,
                ContentImage2Path = contentImage2Path ?? string.Empty,

                CreatedAt = DateTime.Now
            };
        }

        public static BlogEditViewModel ToEditViewModel(this BlogDto dto)
        {
            return new BlogEditViewModel
            {
                Id = dto.Id,
                FullName = dto.FullName,
                Title = dto.Title,
                Subtitle = dto.Subtitle,
                Description = dto.Description,
                EntryTitle = dto.EntryTitle,
                EntryDescription = dto.EntryDescription,
                ExtraTitle = dto.ExtraTitle,
                ExtraDescription = dto.ExtraDescription,
                Quote = dto.Quote,
                QuoteSource = dto.QuoteSource,
                YoutubeVideoUrl = dto.YoutubeVideoUrl,
                CategoryId = dto.CategoryId,

                MainImagePath = dto.MainImagePath,
                ContentImage1Path = dto.ContentImage1Path,
                ContentImage2Path = dto.ContentImage2Path,
                TagIds = dto.Tags?.Select(t => t.Id).ToList() ?? new List<int>()
            };
        }

        public static BlogDto ToDto(this BlogEditViewModel vm,
                                    string mainImagePath,
                                    string contentImage1Path,
                                    string contentImage2Path,
                                    DateTime createdAt)
        {
            return new BlogDto
            {
                Id = vm.Id,
                FullName = vm.FullName,
                Title = vm.Title,
                Subtitle = vm.Subtitle ?? string.Empty,
                Description = vm.Description,
                EntryTitle = vm.EntryTitle ?? string.Empty,
                EntryDescription = vm.EntryDescription ?? string.Empty,
                ExtraTitle = vm.ExtraTitle,
                ExtraDescription = vm.ExtraDescription,
                Quote = vm.Quote,
                QuoteSource = vm.QuoteSource,
                YoutubeVideoUrl = vm.YoutubeVideoUrl,
                CategoryId = vm.CategoryId,

                MainImagePath = mainImagePath,
                ContentImage1Path = contentImage1Path,
                ContentImage2Path = contentImage2Path,
                CreatedAt = createdAt
            };
        }
    }
}
