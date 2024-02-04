using AutoMapper;
using FluentValidation;
using HuzlabBlog.Entities.DTOs.Articles;
using HuzlabBlog.Entities.DTOs.Categories;
using HuzlabBlog.Entities.DTOs.Users;
using HuzlabBlog.Entities.Entities;
using HuzlabBlog.Service.Consts;
using HuzlabBlog.Service.Extensions;
using HuzlabBlog.Service.Services.Abstractions;
using HuzlabBlog.Service.Services.Concrete;
using HuzlabBlog.Web.ResultMessages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace HuzlabBlog.Web.Areas.My.Controllers
{
    [Area("My")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IArticleService articleService;
        private readonly ICategoryService categoryService;
        private readonly IUserService userService;
        private readonly IValidator<AppUser> validator;
        private readonly IValidator<Article> articleValidator;
        private readonly IToastNotification toast;
        private readonly IMapper mapper;

        public HomeController(IValidator<Article> articleValidator, IArticleService articleService, ICategoryService categoryService, IUserService userService, IValidator<AppUser> validator, IToastNotification toast, IMapper mapper)
        {
            this.articleService = articleService;
            this.categoryService = categoryService;
            this.userService = userService;
            this.validator = validator;
            this.articleValidator = articleValidator;
            this.toast = toast;
            this.mapper = mapper;

        }
        [Route("my")]
        public async Task<IActionResult> Index()
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
		[Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}")]
		[HttpGet]
        [Route("create-category/")]
        public IActionResult CreateCategory()
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
		[Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}")]
		[HttpPost]
        [Route("create-category/")]
        public async Task<IActionResult> CreateCategory(CategoryAddDto categoryAddDto)
		{
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(categoryAddDto);
                }

                try
                {
                    await categoryService.CreateCategoryAsync(categoryAddDto);
                    ViewBag.SuccessMessage = "Kategori başarıyla oluşturuldu";
                    return View();
                }
                catch (Exception ex)
                {
                    ViewData["ErrorMessage"] = "Kategori oluştururken bir hata meydana geldi";
                    return View(categoryAddDto);
                }
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("~/Views/Error/NotFound.cshtml");
            }
        }
        [Route("delete-post/{articleId}")]
        public async Task<IActionResult> Delete(Guid articleId)
        {
            try
            {


                var title = await articleService.SafeDeleteArticleAsync(articleId);
                toast.AddSuccessToastMessage(Messages.Article.Delete(title), new ToastrOptions()
                {
                    Title = "İşlem Başarılı"
                });

                return RedirectToAction("Index", "Home", new { Area = "My" });
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("~/Views/Error/NotFound.cshtml");
            }
        }
        [Route("recover-post/{articleId}")]
        public async Task<IActionResult> UndoDelete(Guid articleId)
        {
            try
            {


                var title = await articleService.UndoDeleteArticleAsync(articleId);
                toast.AddSuccessToastMessage(Messages.Article.UndoDelete(title), new ToastrOptions() { Title = "İşlem Başarılı" });


                return RedirectToAction("DeletedPosts", "Home", new { Area = "My" });
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("~/Views/Error/NotFound.cshtml");
            }
        }
        [Route("deleted-posts/")]
        [HttpGet]
        public async Task<IActionResult> DeletedPosts()
        {
            try
            {


                var articles = await articleService.GetAllArticlesWithCategoryDeletedAsync();
                return View(articles);

            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("~/Views/Error/NotFound.cshtml");
            }
        }
        [Route("personel-information/")]
        [HttpGet]
        public async Task<IActionResult> PersonalInformation()
        {
            try
            {


                var profile = await userService.GetUserProfileAsync();

                return View(profile);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("~/Views/Error/NotFound.cshtml");
            }
        }
        [HttpPost]
        public async Task<IActionResult> PersonalInformation(UserProfileDto userProfileDto)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    var result = await userService.UserProfileUpdateAsync(userProfileDto);
                    if (result)
                    {
                        toast.AddSuccessToastMessage("Profil güncelleme işlemi tamamlandı", new ToastrOptions { Title = "İşlem Başarılı" });
                        return RedirectToAction("Index", "Home", new { Area = "My" });
                    }
                    else
                    {
                        var profile = await userService.GetUserProfileAsync();
                        toast.AddErrorToastMessage("Profil güncelleme işlemi tamamlanamadı", new ToastrOptions { Title = "İşlem Başarısız" });
                        return View(profile);
                    }
                }
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("~/Views/Error/NotFound.cshtml");
            }
        }

        // CHANGE PASSWORD İŞLEMLERİ
        // CHANGE PASSWORD İŞLEMLERİ
        // CHANGE PASSWORD İŞLEMLERİ
        // CHANGE PASSWORD İŞLEMLERİ
        [HttpGet]
        [Route("change-password/")]
        public IActionResult ChangePassword()
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(UserPasswordDto userPasswordDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await userService.UserPasswordUpdateAsync(userPasswordDto);

                    if (result)
                    {
                        TempData["SuccessMessage"] = "Şifreniz başarıyla değiştirildi.";
                        return RedirectToAction("ChangePassword");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Şifre değiştirme işlemi başarısız.");
                    }
                }

                return View(userPasswordDto);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("~/Views/Error/NotFound.cshtml");
            }
        }
        // CHANGE PASSWORD İŞLEMLERİ
        // CHANGE PASSWORD İŞLEMLERİ
        // CHANGE PASSWORD İŞLEMLERİ
        // CHANGE PASSWORD İŞLEMLERİ
        [Route("add-post/")]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            try
            {
                var categories = await categoryService.GetAllCategoriesNonDeleted();
                return View(new ArticleAddDto { Categories = categories });
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("~/Views/Error/NotFound.cshtml");
            }
        }
        [Route("add-post/")]
        [HttpPost]
        public async Task<IActionResult> Add(ArticleAddDto articleAddDto)
        {
            try
            {
                var map = mapper.Map<Article>(articleAddDto);
                var result = await articleValidator.ValidateAsync(map);

                if (result.IsValid)
                {
                    await articleService.CreateArticleAsync(articleAddDto);
                    toast.AddSuccessToastMessage(Messages.Article.Add(articleAddDto.Title), new ToastrOptions { Title = "İşlem Başarılı" });
                    return RedirectToAction("Index", "Home", new { Area = "My" });
                }
                else
                {
                    result.AddToModelState(this.ModelState);
                }
                var categories = await categoryService.GetAllCategoriesNonDeleted();
                return View(new ArticleAddDto { Categories = categories });

            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("~/Views/Error/NotFound.cshtml");
            }
        }
    }
}
