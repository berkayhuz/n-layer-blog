using AutoMapper;
using HuzlabBlog.Data.UnitOfWorks;
using HuzlabBlog.Entities.DTOs.Articles;
using HuzlabBlog.Entities.DTOs.Categories;
using HuzlabBlog.Entities.Entities;
using HuzlabBlog.Entities.Enums;
using HuzlabBlog.Service.Extensions;
using HuzlabBlog.Service.Helpers.Images;
using HuzlabBlog.Service.Helpers.Pagination;
using HuzlabBlog.Service.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace HuzlabBlog.Service.Services.Concrete
{
    public class ArticleService : IArticleService
	{
		private readonly IUnitOfWork unitofWork;
		private readonly IMapper mapper;
		private readonly ICategoryService categoryService;
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly ClaimsPrincipal _user;
		private readonly IImageHelper imageHelper;
		private Dictionary<string, List<ArticleDto>> userArticles = new Dictionary<string, List<ArticleDto>>();
		public ArticleService(ICategoryService categoryService, IUnitOfWork unitofWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IImageHelper imageHelper)
		{
			this.unitofWork = unitofWork;
			this.mapper = mapper;
			this.categoryService = categoryService;
			this.httpContextAccessor = httpContextAccessor;
			this.imageHelper = imageHelper;
			_user = httpContextAccessor.HttpContext.User;
		}

        // GÖNDERİ OLUŞTURMA
		public async Task CreateArticleAsync(ArticleAddDto articleAddDto)
		{
			var userId = _user.GetLoggedInUserId();
			var userEmail = _user.GetLoggedInEmail();

			var imageUpload = await imageHelper.Upload(articleAddDto.Title, articleAddDto.Photo, ImageType.Post);
			Image image = new(imageUpload.FullName, articleAddDto.Photo.ContentType, userEmail);
			await unitofWork.GetRepository<Image>().AddAsync(image);

			var article = new Article(articleAddDto.Title, articleAddDto.Content, userId, articleAddDto.CategoryId, image.Id, userEmail, articleAddDto.IsSlider, articleAddDto.IsEditorChoosed, articleAddDto.MiniDescription, articleAddDto.Slug);

			await unitofWork.GetRepository<Article>().AddAsync(article);
			await unitofWork.SaveAsync();
		}


		public async Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync()
		{
			var articles = await unitofWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted, x => x.Category, x => x.Image);
			var map = mapper.Map<List<ArticleDto>>(articles);
			return map;
		}

        // GÖNDERİ LİSTELEME
        public async Task<ArticleDto> GetArticleBySlugWithCategoryNonDeletedAsync(string slug)
        {
            var article = await unitofWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Slug == slug, x => x.Category, i => i.Image, u => u.User);
            if (article == null)
            {
                return null;
            }
            var map = mapper.Map<ArticleDto>(article);
            return map;
        }
        
        // GÖNDERİ SİLME ( VERİTABANINDAN SİLMEZ  )
        public async Task<string> SafeDeleteArticleAsync(Guid articleId)
		{
			var userEmail = _user.GetLoggedInEmail();
			var article = await unitofWork.GetRepository<Article>().GetByGuidAsync(articleId);

			article.IsDeleted = true;
			article.DeletedDate = DateTime.Now;
			article.DeletedBy = userEmail;

			await unitofWork.GetRepository<Article>().UpdateAsync(article);
			await unitofWork.SaveAsync();

			return article.Title;
		}
        public async Task<List<ArticleDto>> GetAllArticlesWithCategoryDeletedAsync()
        {
            var articles = await unitofWork.GetRepository<Article>().GetAllAsync(x => x.IsDeleted && x.CreatedDate >= DateTime.Now.AddDays(-30));
            var map = mapper.Map<List<ArticleDto>>(articles);

            return map;
        }

        public async Task<ArticleListDto> GetAllByPagingAsync(string categorySlug, int currentPage = 1, int pageSize = 10, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;

            List<CategoryDto> categories = new List<CategoryDto>();

            var articles = string.IsNullOrEmpty(categorySlug)
                ? await unitofWork.GetRepository<Article>().GetAllAsync(a => !a.IsDeleted, a => a.Category, i => i.Image, u => u.User)
                : await unitofWork.GetRepository<Article>().GetAllAsync(a => a.Category.Slug == categorySlug && !a.IsDeleted, a => a.Category, i => i.Image, u => u.User);

            string categoryName = string.IsNullOrEmpty(categorySlug) ? "Tüm Kategoriler" : articles.FirstOrDefault()?.Category?.Name;

            var sortedArticles = isAscending
                ? articles.OrderBy(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : articles.OrderByDescending(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            if (string.IsNullOrEmpty(categorySlug))
            {
                var allCategories = await unitofWork.GetRepository<Category>().GetAllAsync();
                categories = allCategories.Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToList();
            }

            return new ArticleListDto
            {
                Articles = sortedArticles,
                CategorySlug = string.IsNullOrEmpty(categorySlug) ? null : categorySlug,
                CategoryName = categoryName,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = articles.Count,
                IsAscending = isAscending,
                Categories = categories
            };
        }

        public async Task<ArticleListDto> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
		{
			pageSize = pageSize > 20 ? 20 : pageSize;
			var articles = await unitofWork.GetRepository<Article>().GetAllAsync(
				a => !a.IsDeleted && (a.Title.Contains(keyword) || a.Content.Contains(keyword) || a.Category.Name.Contains(keyword) || a.MiniDescription.Contains(keyword)),
			a => a.Category, i => i.Image, u => u.User);

			var sortedArticles = isAscending
				? articles.OrderBy(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
				: articles.OrderByDescending(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
			return new ArticleListDto
			{
				Articles = sortedArticles,
				CurrentPage = currentPage, 
				PageSize = pageSize,
				TotalCount = articles.Count,
				IsAscending = isAscending
			};
		}
		public async Task<List<ArticleDto>> GetRandomPostsForCategory(Guid categoryId, int count)
		{
			var articles = await unitofWork.GetRepository<Article>().GetAllAsync(
				a => a.CategoryId == categoryId && !a.IsDeleted,
				a => a.Category, i => i.Image, u => u.User);

			var random = new Random();
			var randomArticles = articles.OrderBy(x => random.Next()).Take(count).ToList();

			return mapper.Map<List<ArticleDto>>(randomArticles);
		}
       
        public async Task<List<ArticleDto>> GetLatestArticles(int count)
        {
            var articles = await unitofWork.GetRepository<Article>().GetAllAsync(
                a => !a.IsDeleted,
                a => a.Category,
                i => i.Image,
                u => u.User);

            var latestSharedArticles = articles.OrderByDescending(a => a.CreatedDate).Take(count).ToList();

            return mapper.Map<List<ArticleDto>>(latestSharedArticles);
        }
        public async Task<List<ArticleDto>> GetSliderArticles(int count)
        {
            var sliderArticles = await unitofWork.GetRepository<Article>().GetAllAsync(
                a => a.IsSlider && !a.IsDeleted,
                a => a.Category, i => i.Image, u => u.User);

            return mapper.Map<List<ArticleDto>>(sliderArticles.Take(count).ToList());
        }
        public async Task<List<ArticleDto>> GetEditorChoosedArticles(int count)
        {
            var editorArticles = await unitofWork.GetRepository<Article>().GetAllAsync(
                a => a.IsEditorChoosed && !a.IsDeleted,
                a => a.Category, i => i.Image, u => u.User);

            return mapper.Map<List<ArticleDto>>(editorArticles.Take(count).ToList());
        }
        public async Task<PaginatedList<ArticleDto>> GetPaginatedArticlesAsync(int page, int pageSize)
        {
            var allArticles = await GetAllArticlesWithCategoryNonDeletedAsync();

            var totalCount = allArticles.Count;
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            var paginatedArticles = allArticles.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return new PaginatedList<ArticleDto>(paginatedArticles, page, totalPages, totalCount, pageSize);
        }
        public async Task<string> UndoDeleteArticleAsync(Guid articleId)
        {
            var article = await unitofWork.GetRepository<Article>().GetByGuidAsync(articleId);

            article.IsDeleted = false;
            article.DeletedDate = null;
            article.DeletedBy = null;

            await unitofWork.GetRepository<Article>().UpdateAsync(article);
            await unitofWork.SaveAsync();

            return article.Title;
        }
    }
}