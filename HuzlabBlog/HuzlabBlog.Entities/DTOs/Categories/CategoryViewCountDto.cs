namespace HuzlabBlog.Entities.DTOs.Categories
{
    public class CategoryViewCountDto
    {
        public string CategoryName { get; set; }
        public Guid Id { get; set; }
        public int TotalViewCount { get; set; }
    }
}
