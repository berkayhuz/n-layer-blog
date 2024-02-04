using HuzlabBlog.Entities.DTOs.Articles;
using HuzlabBlog.Entities.Entities;
using Microsoft.AspNetCore.Http;

namespace HuzlabBlog.Entities.DTOs.Users
{
    public class UserViewDto
    {
        public List<ArticleUserListDto> Articles { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Slug { get; set; }
        public string PhoneNumber { get; set; }
        public string Biography { get; set; }
        public Image Image { get; set; }
    }
}
