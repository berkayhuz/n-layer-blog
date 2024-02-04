using HuzlabBlog.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace HuzlabBlog.Web.ViewComponents
{
    public class UserHeaderViewComponent : ViewComponent
    {
        private readonly IUserService _userService;

        public UserHeaderViewComponent(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var userHeaderDto = await _userService.GetUserHeaderAsync();
                return View(userHeaderDto);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("NotFound", "Error");
            }
        }
    }
}
