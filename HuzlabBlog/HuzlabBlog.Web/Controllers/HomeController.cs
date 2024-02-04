using AutoMapper;
using FluentValidation;
using HuzlabBlog.Data.UnitOfWorks;
using HuzlabBlog.Entities.DTOs.Subscribe;
using HuzlabBlog.Entities.Entities;
using HuzlabBlog.Service.Extensions;
using HuzlabBlog.Service.Services.Abstractions;
using HuzlabBlog.Service.Services.Concrete;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace HuzlabBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleService articleService;
        private readonly ITranslationService translationService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IValidator<Subscribe> validator;
        private readonly ISubscribeService subscribeService;
        private readonly IToastNotification toast;

        public HomeController(ITranslationService translationService,ILogger<HomeController> logger, IArticleService articleService, IMapper mapper, IValidator<Subscribe> validator, IToastNotification toast, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork, ISubscribeService subscribeService)
        {
            _logger = logger;
            this.articleService = articleService;
            this.httpContextAccessor = httpContextAccessor;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.validator = validator;
            this.subscribeService = subscribeService;
            this.toast = toast;
            this.translationService = translationService;

        }

        [HttpPost]
        public async Task<IActionResult> Add(SubscribeAddDto subscribeAddDto)
        {
            try
            {
                var map = mapper.Map<Subscribe>(subscribeAddDto);
                var result = await validator.ValidateAsync(map);

                if (subscribeAddDto.Name.Length < 2 || subscribeAddDto.Surname.Length < 2)
                {
                    string refererUrl = Request.Headers["Referer"];
                    if (!string.IsNullOrEmpty(refererUrl))
                    {
                        TempData["NotificationMessage"] = "İsim ve soyisim en az 2 harf içermelidir.";

                        return Redirect(refererUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                else if (!IsValidEmail(subscribeAddDto.Email))
                {
                    string refererUrl = Request.Headers["Referer"];
                    if (!string.IsNullOrEmpty(refererUrl))
                    {
                        string notificationMessage = "E-posta yanlış formatta. Lütfen geçerli bir e-posta adresi girin.";

                        TempData["NotificationMessage"] = notificationMessage;

                        return Redirect(refererUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    if (result.IsValid)
                    {
                        await subscribeService.SubscribeAsync(subscribeAddDto);

                        string refererUrl = Request.Headers["Referer"];
                        if (!string.IsNullOrEmpty(refererUrl))
                        {
                            TempData["NotificationMessage"] = "İşlem başarıyla tamamlandı.";

                            return Redirect(refererUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        result.AddToModelState(this.ModelState);

                        return RedirectToAction("HttpStatusCodeHandler", "Error", new { statusCode = 400 });
                    }
                }
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("NotFound", "Error");
            }
        }
        

        private bool IsValidEmail(string email)
        {
            return
                email.EndsWith("@hotmail.com") ||
                email.EndsWith("@hotmail.com.tr") ||
                email.EndsWith("@hotmail.co") ||
                email.EndsWith("@gmail.com") ||
                email.EndsWith("@gmail.com.tr") ||
                email.EndsWith("@gmail.co") ||
                email.EndsWith("@icloud.com") ||
                email.EndsWith("@icloud.com.tr") ||
                email.EndsWith("@icloud.co") ||
                email.EndsWith("@yahoo.com") ||
                email.EndsWith("@yahoo.co") ||
                email.EndsWith("@aol.com") ||
                email.EndsWith("@aol.co") ||
                email.EndsWith("@turktelekom.net") ||
                email.EndsWith("@turktelekom.com") ||
                email.EndsWith("@superonline.com") ||
                email.EndsWith("@superonline.net") ||
                email.EndsWith("@outlook.com") ||
                email.EndsWith("@outlook.co") ||
                email.EndsWith("@outlook.com.tr") ||
                email.EndsWith("@outlook.com.en") ||
                email.EndsWith("@outlook.com.ru") ||
                email.EndsWith("@outlook.com.de") ||
                email.EndsWith("@gmx.com") ||
                email.EndsWith("@protonmail.com") ||
                email.EndsWith("@zoho.com") ||
                email.EndsWith("@yandex.com") ||
                email.EndsWith("@mail.com") ||
                email.EndsWith("@disroot.com") ||
                email.EndsWith("@email.com") ||
                email.EndsWith("@fastmail.com") ||
                email.EndsWith("@hushmail.com") ||
                email.EndsWith("@tutanota.com") ||
                email.EndsWith("@mail.ru") ||
                email.EndsWith("@t-online.de") ||
                email.EndsWith("@comcast.net") ||
                email.EndsWith("@rambler.ru") ||
                email.EndsWith("@cox.net") ||
                email.EndsWith("@gmx.net") ||
                email.EndsWith("@posteo.de") ||
                email.EndsWith("@bluewin.ch") ||
                email.EndsWith("@bell.net") ||
                email.EndsWith("@zoho.eu") ||
                email.EndsWith("@aol.co.uk") ||
                email.EndsWith("@icloud.co.uk") ||
                email.EndsWith("@qq.co") ||
                email.EndsWith("@orange.es") ||
                email.EndsWith("@fastmail.co.uk");
        }
        [HttpGet]
        public async Task<ActionResult> Index()
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