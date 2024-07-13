using DapperTest.Services.Abstracts.Agent;
using Microsoft.AspNetCore.Mvc;

namespace DapperTest.Controllers
{
	public class AgentController : Controller
	{
		private readonly IAgentService agentService;

		public AgentController(IAgentService agentService)
		{
			this.agentService = agentService;
		}

		public async Task<IActionResult> Index()
		{
			var values = await agentService.GetAllAgentAsync();
			return View(values);
		}
	}
}
