using DapperTest.Dtos.AgentDtos;
using DapperTest.Services.Abstracts.Agent;
using Microsoft.AspNetCore.Mvc;

namespace DapperTest.Controllers
{
    public class AdminAgentController : Controller
    {
        private readonly IAgentService _agentService;

        public AdminAgentController(IAgentService AgentService)
        {
            _agentService = AgentService;
        }

        public async Task<IActionResult> AgentList()
        {
            var values = await _agentService.GetAllAgentAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateAgent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAgent(CreateAgentDto dto)
        {
            await _agentService.CreateAgentAsync(dto);
            return RedirectToAction("AgentList");
        }
        public async Task<IActionResult> DeleteAgent(int id)
        {
            await _agentService.DeleteAgentAsync(id);
            return RedirectToAction("AgentList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAgent(int id)
        {
            var values = await _agentService.GetAgentAsync(id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAgent(UpdateAgentDto dto)
        {
            await _agentService.UpdateAgentAsync(dto);
            return RedirectToAction("AgentList");
        }
    }
}
