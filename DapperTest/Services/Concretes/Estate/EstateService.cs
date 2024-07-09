using Dapper;
using DapperTest.Context;
using DapperTest.Dtos.EstateDtos;
using DapperTest.Dtos.ImageDtos;
using DapperTest.Dtos.TagCloud;
using DapperTest.Services.Abstracts.Estate;
using Newtonsoft.Json.Linq;

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
        public async Task DeleteEstateAsync(int id)
        {
            var query1 = "Delete From TblImage Where EstateId=@estateId";
            var parameters1 = new DynamicParameters();
            parameters1.Add("@estateId", id);

            var query2 = "Delete From TblEstate Where EstateId=@estateId";
            var parameters2 = new DynamicParameters();
            parameters2.Add("@estateId", id);

            var connection = _dapperContext.CreateConnection();
            await connection.ExecuteAsync(query1, parameters1);
            await connection.ExecuteAsync(query2, parameters2);

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

        public async Task<List<ResultEstateByIsFeatureDto>> GetAllEstateByIsFeatureAsync()
        {
            var query = "SELECT dbo.TblEstate.*, dbo.TblLocation.LocationName, dbo.TblCategory.CategoryName FROM dbo.TblCategory INNER JOIN dbo.TblEstate ON dbo.TblCategory.CategoryId = dbo.TblEstate.CategoryId INNER JOIN dbo.TblLocation ON dbo.TblEstate.LocationId = dbo.TblLocation.LocationId Where dbo.TblEstate.IsFeatured=1";
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = (await connection.QueryAsync<ResultEstateByIsFeatureDto>(query)).ToList();

                foreach (var value in values)
                {
                    var query1 = "Select * From TblImage Where EstateId=@estateId";
                    var image = (await connection.QueryFirstOrDefaultAsync<ResultImageDto>(query1, new { estateId = value.EstateId }));
                    value.ImageUrl = image.ImageUrl;
                }
                return values;
            }
        }

        public async Task<ResultEstateForDetailDto> GetEstateForDetailAsync(int id)
        {
            var query = @"
        SELECT dbo.TblCategory.CategoryName, dbo.TblEstate.*, dbo.TblLocation.LocationName 
        FROM dbo.TblCategory 
        INNER JOIN dbo.TblEstate ON dbo.TblCategory.CategoryId = dbo.TblEstate.CategoryId 
        INNER JOIN dbo.TblLocation ON dbo.TblEstate.LocationId = dbo.TblLocation.LocationId 
        WHERE dbo.TblEstate.EstateId = @estateId";

            using (var connection = _dapperContext.CreateConnection())
            {
                var estate = await connection.QueryFirstOrDefaultAsync<ResultEstateForDetailDto>(query, new { estateId = id });

                if (estate != null)
                {
                    var query1 = "SELECT * FROM TblImage WHERE EstateId = @estateId";
                    var images = (await connection.QueryAsync<ResultImageDto>(query1, new { estateId = id })).ToList();

                    // Assuming you want to set the ImageUrl to the first image's URL
                    if (images.Any())
                    {
                        estate.ImageUrl = images.First().ImageUrl;
                    }
                    //string query2 = "Select * From TblTagCloud Where EstateId = @estateId";
                    //var tags = (await connection.QueryAsync<ResultTagCloudDto>(query2, new { estateId = id })).ToList();
                    //estate.TagClouds = tags;
                    return estate;
                }

                return null;
            }
        }


        public async Task<List<ResultEstateWithCategoryAndLocationDto>> GetAllEstateWithCategoryAndLocationAsync()
        {
            var query = "SELECT dbo.TblEstate.*, dbo.TblLocation.LocationName, dbo.TblCategory.CategoryName FROM dbo.TblCategory INNER JOIN dbo.TblEstate ON dbo.TblCategory.CategoryId = dbo.TblEstate.CategoryId INNER JOIN dbo.TblLocation ON dbo.TblEstate.LocationId = dbo.TblLocation.LocationId";
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = (await connection.QueryAsync<ResultEstateWithCategoryAndLocationDto>(query)).ToList();

                foreach (var value in values)
                {
                    var query1 = "Select * From TblImage Where EstateId=@estateId";
                    var image = (await connection.QueryFirstOrDefaultAsync<ResultImageDto>(query1, new { estateId = value.EstateId }));
                    value.ImageUrl = image.ImageUrl;
                }
                return values;
            }
        }

        public async Task<GetByIdEstateDto> GetEstateAsync(int id)
        {
            string query = "Select * From TblEstate Where EstateId=@estateId";
            var parameter = new DynamicParameters();
            parameter.Add("@estateId", id);
            var connection = _dapperContext.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdEstateDto>(query, parameter);

            var query1 = "Select * From TblImage Where EstateId=@estateId";
            var imageList = (await connection.QueryAsync<ResultImageDto>(query1, new { estateId = id })).ToList();

            values.Images = imageList;
            return values;

        }

        public async Task<List<ResultEstateByIsFeatureDto>> GetLast4EstateAsync()
        {
            var query = "SELECT dbo.TblEstate.*, dbo.TblLocation.LocationName, dbo.TblCategory.CategoryName FROM dbo.TblCategory INNER JOIN dbo.TblEstate ON dbo.TblCategory.CategoryId = dbo.TblEstate.CategoryId INNER JOIN dbo.TblLocation ON dbo.TblEstate.LocationId = dbo.TblLocation.LocationId ORDER BY dbo.TblEstate.EstateId DESC OFFSET 0 ROWS FETCH NEXT 4 ROWS ONLY;";
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = (await connection.QueryAsync<ResultEstateByIsFeatureDto>(query)).ToList();

                foreach (var value in values)
                {
                    var query1 = "Select * From TblImage Where EstateId=@estateId";
                    var image = (await connection.QueryFirstOrDefaultAsync<ResultImageDto>(query1, new { estateId = value.EstateId }));
                    value.ImageUrl = image.ImageUrl;
                }
                return values;
            }
        }

        public async Task UpdateEstateAsync(UpdateEstateDto dto)
        {
            var query = @"Update TblEstate 
                  Set EstateName = @estateName, 
                      VideoUrl = @videoUrl, 
                      Adress = @adress, 
                      Description = @description, 
                      ForRent = @forRent, 
                      ForSale = @forSale, 
                      BedroomCount = @bedroomCount, 
                      BathroomCount = @bathroomCount, 
                      Price = @price, 
                      AreaSize = @areaSize, 
                      IsFeatured = @isFeatured, 
                      BuildAge = @buildAge, 
                      CategoryId = @categoryId, 
                      LocationId = @locationId 
                  Where EstateId = @estateId";

            var parameters = new DynamicParameters();
            parameters.Add("@estateId", dto.EstateId);
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
                await connection.ExecuteAsync(query, parameters);

                // Eski resimleri silmek ve yeni resimleri eklemek için
                if (dto.Images != null && dto.Images.Any())
                {
                    var deleteCommand = "Delete From TblImage Where EstateId = @estateId";
                    await connection.ExecuteAsync(deleteCommand, new { estateId = dto.EstateId });

                    foreach (var image in dto.Images.Where(x => !string.IsNullOrWhiteSpace(x)))
                    {
                        var insertCommand = "Insert Into TblImage (ImageUrl, EstateId) values (@imageUrl, @estateId)";
                        var imageParameters = new DynamicParameters();
                        imageParameters.Add("@imageUrl", image);
                        imageParameters.Add("@estateId", dto.EstateId);
                        await connection.ExecuteAsync(insertCommand, imageParameters);
                    }
                }
            }
        }


    }
}
