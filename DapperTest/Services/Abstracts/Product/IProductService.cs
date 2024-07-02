using DapperTest.Dtos.ProductDtos;

namespace DapperTest.Services.Abstracts.Product
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
        Task CreateProductAsync(CreateProductDto dto);
        Task DeleteProductAsync(int id);
        Task UpdateProductAsync(UpdateProductDto dto);
        Task<GetByIdProductDto> GetProductAsync(int id);
        Task<int> GetProductCount();
    }
}
