using DapperTest.Dtos.CategoryDtos;
using DapperTest.Services.Abstracts.Category;

namespace DapperTest.Services.Concretes.Category
{
    public class CategoryService : ICategoryService
    {
        public Task CreateCategoryAsync(CreateCategoryDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetByIdCategoryDto> GetCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategoryAsync(UpdateCategoryDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
