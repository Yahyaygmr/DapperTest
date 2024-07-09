using Dapper;
using DapperTest.Context;
using DapperTest.Dtos.TagCloud;
using DapperTest.Services.Abstracts.TagCloud;

namespace DapperTest.Services.Concretes.TagCloud
{
    public class TagCloudService : ITagCloudService
    {
        private readonly DapperContext _dapperContext;

        public TagCloudService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<List<ResultTagCloudDto>> GetAllTagsByEstateId(int id)
        {

            string query = "Select * From TblTagCloud Where EstateId = @estateId";
            using (var connection = _dapperContext.CreateConnection())
            {
                var tags = (await connection.QueryAsync<ResultTagCloudDto>(query, new { estateId = id })).ToList();
                return tags;
            }
        }
    }
}
