using HuzlabBlog.Data.UnitOfWorks;
using HuzlabBlog.Entities.Entities;
using HuzlabBlog.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace HuzlabBlog.Web.Controllers
{
    public class PostController : Controller
	{
        private readonly IArticleService articleService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IUnitOfWork unitOfWork;

        public PostController(IArticleService articleService, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            this.articleService = articleService;
            this.httpContextAccessor = httpContextAccessor;
            this.unitOfWork = unitOfWork;
        }
        [Route("post/{slug}")]
        public async Task<IActionResult> Detail(string slug)
        {
            try
            {
                if (string.IsNullOrEmpty(slug))
                {
                    return RedirectToAction("Index", new { controller = "Home" });
                }

                var ipAddress = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
                var articeVisitors = await unitOfWork.GetRepository<ArticleVisitor>().GetAllAsync(null, x => x.Visitor, y => y.Article);
                var article = await unitOfWork.GetRepository<Article>().GetAsync(x => x.Slug == slug);

                if (article == null)
                {
                    return RedirectToAction("Index", new { controller = "Home" });
                }

                var result = await articleService.GetArticleBySlugWithCategoryNonDeletedAsync(article.Slug);

                var visitor = await unitOfWork.GetRepository<Visitor>().GetAsync(x => x.IpAddress == ipAddress);

                var addArticleVisitors = new ArticleVisitor(article.Id, visitor.Id);

                if (articeVisitors.Any(x => x.VisitorId == addArticleVisitors.VisitorId && x.ArticleId == addArticleVisitors.ArticleId))
                    return View(result);
                else
                {
                    await unitOfWork.GetRepository<ArticleVisitor>().AddAsync(addArticleVisitors);
                    article.ViewCount += 1;
                    await unitOfWork.GetRepository<Article>().UpdateAsync(article);
                    await unitOfWork.SaveAsync();
                }

                return View(result);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("NotFound", "Error");
            }
        }
        [Route("posts/")]
        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 9)
        {
            try
            {
                var model = await articleService.GetPaginatedArticlesAsync(page, pageSize);
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
