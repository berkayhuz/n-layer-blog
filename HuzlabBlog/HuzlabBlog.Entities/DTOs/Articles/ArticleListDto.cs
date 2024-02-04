using HuzlabBlog.Entities.DTOs.Categories;
using HuzlabBlog.Entities.Entities;

namespace HuzlabBlog.Entities.DTOs.Articles
{
    public class ArticleListDto
    {
        public IList<Article> Articles { get; set; }
        public IList<CategoryDto> Categories { get; set; }
        public Guid? CategoryId { get; set; }
        public string? CategorySlug { get; set; }
        public virtual string CategoryName { get; set; }
        public virtual string Slug { get; set; }
        public virtual int CurrentPage { get; set; } = 1;
        public virtual int PageSize { get; set; } = 3;
        public virtual int ViewCount { get; set; }
        public virtual bool IsSlider { get; set; }
        public virtual bool IsEditorChoosed { get; set; }
        public virtual int TotalCount { get; set; }
        public virtual int TotalPages => (int)Math.Ceiling(decimal.Divide(TotalCount, PageSize));
        public virtual bool ShowPrevious => CurrentPage > 1;
        public virtual bool ShowNext => CurrentPage < TotalPages;
        public virtual bool IsAscending { get; set; } = false;
    }
}
