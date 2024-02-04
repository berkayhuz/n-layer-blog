using HuzlabBlog.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;


namespace HuzlabBlog.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly IArticleService articleService;

        public SearchController(IArticleService articleService)
        {
            this.articleService = articleService;
        }
        [Route("search/")]
        [HttpGet]
        public async Task<IActionResult> Index(string query, int currentPage = 1, int pageSize = 8, bool isAscending = false)
        {
            try
            {
                ViewBag.Query = query;
                var articles = await articleService.SearchAsync(query, currentPage, pageSize, isAscending);
                return View(articles);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("NotFound", "Error");
            }
        }
    }
}
