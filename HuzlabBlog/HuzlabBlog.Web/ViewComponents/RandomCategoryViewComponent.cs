using HuzlabBlog.Service.Services.Abstractions;
using HuzlabBlog.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace HuzlabBlog.Web.ViewComponents
{
    public class RandomCategoryViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly IArticleService _articleService;

        public RandomCategoryViewComponent(ICategoryService categoryService, IArticleService articleService)
        {
            _categoryService = categoryService;
            _articleService = articleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var randomCategory = await _categoryService.GetRandomCategory();

                if (randomCategory != null)
                {
                    var randomPosts = await _articleService.GetRandomPostsForCategory(randomCategory.Id, 6);

                    var model = new RandomCategoryViewModel
                    {
                        Category = randomCategory,
                        Posts = randomPosts
                    };

                    return View(model);
                }

                return View(new RandomCategoryViewModel());
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("NotFound", "Error");
            }
        }
    }
}        