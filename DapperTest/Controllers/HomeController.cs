using Microsoft.AspNetCore.Mvc;

namespace DapperTest.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
