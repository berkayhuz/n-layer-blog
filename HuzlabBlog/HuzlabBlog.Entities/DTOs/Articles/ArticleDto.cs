using HuzlabBlog.Entities.DTOs.Categories;
using HuzlabBlog.Entities.Entities;

namespace HuzlabBlog.Entities.DTOs.Articles
{
    public class ArticleDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public string MiniDescription { get; set; }
        public Guid CategoryId { get; set; }
        public string categorySlug { get; set; }
        public CategoryDto Category { get; set; }
        public string CreatedBy { get; set; }
        public bool IsSlider { get; set; }
        public bool IsEditorChoosed { get; set; }

        private Image _image;
        public Image Image
        {
            get { return _image ?? (_image = new Image()); }
            set { _image = value; }
        }
        public AppUser User {  get; set; }
        public int ViewCount {  get; set; }
        public DateTime CreatedDate {  get; set; }
		public bool IsDeleted { get; set; }
    }
}
