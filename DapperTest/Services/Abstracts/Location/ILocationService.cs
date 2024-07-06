using DapperTest.Dtos.LocationDtos;

namespace DapperTest.Services.Abstracts.Location
{
    public interface ILocationService
    {
        Task<List<ResultLocationDto>> GetAllLocationAsync();
        Task CreateLocationAsync(CreateLocationDto dto);
        Task DeleteLocationAsync(int id);
        Task UpdateLocationAsync(UpdateLocationDto dto);
        Task<GetByIdLocationDto> GetLocationAsync(int id);
    }
}
