using HuzlabBlog.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace HuzlabBlog.Web.ViewComponents
{
    public class UnderCategoryLastPostsViewComponent : ViewComponent
    {
        private readonly IArticleService _articleService;

        public UnderCategoryLastPostsViewComponent(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var sliderArticles = await _articleService.GetSliderArticles(4);

                return View(sliderArticles);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("NotFound", "Error");
            }
        }
    }
}