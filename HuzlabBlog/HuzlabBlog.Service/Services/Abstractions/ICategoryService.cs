using HuzlabBlog.Entities.DTOs.Categories;
using HuzlabBlog.Entities.Entities;

namespace HuzlabBlog.Service.Services.Abstractions
{
    public interface  ICategoryService
	{
        Task<List<CategoryDto>> GetAllCategoriesNonDeleted();
        Task<List<CategoryDto>> GetAllCategoriesNonDeletedIndex();
        Task<CategoryDto> GetRandomCategory();
        Task CreateCategoryAsync(CategoryAddDto categoryAddDto);
    }
}
