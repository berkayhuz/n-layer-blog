using HuzlabBlog.Entities.Entities;

namespace HuzlabBlog.Entities.DTOs.Users
{
	public class UserDto
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Slug { get; set; }
        public string Biography { get; set; }
        public bool EmailConfirmed { get; set; }
		public string PhoneNumber { get; set; }
		public int AccessFailedCount { get; set; }
		public string Role { get; set; }

        private Image _image;
        public Image Image
        {
            get { return _image ?? (_image = new Image()); }
            set { _image = value; }
        }
        public UserDto()
        {
            Image = new Image(); 
        }
    }
}
