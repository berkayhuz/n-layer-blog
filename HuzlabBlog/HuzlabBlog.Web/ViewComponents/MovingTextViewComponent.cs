using Microsoft.AspNetCore.Mvc;

namespace HuzlabBlog.Web.ViewComponents
{
    public class MovingTextViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("NotFound", "Error");
            }
        }
    }
}
