using HuzlabBlog.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HuzlabBlog.Service.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<AppUser?> FindBySlugAsync(this UserManager<AppUser> userManager, string slug)
        {
            return await userManager.Users.FirstOrDefaultAsync(u => u.Slug == slug);
        }
        public static async Task<AppUser?> FindByEmailVerificationCodeAsync(this UserManager<AppUser> userManager, string emailVerificationCode)
        {
            return await userManager.Users.FirstOrDefaultAsync(u => u.EmailVerificationCode == emailVerificationCode);
        }
    }
}