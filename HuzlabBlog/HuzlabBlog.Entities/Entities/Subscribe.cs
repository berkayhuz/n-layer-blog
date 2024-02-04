using HuzlabBlog.Core.Entities;

namespace HuzlabBlog.Entities.Entities
{
    public class Subscribe : BaseEntity
    {
        public Subscribe()
        {

        }
        public Subscribe(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}