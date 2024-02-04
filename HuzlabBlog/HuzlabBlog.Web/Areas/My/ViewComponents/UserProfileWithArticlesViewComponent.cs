using HuzlabBlog.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace HuzlabBlog.Web.Areas.My.ViewComponents
{
    public class UserProfileWithArticlesViewComponent : ViewComponent
    {
        private readonly IUserService _userService;

        public UserProfileWithArticlesViewComponent(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var userProfileWithArticles = await _userService.GetUserProfileWithArticlesAsync();
                return View("Default", userProfileWithArticles);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("NotFound", "Error");
            }
        }
    }
}
