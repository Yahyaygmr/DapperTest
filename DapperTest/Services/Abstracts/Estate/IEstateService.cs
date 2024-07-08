using DapperTest.Dtos.EstateDtos;

namespace DapperTest.Services.Abstracts.Estate
{
    public interface IEstateService
    {
        Task<List<ResultEstateDto>> GetAllEstateAsync();
        Task<ResultEstateForDetailDto> GetEstateForDetailAsync(int id);
        Task<List<ResultEstateWithCategoryAndLocationDto>> GetAllEstateWithCategoryAndLocationAsync();
        Task<List<ResultEstateByIsFeatureDto>> GetAllEstateByIsFeatureAsync();
        Task<List<ResultEstateByIsFeatureDto>> GetLast4EstateAsync();
        Task CreateEstateAsync(CreateEstateDto dto);
        Task DeleteEstateAsync(int id);
        Task UpdateEstateAsync(UpdateEstateDto dto);
        Task<GetByIdEstateDto> GetEstateAsync(int id);
    }
}
