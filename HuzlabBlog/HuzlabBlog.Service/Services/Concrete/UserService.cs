using AutoMapper;
using Azure.Core;
using HuzlabBlog.Data.UnitOfWorks;
using HuzlabBlog.Entities.DTOs.Articles;
using HuzlabBlog.Entities.DTOs.Users;
using HuzlabBlog.Entities.Entities;
using HuzlabBlog.Entities.Enums;
using HuzlabBlog.Service.Email.Abstractions;
using HuzlabBlog.Service.Extensions;
using HuzlabBlog.Service.Helpers.Images;
using HuzlabBlog.Service.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Entity;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Routing;

namespace HuzlabBlog.Service.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IImageHelper imageHelper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMapper mapper;
        private readonly IEmailSender emailSender;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly ClaimsPrincipal _user;
        private readonly IUrlHelper urlHelper; // IUrlHelper ekleyin

        public UserService(IEmailSender emailSender, IUnitOfWork unitOfWork, IImageHelper imageHelper, IHttpContextAccessor httpContextAccessor, IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IUrlHelperFactory urlHelperFactory)
        {
            this.unitOfWork = unitOfWork;
            this.imageHelper = imageHelper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.emailSender = emailSender;
            this.roleManager = roleManager;

            var actionContext = new ActionContext(httpContextAccessor.HttpContext, httpContextAccessor.HttpContext.GetRouteData(), new ControllerActionDescriptor());
            this.urlHelper = urlHelperFactory.GetUrlHelper(actionContext);
        }

        public async Task<(IdentityResult identityResult, string? email)> RegisterAsync(RegisterDto registerDto)
        {
            var user = new AppUser
            {
                UserName = registerDto.Email,
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Slug = registerDto.Slug
            };

            var existingUserWithSlug = await userManager.FindBySlugAsync(registerDto.Slug);
            if (existingUserWithSlug != null)
            {
                var errorResult = IdentityResult.Failed(new IdentityError { Code = "DuplicateSlug", Description = "Kullanıcı adı kullanılıyor." });
                return (errorResult, null);
            }

            var result = await userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                var defaultRole = "User";
                if (!await roleManager.RoleExistsAsync(defaultRole))
                {
                    await roleManager.CreateAsync(new AppRole { Name = defaultRole });
                }

                await userManager.AddToRoleAsync(user, defaultRole);

                var emailVerificationToken = await userManager.GenerateEmailConfirmationTokenAsync(user);

                var emailVerificationLink = urlHelper.Action("ConfirmEmail", "Auth", new { userId = user.Id, token = emailVerificationToken });

                await emailSender.SendEmailAsync(user.Email, "Hesap Doğrulama", $"Lütfen hesabınızı doğrulamak için aşağıdaki linke tıklayın: {emailVerificationLink}");

                return (result, user.Email);
            }
            else
            {
                return (result, null);
            }
        }

        private string GenerateVerificationCode()
        {
            Random random = new Random();
            int verificationCode = random.Next(100000, 999999);
            return verificationCode.ToString();
        }
        public async Task<(IdentityResult identityResult, string? email)> DeleteUserAsync(Guid userId)
		{
			var user = await GetAppUserByIdAsync(userId);
			var result = await userManager.DeleteAsync(user);
			if (result.Succeeded)
				return (result, user.Email);
			else
				return (result, null);
		}
		public async Task<List<AppRole>> GetAllRolesAsync()
		{
			return await roleManager.Roles.ToListAsync();
		}
        public async Task<List<UserDto>> GetAllUsersWithRoleAsync()
        {
            var users = await userManager.Users.ToListAsync();
            var map = mapper.Map<List<UserDto>>(users);


            foreach (var item in map)
            {
                var findUser = await userManager.FindByIdAsync(item.Id.ToString());
                var role = string.Join("", await userManager.GetRolesAsync(findUser));

                item.Role = role;
            }

            return map;
        }
        public async Task<AppUser> GetAppUserByIdAsync(Guid userId)
		{
			return await userManager.FindByIdAsync(userId.ToString());
		}
		public async Task<string> GetUserRoleAsync(AppUser user)
		{
			return string.Join("", await userManager.GetRolesAsync(user));
		}
		public async Task<IdentityResult> UpdateUserAsync(UserUpdateDto userUpdateDto)
		{
			var user = await GetAppUserByIdAsync(userUpdateDto.Id);
			var userRole = await GetUserRoleAsync(user);

			var result = await userManager.UpdateAsync(user);
			if (result.Succeeded)
			{
				await userManager.RemoveFromRoleAsync(user, userRole);
				var findRole = await roleManager.FindByIdAsync(userUpdateDto.RoleId.ToString());
				await userManager.AddToRoleAsync(user, findRole.Name);
				return result;
			}
			else
				return result;
		}
        public async Task<UserProfileDto> GetUserProfileAsync()
        {
            var userId = _user.GetLoggedInUserId();

            var getUserWithImage = await unitOfWork.GetRepository<AppUser>().GetAsync(x => x.Id == userId, x => x.Image);
            var map = mapper.Map<UserProfileDto>(getUserWithImage);
            map.Image.FileName = getUserWithImage.Image.FileName;

            return map;
        }
        public async Task<UserHeaderDto> GetUserHeaderAsync()
        {
            var userId = _user.GetLoggedInUserId();

            var getUserWithImage = await unitOfWork.GetRepository<AppUser>().GetAsync(x => x.Id == userId, x => x.Image);
            var map = mapper.Map<UserHeaderDto>(getUserWithImage);
            map.Image.FileName = getUserWithImage.Image.FileName;

            return map;
        }
        public async Task<UserProfileWithArticlesDto> GetUserProfileWithArticlesAsync()
        {
            var userId = _user.GetLoggedInUserId();

            var getUserWithImage = await unitOfWork.GetRepository<AppUser>().GetAsync(x => x.Id == userId, x => x.Image);
            var userProfile = mapper.Map<UserProfileCardDto>(getUserWithImage);
            userProfile.Image.FileName = getUserWithImage.Image.FileName;

            var userArticles = await unitOfWork.GetRepository<Article>().GetAllAsync(
                a => a.UserId == userId && !a.Category.IsDeleted && !a.IsDeleted,
                a => a.Category, i => i.Image, u => u.User
            );
            var mappedArticles = mapper.Map<List<ArticleDto>>(userArticles);

            var userProfileWithArticles = new UserProfileWithArticlesDto
            {
                UserProfile = userProfile,
                UserArticles = mappedArticles
            };

            return userProfileWithArticles;
        }
        public async Task<UserViewDto> GetUserBySlug(string slug)
        {
            var userEntity = await unitOfWork.GetRepository<AppUser>().GetAsync(u => u.Slug == slug, u => u.Image, u => u.Articles);

            if (userEntity == null)
            {
                return null;
            }

            var userDto = mapper.Map<UserViewDto>(userEntity);
            userDto.Image = userEntity.Image;
            userDto.Articles = userEntity.Articles.Select(article => mapper.Map<ArticleUserListDto>(article)).ToList();

            return userDto;
        }
        private async Task<Guid> UploadImageForUser(UserProfileDto userProfileDto)
		{
			var userEmail = _user.GetLoggedInEmail();

			var imageUpload = await imageHelper.Upload($"{userProfileDto.FirstName}{userProfileDto.LastName}", userProfileDto.Photo, ImageType.User);
			Image image = new(imageUpload.FullName, userProfileDto.Photo.ContentType, userEmail);
			await unitOfWork.GetRepository<Image>().AddAsync(image);

			return image.Id;
		}
		public async Task<bool> UserProfileUpdateAsync(UserProfileDto userProfileDto)
		{
			var userId = _user.GetLoggedInUserId();
			var user = await GetAppUserByIdAsync(userId);

			var isVerified = await userManager.CheckPasswordAsync(user, userProfileDto.CurrentPassword);
			if (isVerified && userProfileDto.NewPassword != null)
			{
				var result = await userManager.ChangePasswordAsync(user, userProfileDto.CurrentPassword, userProfileDto.NewPassword);
				if (result.Succeeded)
				{
					await userManager.UpdateSecurityStampAsync(user);
					await signInManager.SignOutAsync();
					await signInManager.PasswordSignInAsync(user, userProfileDto.NewPassword, true, false);

					mapper.Map(userProfileDto, user);

					if (userProfileDto.Photo != null)
						user.ImageId = await UploadImageForUser(userProfileDto);

					await userManager.UpdateAsync(user);
					await unitOfWork.SaveAsync();

					return true;
				}
				else
					return false;
			}
			else if (isVerified)
			{
				await userManager.UpdateSecurityStampAsync(user);
				mapper.Map(userProfileDto, user);

				if (userProfileDto.Photo != null)
					user.ImageId = await UploadImageForUser(userProfileDto);

				await userManager.UpdateAsync(user);
				await unitOfWork.SaveAsync();
				return true;
			}
			else
				return false;
		}
        public async Task<bool> UserPasswordUpdateAsync(UserPasswordDto userPasswordDto)
        {
            var userId = _user.GetLoggedInUserId();
            var user = await GetAppUserByIdAsync(userId);

            if (user == null)
            {
                // Kullanıcı bulunamadı, isteği başarısız olarak işaretle.
                return false;
            }

            var isVerified = await userManager.CheckPasswordAsync(user, userPasswordDto.CurrentPassword);

            if (!isVerified)
            {
                // Geçerli şifre doğrulama başarısız, isteği başarısız olarak işaretle.
                return false;
            }

            if (!string.IsNullOrEmpty(userPasswordDto.NewPassword))
            {
                var result = await userManager.ChangePasswordAsync(user, userPasswordDto.CurrentPassword, userPasswordDto.NewPassword);

                if (!result.Succeeded)
                {
                    // Şifre değiştirme işlemi başarısız, isteği başarısız olarak işaretle.
                    return false;
                }

                // Gerekli güvenlik adımlarını uygula.
                await userManager.UpdateSecurityStampAsync(user);
                await signInManager.SignOutAsync();
                await signInManager.PasswordSignInAsync(user, userPasswordDto.NewPassword, true, false);

                // Kullanıcı verilerini güncelle.
                mapper.Map(userPasswordDto, user);
                await userManager.UpdateAsync(user);
                await unitOfWork.SaveAsync();

                return true;
            }
            else
            {
                // Yeni şifre boş, sadece güvenlik adımlarını uygula ve kullanıcı verilerini güncelle.
                await userManager.UpdateSecurityStampAsync(user);
                mapper.Map(userPasswordDto, user);
                await userManager.UpdateAsync(user);
                await unitOfWork.SaveAsync();

                return true;
            }
        }
    }
}
