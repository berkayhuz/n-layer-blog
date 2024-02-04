using HuzlabBlog.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace HuzlabBlog.Entities.Entities
{
    public class AppUser : IdentityUser<Guid>, IBaseEntity
	{
        public string FirstName { get; set; } = "İsim";
        public string LastName { get; set; } = "Soyisim";
        public string Slug { get; set; } = string.Empty;
        public string? Biography { get; set; } = "Biyografi.";
        public Guid? ImageId {  get; set; } = Guid.Parse("5783A0A4-0C35-4F26-A466-05636F9FEE2C");
		public Image? Image {  get; set; }
        public string? EmailVerificationCode { get; set; }
        public ICollection<Article>? Articles {  get; set; }

        public AppUser()
        {
            if (string.IsNullOrEmpty(Slug))
            {
                Slug = "user-" + Guid.NewGuid().ToString("N").ToLower();
            }
        }
    }
}
