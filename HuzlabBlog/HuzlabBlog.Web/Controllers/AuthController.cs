using HuzlabBlog.Entities.DTOs.Users;
using HuzlabBlog.Entities.Entities;
using HuzlabBlog.Service.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using HuzlabBlog.Service.Extensions;


namespace HuzlabBlog.Web.Controllers
{
	public class AuthController : Controller
	{
		private readonly UserManager<AppUser> userManager;
		private readonly SignInManager<AppUser> signInManager;
		private readonly IUserService userService;
		public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IUserService userService)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
			this.userService = userService;
        }
        //REGİSTER İŞLEMİ
        //REGİSTER İŞLEMİ
        //REGİSTER İŞLEMİ
        //REGİSTER İŞLEMİ

        
        [HttpGet]
        public IActionResult Register()
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await userService.RegisterAsync(registerDto);

                    if (result.identityResult.Succeeded)
                    {
                        TempData["SuccessMessage"] = "Kaydınız başarıyla tamamlandı. E-postanızı kontrol edin ve hesabınızı doğrulayın.";
                        return RedirectToAction("ConfirmEmail", "Auth");
                    }

                    foreach (var error in result.identityResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

                return View(registerDto);

            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("NotFound", "Error");
            }
        
        }


        //REGİSTER İŞLEMİ
        //REGİSTER İŞLEMİ
        //REGİSTER İŞLEMİ
        //REGİSTER İŞLEMİ



        //LOGİN İŞLEMİ
        //LOGİN İŞLEMİ
        //LOGİN İŞLEMİ
        //LOGİN İŞLEMİ
        //LOGİN İŞLEMİ
        [HttpGet]
        public IActionResult Login()
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
		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Login(UserLoginDto userLoginDto)
		{
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await userManager.FindByEmailAsync(userLoginDto.Email);
                    if (user != null)
                    {
                        if (!user.EmailConfirmed)
                        {
                            ViewData["ErrorMessage"] = "Hesabınız henüz doğrulanmamış. Lütfen e-posta adresinize gönderilen doğrulama linkini kontrol edin.";
                            return View();
                        }

                        var result = await signInManager.PasswordSignInAsync(user, userLoginDto.password, userLoginDto.RememberMe, false);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index", "Home", new { area = "My" });
                        }
                        else
                        {
                            ViewData["ErrorMessage"] = "E-Posta adresiniz veya Şifreniz yanlıştır.";
                            return View();
                        }
                    }
                    else
                    {
                        ViewData["ErrorMessage"] = "E-Posta adresiniz veya Şifreniz yanlıştır.";
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("NotFound", "Error");
            }
        }
        //LOGİN İŞLEMİ
        //LOGİN İŞLEMİ
        //LOGİN İŞLEMİ
        //LOGİN İŞLEMİ
        //LOGİN İŞLEMİ
        [Authorize]
		[HttpGet]
        [Route("logout/")]
        public async Task<IActionResult> Logout()
		{
            try
            {
                await signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("NotFound", "Error");
            }
        }
		[Authorize]
		[HttpGet]
        [Route("register/")]
        public async Task<IActionResult> AccessDenied()
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

        
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            try
            {


                if (userId == null || token == null)
                {
                    // Geçersiz istek, hata sayfasına yönlendir.
                    return View("Privacy", "Policy");
                }

                var user = await userManager.FindByIdAsync(userId);

                if (user == null)
                {
                    // Kullanıcı bulunamadı, hata sayfasına yönlendir.
                    return View("Error");
                }

                var result = await userManager.ConfirmEmailAsync(user, token);

                if (result.Succeeded)
                {
                    // E-posta doğrulama başarılı, kullanıcıyı giriş yapmaya yönlendir.
                    await userManager.AddToRoleAsync(user, "User"); // Giriş yaptıktan sonra kullanıcının atanacağı rolü belirtin.


                    return RedirectToAction("Index", "My");
                }
                else
                {
                    // E-posta doğrulama başarısız, hata sayfasına yönlendir.
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("NotFound", "Error");
            }
        }


    }
}