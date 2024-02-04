using HuzlabBlog.Entities.Entities;

namespace HuzlabBlog.Entities.DTOs.Categories
{
    public class CategoryListDto
    {
        public List<Category> Categories { get; set; }

        public CategoryListDto()
        {
            Categories = new List<Category>();
        }
    }
}
