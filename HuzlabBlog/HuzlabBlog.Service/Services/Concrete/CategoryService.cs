using AutoMapper;
using HuzlabBlog.Data.UnitOfWorks;
using HuzlabBlog.Entities.DTOs.Categories;
using HuzlabBlog.Entities.Entities;
using HuzlabBlog.Service.Extensions;
using HuzlabBlog.Service.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace HuzlabBlog.Service.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }
        public async Task<List<CategoryDto>> GetAllCategoriesNonDeleted()
        {

            var categories = await unitOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
            var map = mapper.Map<List<CategoryDto>>(categories);

            return map;
        }
        public async Task<List<CategoryDto>> GetAllCategoriesNonDeletedIndex()
        {
            var categories = await unitOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
            var map = mapper.Map<List<CategoryDto>>(categories);

            return map.Take(10).ToList();
        }
		public async Task CreateCategoryAsync(CategoryAddDto categoryAddDto)
		{
			var userEmail = _user.GetLoggedInEmail();

			string slug = categoryAddDto.Slug;

			if (string.IsNullOrEmpty(slug))
			{
				slug = GenerateSlug(categoryAddDto.Name);
			}

			Category category = new Category(categoryAddDto.Name, userEmail, slug);

			await unitOfWork.GetRepository<Category>().AddAsync(category);
			await unitOfWork.SaveAsync();
		}
		private string GenerateSlug(string input)
        {
            string slug = RemoveTurkishCharacters(input);

            slug = slug.Replace(' ', '-');

            slug = RemoveSpecialCharacters(slug);

            slug = RemoveConsecutiveHyphens(slug);

            return slug.ToLower();
        }

        private string RemoveTurkishCharacters(string input)
        {
            string[] turkishChars = { "ğ", "ü", "ş", "ı", "i", "ö", "ç", "Ğ", "Ü", "Ş", "İ", "Ö", "Ç" };
            string[] englishChars = { "g", "u", "s", "i", "i", "o", "c", "G", "U", "S", "I", "O", "C" };

            for (int i = 0; i < turkishChars.Length; i++)
            {
                input = input.Replace(turkishChars[i], englishChars[i]);
            }

            return input;
        }

        private string RemoveSpecialCharacters(string input)
        {
            return Regex.Replace(input, @"[^a-zA-Z0-9\-]", "");
        }

        private string RemoveConsecutiveHyphens(string input)
        {
            return Regex.Replace(input, @"-+", "-");
        }

        public async Task<Category> GetCategoryByGuid(Guid id)
        {
            var category = await unitOfWork.GetRepository<Category>().GetByGuidAsync(id);
            return category;
        }
        public async Task<string> UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            var category = await unitOfWork.GetRepository<Category>().GetAsync(x => !x.IsDeleted && x.Id == categoryUpdateDto.Id);

            category.Name = categoryUpdateDto.Name;
            category.ModifiedBy = userEmail;
            category.ModifiedDate = DateTime.Now;


            await unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await unitOfWork.SaveAsync();


            return category.Name;
        }

        public async Task<string> SafeDeleteCategoryAsync(Guid categoryId)
        {
            var userEmail = _user.GetLoggedInEmail();
            var category = await unitOfWork.GetRepository<Category>().GetByGuidAsync(categoryId);

            category.IsDeleted = true;
            category.DeletedDate = DateTime.Now;
            category.DeletedBy = userEmail;

            await unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await unitOfWork.SaveAsync();

            return category.Name;
        }

        public async Task<List<CategoryDto>> GetAllCategoriesDeleted()
        {
            var categories = await unitOfWork.GetRepository<Category>().GetAllAsync(x => x.IsDeleted);
            var map = mapper.Map<List<CategoryDto>>(categories);

            return map;
        }

        public async Task<string> UndoDeleteCategoryAsync(Guid categoryId)
        {
            var category = await unitOfWork.GetRepository<Category>().GetByGuidAsync(categoryId);

            category.IsDeleted = false;
            category.DeletedDate = null;
            category.DeletedBy = null;

            await unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await unitOfWork.SaveAsync();

            return category.Name;
        }
        public async Task<CategoryDto> GetRandomCategory()
        {
            var categories = await unitOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
            var random = new Random();

            if (categories.Any())
            {
                int randomIndex = random.Next(0, categories.Count);
                return mapper.Map<CategoryDto>(categories[randomIndex]);
            }

            return null;
        }
    }
}
