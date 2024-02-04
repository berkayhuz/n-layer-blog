﻿using HuzlabBlog.Entities.DTOs.Categories;
using HuzlabBlog.Entities.Entities;
using Microsoft.AspNetCore.Http;

namespace HuzlabBlog.Entities.DTOs.Articles
{
	public class ArticleUpdateDto
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
        public string MiniDescription { get; set; }
        public Guid CategoryId { get; set; }
        public bool IsSlider { get; set; }
        public bool IsEditorChoosed { get; set; }
        public Image Image { get; set; }
		public IFormFile? Photo { get; set; }

		public IList<CategoryDto> Categories { get; set; }
	}
}
