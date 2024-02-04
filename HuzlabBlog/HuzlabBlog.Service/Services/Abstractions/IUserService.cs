using HuzlabBlog.Entities.DTOs.Categories;
using HuzlabBlog.Entities.DTOs.Users;
using HuzlabBlog.Entities.Entities;
using Microsoft.AspNetCore.Identity;

namespace HuzlabBlog.Service.Services.Abstractions
{
    public interface IUserService
    {
		Task<List<UserDto>> GetAllUsersWithRoleAsync();
		Task<List<AppRole>> GetAllRolesAsync();
		Task<(IdentityResult identityResult, string? email)> RegisterAsync(RegisterDto registerDto);   
		Task<IdentityResult> UpdateUserAsync(UserUpdateDto userUpdateDto);
		Task<(IdentityResult identityResult, string? email)> DeleteUserAsync(Guid userId);
		Task<AppUser> GetAppUserByIdAsync(Guid userId);
		Task<string> GetUserRoleAsync(AppUser user);
		Task<UserProfileDto> GetUserProfileAsync();
		Task<UserViewDto> GetUserBySlug(string slug);
		Task<bool> UserProfileUpdateAsync(UserProfileDto userProfileDto);
		Task<bool> UserPasswordUpdateAsync(UserPasswordDto userPasswordDto);
		Task<UserHeaderDto> GetUserHeaderAsync();
		Task<UserProfileWithArticlesDto> GetUserProfileWithArticlesAsync();
	}
}
