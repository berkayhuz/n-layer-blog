using HuzlabBlog.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace HuzlabBlog.Web.ViewComponents
{
    public class HomeCategoryViewComponent : ViewComponent
    {
        private readonly ICategoryService categoryService;

        public HomeCategoryViewComponent(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var categories = await categoryService.GetAllCategoriesNonDeletedIndex();
                return View(categories);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("NotFound", "Error");
            }
        }
    }
}
