using HuzlabBlog.Entities.DTOs.Articles;
using HuzlabBlog.Service.Helpers.Pagination;

namespace HuzlabBlog.Service.Services.Abstractions
{
    public interface IArticleService
    {
        Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync();
        Task<List<ArticleDto>> GetAllArticlesWithCategoryDeletedAsync(); 
        Task<ArticleDto> GetArticleBySlugWithCategoryNonDeletedAsync(string slug);
        Task CreateArticleAsync(ArticleAddDto articleAddDto);
        Task<string> SafeDeleteArticleAsync(Guid articleId);
        Task<ArticleListDto> GetAllByPagingAsync(string categorySlug, int currentPage = 1, int pageSize = 10, bool isAscending = false);
        Task<ArticleListDto> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3,
            bool isAscending = false);
        Task<List<ArticleDto>> GetRandomPostsForCategory(Guid categoryId, int count);
        Task<List<ArticleDto>> GetLatestArticles(int count);
        Task<List<ArticleDto>> GetSliderArticles(int count);
        Task<List<ArticleDto>> GetEditorChoosedArticles(int count);
        Task<PaginatedList<ArticleDto>> GetPaginatedArticlesAsync(int page, int pageSize);
        Task<string> UndoDeleteArticleAsync(Guid articleId);
    }
}
