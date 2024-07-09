using DapperTest.Dtos.CategoryDtos;

namespace DapperTest.Services.Abstracts.Category
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task<List<ResultCategoryWithCount>> GetAllCategoryWithCountAsync();
        Task CreateCategoryAsync(CreateCategoryDto dto);
        Task DeleteCategoryAsync(int id);
        Task UpdateCategoryAsync(UpdateCategoryDto dto);
        Task<GetByIdCategoryDto> GetCategoryAsync(int id);
    }
}
