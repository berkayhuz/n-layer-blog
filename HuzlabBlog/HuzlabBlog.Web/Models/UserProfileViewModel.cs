using HuzlabBlog.Entities.DTOs.Articles;
using HuzlabBlog.Entities.DTOs.Users;

namespace HuzlabBlog.Web.Models
{
    public class UserProfileViewModel
    {
        public UserViewDto User { get; set; }
        public List<ArticleUserListDto> Articles { get; set; }
        public PaginationInfo PaginationInfo { get; set; }
    }
}
