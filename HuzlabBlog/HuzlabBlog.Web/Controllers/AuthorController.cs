
using HuzlabBlog.Service.Services.Abstractions;
using HuzlabBlog.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace HuzlabBlog.Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IUserService _userService;

        public AuthorController(IUserService userService)
        {
            _userService = userService;
        }
        [Route("{id}")]
        public async Task<IActionResult> Profile(string id, int page = 1)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return RedirectToAction("Index");
                }

                var user = await _userService.GetUserBySlug(id);

                if (user == null)
                {
                    return NotFound();
                }

                int pageSize = 4;
                var articles = user.Articles.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                var totalArticles = user.Articles.Count;

                var viewModel = new UserProfileViewModel
                {
                    User = user,
                    Articles = articles,
                    PaginationInfo = new PaginationInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        TotalItems = totalArticles
                    }
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("NotFound", "Error");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Index()
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
