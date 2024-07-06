using DapperTest.Dtos.EstateDtos;

namespace DapperTest.Services.Abstracts.Estate
{
    public interface IEstateService
    {
        Task<List<ResultEstateDto>> GetAllEstateAsync();
        Task CreateEstateAsync(CreateEstateDto dto);
        Task DeleteEstateAsync(int id);
        Task UpdateEstateAsync(UpdateEstateDto dto);
        Task<GetByIdEstateDto> GetEstateAsync(int id);
    }
}
