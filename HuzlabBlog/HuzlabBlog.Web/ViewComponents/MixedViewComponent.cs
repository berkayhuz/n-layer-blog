using HuzlabBlog.Entities.DTOs.Articles;
using HuzlabBlog.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace HuzlabBlog.Web.ViewComponents
{
    public class MixedViewComponent : ViewComponent
    {
        private readonly IArticleService articleService;

        public MixedViewComponent(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var latestSharedArticles = await articleService.GetLatestArticles(4);

                var model = new List<ArticleDto>(latestSharedArticles);

                return View(model);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("NotFound", "Error");
            }
        }
    }
}