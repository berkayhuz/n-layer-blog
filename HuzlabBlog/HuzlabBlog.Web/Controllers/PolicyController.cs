using Microsoft.AspNetCore.Mvc;

namespace HuzlabBlog.Web.Controllers
{
    public class PolicyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("kvkk/")]
        public IActionResult Kvkk()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("~/Views/Error/NotFound.cshtml");
            }
        }
        [HttpGet]
        [Route("privacy-policy/")]
        public IActionResult Privacy()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("~/Views/Error/NotFound.cshtml");
            }
        }
        [HttpGet]
        [Route("terms-and-conditions/")]
        public IActionResult TermsandConditions()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("~/Views/Error/NotFound.cshtml");
            }
        }
        [HttpGet]
        [Route("term-of-use/")]
        public IActionResult TermofUse()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("~/Views/Error/NotFound.cshtml");
            }
        }
        [HttpGet]
        [Route("bgys-policy/")]
        public IActionResult Bgys()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("~/Views/Error/NotFound.cshtml");
            }
        }
        [HttpGet]
        [Route("security-policy/")]
        public IActionResult Security()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("~/Views/Error/NotFound.cshtml");
            }
        }
        [HttpGet]
        [Route("cookies/")]
        public IActionResult Cookies()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("~/Views/Error/NotFound.cshtml");
            }
        }
        [HttpGet]
        [Route("intellectual-property/")]
        public IActionResult IntellectualProperty()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("~/Views/Error/NotFound.cshtml");
            }
        }
    }
}
