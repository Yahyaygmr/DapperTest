using DapperTest.Dtos.SliderDtos;

namespace DapperTest.Services.Abstracts.Slider
{
    public interface ISliderService
    {
        Task<List<ResultSliderDto>> GetAllSliderAsync();
        Task CreateSliderAsync(CreateSliderDto dto);
        Task DeleteSliderAsync(int id);
        Task UpdateSliderAsync(UpdateSliderDto dto);
        Task<GetByIdSliderDto> GetSliderAsync(int id);
    }
}
