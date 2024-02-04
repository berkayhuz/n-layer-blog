using HuzlabBlog.Core.Entities;

namespace HuzlabBlog.Entities.Entities
{
    public class Article : BaseEntity
    {
        public Article() 
        { 
        
        }
        public Article(string title, string content, Guid userId, Guid categoryId, Guid imageId, string createdBy, bool isSlider, bool ısEditorChoosed, string miniDescription, string slug)
        {
            Title = title;
            Content = content;
            UserId = userId;
            CategoryId = categoryId;
            ImageId = imageId;
            CreatedBy = createdBy;
            IsSlider = isSlider;
            IsEditorChoosed = ısEditorChoosed;
            MiniDescription = miniDescription;
            Slug = slug;
        }
        public string Title { get; set; }
        public string MiniDescription { get; set; }
        public string Content { get; set; }
        public bool IsSlider {  get; set; }
        public string? Slug { get; set; }
        public bool IsEditorChoosed { get; set; }
        public int ViewCount { get; set; } = 0;
        public Guid CategoryId {  get; set; }
        public Category Category { get; set; }
        public Guid? ImageId {  get; set; }
        public Image Image {  get; set; }
        public Guid UserId { get; set; }
        public AppUser User {  get; set; }
        public ICollection<ArticleVisitor> ArticleVisitors { get; set; }
    }
}