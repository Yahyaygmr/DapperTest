using Dapper;
using DapperTest.Context;
using DapperTest.Dtos.CategoryDtos;
using DapperTest.Services.Abstracts.Category;

namespace DapperTest.Services.Concretes.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly DapperContext _context;

        public CategoryService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto dto)
        {
            string query = "Insert Into TblCategory (CategoryName) values (@categoryName)";

            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", dto.CategoryName);

            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            string query = "Delete From TblCategory Where CategoryId=@categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select * From TblCategory";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultCategoryDto>(query);
            return values.ToList();
        }

        public async Task<GetByIdCategoryDto> GetCategoryAsync(int id)
        {
            string query = "Select * From TblCategory Where CategoryId=@categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", id);
            var connection = _context.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(query);
            return values;
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto dto)
        {
            string query = "Update TblCategory Set CategoryName=@categoryName Where CategoryId=@categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", dto.CategoryName);
            parameters.Add("@categoryId", dto.CategoryId);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
