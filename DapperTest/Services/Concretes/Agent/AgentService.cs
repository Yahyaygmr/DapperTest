using Dapper;
using DapperTest.Context;
using DapperTest.Dtos.AgentDtos;
using DapperTest.Dtos.TagCloud;
using DapperTest.Services.Abstracts.Agent;

namespace DapperTest.Services.Concretes.Agent
{
    public class AgentService : IAgentService
    {
        private readonly DapperContext _context;

        public AgentService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateAgentAsync(CreateAgentDto dto)
        {
            string query = "Insert Into TblAgent (AgentFullName,ImageUrl,Title) values (@agentFullName,@imageUrl,@title)";

            var parameters = new DynamicParameters();
            parameters.Add("@agentFullName", dto.AgentFullName);
            parameters.Add("@imageUrl", dto.ImageUrl);
            parameters.Add("@title", dto.Title);

            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAgentAsync(int id)
        {
            string query = "Delete From TblAgent Where AgentId=@agentId";
            var parameters = new DynamicParameters();
            parameters.Add("@agentId", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultAgentDto>> GetAllAgentAsync()
        {
            string query = "Select * From TblAgent";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultAgentDto>(query);
            return values.ToList();
        }

        public async Task<GetByIdAgentDto> GetAgentAsync(int id)
        {
            string query = "Select * From TblAgent Where AgentId=@agentId";
            var parameters = new DynamicParameters();
            parameters.Add("@agentId", id);
            var connection = _context.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdAgentDto>(query, parameters);
            return values;
        }

        public async Task UpdateAgentAsync(UpdateAgentDto dto)
        {
            string query = "Update TblAgent Set AgentFullName=@agentFullName, ImageUrl=@imageUrl, Title=@title Where AgentId=@agentId";
            var parameters = new DynamicParameters();
            parameters.Add("@agentFullName", dto.AgentFullName);
            parameters.Add("@imageUrl", dto.ImageUrl);
            parameters.Add("@title", dto.Title);
            parameters.Add("@agentId", dto.AgentId);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
