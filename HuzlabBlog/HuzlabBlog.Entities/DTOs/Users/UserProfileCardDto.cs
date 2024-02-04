using HuzlabBlog.Entities.Entities;

namespace HuzlabBlog.Entities.DTOs.Users
{
    public class UserProfileCardDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }
        public string Slug { get; set; }
        public Image Image { get; set; }
    }
}
