using HuzlabBlog.Entities.DTOs.Articles;

namespace HuzlabBlog.Entities.DTOs.Users
{
    public class UserProfileWithArticlesDto
    {
        public UserProfileCardDto UserProfile { get; set; }
        public List<ArticleDto> UserArticles { get; set; }
    }
}
