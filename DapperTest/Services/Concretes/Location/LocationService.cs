using Dapper;
using DapperTest.Context;
using DapperTest.Dtos.LocationDtos;
using DapperTest.Services.Abstracts.Location;

namespace DapperTest.Services.Concretes.Location
{
    public class LocationService : ILocationService
    {
        private readonly DapperContext _context;

        public LocationService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateLocationAsync(CreateLocationDto dto)
        {
            string query = "Insert Into TblLocation (LocationName) values (@locationName)";

            var parameters = new DynamicParameters();
            parameters.Add("@locationName", dto.LocationName);

            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteLocationAsync(int id)
        {
            string query = "Delete From TblLocation Where LocationId=@locationId";
            var parameters = new DynamicParameters();
            parameters.Add("@locationId", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultLocationDto>> GetAllLocationAsync()
        {
            string query = "Select * From TblLocation";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultLocationDto>(query);
            return values.ToList();
        }

        public async Task<GetByIdLocationDto> GetLocationAsync(int id)
        {
            string query = "Select * From TblLocation Where LocationId=@locationId";
            var parameters = new DynamicParameters();
            parameters.Add("@locationId", id);
            var connection = _context.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdLocationDto>(query, parameters);
            return values;
        }

        public async Task UpdateLocationAsync(UpdateLocationDto dto)
        {
            string query = "Update TblLocation Set LocationName=@locationName Where LocationId=@locationId";
            var parameters = new DynamicParameters();
            parameters.Add("@locationName", dto.LocationName);
            parameters.Add("@locationId", dto.LocationId);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
