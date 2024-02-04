using HuzlabBlog.Entities.DTOs.Articles;
using HuzlabBlog.Entities.DTOs.Categories;

namespace HuzlabBlog.Web.Models
{
    public class RandomCategoryViewModel
    {
        public CategoryDto Category { get; set; }
        public List<ArticleDto> Posts { get; set; }
    }
}
