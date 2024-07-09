using DapperTest.Dtos.TagCloud;

namespace DapperTest.Services.Abstracts.TagCloud
{
    public interface ITagCloudService
    {
        Task<List<ResultTagCloudDto>> GetAllTagsByEstateId(int id);
    }
}
