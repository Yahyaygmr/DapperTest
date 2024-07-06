using Microsoft.AspNetCore.Mvc;

namespace DapperTest.Controllers
{
    public class AdminDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
