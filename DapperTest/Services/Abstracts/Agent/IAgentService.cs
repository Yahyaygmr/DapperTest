using DapperTest.Dtos.AgentDtos;

namespace DapperTest.Services.Abstracts.Agent
{
    public interface IAgentService
    {
        Task<List<ResultAgentDto>> GetAllAgentAsync();
        Task CreateAgentAsync(CreateAgentDto dto);
        Task DeleteAgentAsync(int id);
        Task UpdateAgentAsync(UpdateAgentDto dto);
        Task<GetByIdAgentDto> GetAgentAsync(int id);
    }
}
