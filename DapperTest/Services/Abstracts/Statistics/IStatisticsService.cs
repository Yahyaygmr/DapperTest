using DapperTest.Dtos.StatisticDtos;

namespace DapperTest.Services.Abstracts.Statistics
{
    public interface IStatisticsService
    {
        Task<StatisticsDto> GetStatisticsAsync();
    }
}
