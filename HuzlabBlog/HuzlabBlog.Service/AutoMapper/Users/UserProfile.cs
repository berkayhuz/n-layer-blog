using AutoMapper;
using HuzlabBlog.Entities.DTOs.Users;
using HuzlabBlog.Entities.Entities;

namespace HuzlabBlog.Service.AutoMapper.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
			CreateMap<AppUser, UserDto>().ReverseMap();
			CreateMap<AppUser, UserAddDto>().ReverseMap();
			CreateMap<AppUser, UserUpdateDto>().ReverseMap();
			CreateMap<AppUser, UserProfileDto>().ReverseMap();
			CreateMap<AppUser, UserViewDto>().ReverseMap();
			CreateMap<AppUser, UserPasswordDto>().ReverseMap();
			CreateMap<AppUser, RegisterDto>().ReverseMap();
			CreateMap<AppUser, UserHeaderDto>().ReverseMap();
			CreateMap<AppUser, UserProfileCardDto>().ReverseMap();
			CreateMap<AppUser, UserProfileWithArticlesDto>().ReverseMap();
        }
    }
}
