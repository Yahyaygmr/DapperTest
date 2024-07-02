using Dapper;
using DapperTest.Context;
using DapperTest.Dtos.ProductDtos;
using DapperTest.Services.Abstracts.Product;
using Microsoft.CodeAnalysis.CSharp;

namespace DapperTest.Services.Concretes.Product
{
    public class ProductService : IProductService
    {
        private readonly DapperContext _dapperContext;

        public ProductService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateProductAsync(CreateProductDto dto)
        {
            string query = "Insert Into TblProduct (ProductName,Price,Stock,CategoryId) values (@productName,@price,@stock,@categoryId)";
            var parameters = new DynamicParameters();
            parameters.Add("@productName", dto.ProductName);
            parameters.Add("@price", dto.Price);
            parameters.Add("@stock", dto.Stock);
            parameters.Add("@categoryId", dto.CategoryId);
            var connection = _dapperContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteProductAsync(int id)
        {
            string query = "Delete From TblProduct Where ProductId=@productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productId", id);
            var connection = _dapperContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "Select * From TblProduct";
            var connection = _dapperContext.CreateConnection();
            var values = await connection.QueryAsync<ResultProductDto>(query);
            return values.ToList();
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            string query = "Select ProductId,ProductName,Price,Stock,CategoryName From TblProduct Inner Join TblCategory On TblProduct.CategoryId=TblCategory.CategoryId";
            var connection = _dapperContext.CreateConnection();
            var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
            return values.ToList();
        }

        public async Task<GetByIdProductDto> GetProductAsync(int id)
        {
            string query = "Select * From TblProduct Where ProductId=@productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productId", id);
            var connection = _dapperContext.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdProductDto>(query, parameters);
            return values;
        }

        public async Task<int> GetProductCount()
        {
            string query = "Select Count(*) From TblProduct";
            var connection = _dapperContext.CreateConnection();
            int value = await connection.QueryFirstOrDefaultAsync<int>(query);
            return value;
        }

        public async Task UpdateProductAsync(UpdateProductDto dto)
        {
            string query = "Update TblProduct Set ProductName=@productName, Price=@price, Stock=@stock, CategoryId=@categoryId Where ProductId=@productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productName", dto.ProductName);
            parameters.Add("@price", dto.Price);
            parameters.Add("@stock", dto.Stock);
            parameters.Add("@categoryId", dto.CategoryId);
            parameters.Add("@productId", dto.ProductId);
            var connection = _dapperContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
