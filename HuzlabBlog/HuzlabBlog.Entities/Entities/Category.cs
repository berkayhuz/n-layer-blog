using HuzlabBlog.Core.Entities;

namespace HuzlabBlog.Entities.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            
        }
        public Category(string name, string createdBy, string slug)
        {
            CreatedBy = createdBy;
            Name = name;
            Slug = slug;
        }
        public string Name { get; set; }
        public string? Slug { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
