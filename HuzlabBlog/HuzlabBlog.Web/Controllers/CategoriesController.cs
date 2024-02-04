using HuzlabBlog.Data.UnitOfWorks;
using HuzlabBlog.Entities.DTOs.Categories;
using HuzlabBlog.Entities.Entities;
using HuzlabBlog.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace HuzlabBlog.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IArticleService articleService;
        private readonly ICategoryService categoryService;
        private readonly IUnitOfWork unitOfWork;

        public CategoriesController(IArticleService articleService, ICategoryService categoryService, IUnitOfWork unitOfWork)
        {
            this.articleService = articleService;
            this.categoryService = categoryService;
            this.unitOfWork = unitOfWork;
        }

        [Route("category/{categorySlug}")]
        [HttpGet]
        public async Task<IActionResult> Category(string? categorySlug, int currentPage = 1, int pageSize = 10, bool isAscending = false)
        {
            try
            {
                var articles = await articleService.GetAllByPagingAsync(categorySlug, currentPage, pageSize, isAscending);

                string categoryName = articles.CategoryName;

                ViewBag.CategoryName = categoryName;

                return View(articles);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("NotFound", "Error");
            }
        }
        [HttpGet]
        [Route("categories/")]
        public async Task<IActionResult> Index()
        {
            try
            {


                var model = await categoryService.GetAllCategoriesNonDeleted();
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
