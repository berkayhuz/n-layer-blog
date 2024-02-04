using Microsoft.AspNetCore.Mvc;

namespace HuzlabBlog.Web.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var errorDetails = GetErrorDetails(statusCode);
            ViewData["StatusCode"] = statusCode;
            ViewData["ErrorTitle"] = errorDetails.Title;
            ViewData["ErrorMessage"] = errorDetails.Message;
            return View("NotFound");
        }

        private (string Title, string Message) GetErrorDetails(int statusCode)
        {
            switch (statusCode)
            {
                case 400:
                    return ("Bad Request", "The server did not understand the request.");
                case 401:
                    return ("Unauthorized", "You are not authorized to view the requested resource.");
                case 403:
                    return ("Forbidden", "You don't have permission to access the requested resource.");
                case 404:
                    return ("Not Found", "The requested resource could not be found on the server.");
                case 500:
                    return ("Internal Server Error", "An unexpected error occurred on the server.");
                default:
                    return ("Error", "An error occurred while processing your request.");
            }
        }
    }
}
