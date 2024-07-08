using DapperTest.Dtos.ImageDtos;

namespace DapperTest.Services.Abstracts.Image
{
    public interface IImageService
    {
        Task<List<ResultImageDto>> GetImagesByEstateId(int id);
    }
}
