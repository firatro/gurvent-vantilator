using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cosmedest.WebUI.ViewComponents
{
    public class BreadcrumbViewComponent : ViewComponent
    {
        private readonly IPageImageService _pageImageService;

        public BreadcrumbViewComponent(IPageImageService pageImageService)
        {
            _pageImageService = pageImageService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string title, string pageTitle, string pageKey, string? parentUrl = "/")
        {
            var imageResult = await _pageImageService.GetImageAsync(pageKey, "Breadcrumb");

            var model = new BreadcrumbViewModel
            {
                Title = title,
                PageTitle = pageTitle,
                ParentUrl = parentUrl,
                ImagePath = imageResult.Success ? imageResult.Data?.ImagePath : null
            };

            return View(model);
        }
    }

    public class BreadcrumbViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string PageTitle { get; set; } = string.Empty;
        public string? ImagePath { get; set; }
        public string? ParentUrl { get; set; }
    }
}
