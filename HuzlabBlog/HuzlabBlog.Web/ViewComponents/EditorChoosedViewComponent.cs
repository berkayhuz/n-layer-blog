using HuzlabBlog.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace HuzlabBlog.Web.ViewComponents
{
    public class EditorChoosedViewComponent : ViewComponent
    {
        private readonly IArticleService _articleService;

        public EditorChoosedViewComponent(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var editorArticles = await _articleService.GetEditorChoosedArticles(3);

                return View(editorArticles);

            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("NotFound", "Error");
            }
        }
    }
}