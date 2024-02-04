namespace HuzlabBlog.Entities.DTOs.Articles
{
    public class ArticleUserListDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
