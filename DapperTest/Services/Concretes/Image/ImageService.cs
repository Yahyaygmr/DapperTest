using Dapper;
using DapperTest.Context;
using DapperTest.Dtos.ImageDtos;
using DapperTest.Services.Abstracts.Image;

namespace DapperTest.Services.Concretes.Image
{
    public class ImageService : IImageService
    {
        private readonly DapperContext _dapperContext;

        public ImageService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<List<ResultImageDto>> GetImagesByEstateId(int id)
        {
            var query = "Select * From TblImage Where EstateId=@estateId";

            var parameter = new DynamicParameters();
            parameter.Add("@estateId", id);

            var connection = _dapperContext.CreateConnection();
            var values = await connection.QueryAsync<ResultImageDto>(query, parameter);

            return values.ToList();
        }
    }
}
