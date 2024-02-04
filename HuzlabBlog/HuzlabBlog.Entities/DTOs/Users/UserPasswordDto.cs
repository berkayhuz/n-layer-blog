namespace HuzlabBlog.Entities.DTOs.Users
{
    public class UserPasswordDto
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
