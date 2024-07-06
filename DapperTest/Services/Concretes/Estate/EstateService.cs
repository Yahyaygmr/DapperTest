using Dapper;
using DapperTest.Context;
using DapperTest.Dtos.EstateDtos;
using DapperTest.Dtos.ImageDtos;
using DapperTest.Services.Abstracts.Estate;

namespace DapperTest.Services.Concretes.Estate
{

    public class EstateService : IEstateService
    {
        private readonly DapperContext _dapperContext;

        public EstateService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateEstateAsync(CreateEstateDto dto)
        {
            var query = "Insert Into TblEstate (EstateName,VideoUrl,Adress,Description,ForRent,ForSale,BedroomCount,BathroomCount,Price,AreaSize,IsFeatured,BuildAge,CategoryId,LocationId) values (@estateName,@videoUrl,@adress,@description,@forRent,@forSale,@bedroomCount,@bathroomCount,@price,@areaSize,@isFeatured,@buildAge,@categoryId,@locationId); SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("@estateName", dto.EstateName);
            parameters.Add("@videoUrl", dto.VideoUrl);
            parameters.Add("@adress", dto.Adress);
            parameters.Add("@description", dto.Description);
            parameters.Add("@forRent", dto.ForRent);
            parameters.Add("@forSale", dto.ForSale);
            parameters.Add("@bedroomCount", dto.BedroomCount);
            parameters.Add("@bathroomCount", dto.BathroomCount);
            parameters.Add("@price", dto.Price);
            parameters.Add("@areaSize", dto.AreaSize);
            parameters.Add("@isFeatured", dto.IsFeatured);
            parameters.Add("@buildAge", dto.BuildAge);
            parameters.Add("@categoryId", dto.CategoryId);
            parameters.Add("@locationId", dto.LocationId);

            using (var connection = _dapperContext.CreateConnection())
            {
                var estateId = await connection.QuerySingleAsync<int>(query, parameters);
                if (dto.Images != null && dto.Images.Any())
                {
                    foreach (var image in dto.Images)
                    {
                        var command = "Insert Into TblImage (ImageUrl,EstateId) values (@imageUrl,@estateId)";
                        var parameters2 = new DynamicParameters();
                        parameters2.Add("@imageUrl", image);
                        parameters2.Add("@estateId", estateId);
                        await connection.ExecuteAsync(command, parameters2);

                    }
                }
            }

        }
        public Task DeleteEstateAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultEstateDto>> GetAllEstateAsync()
        {
            var query = "Select * From TblEstate";
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = (await connection.QueryAsync<ResultEstateDto>(query)).ToList();

                foreach (var value in values)
                {
                    var query1 = "Select * From TblImage Where EstateId=@estateId";
                    var imageList = (await connection.QueryAsync<ResultImageDto>(query1, new { estateId = value.EstateId })).ToList();
                    value.Images = imageList;
                }

                return values;
            }
        }


        public Task<GetByIdEstateDto> GetEstateAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEstateAsync(UpdateEstateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
