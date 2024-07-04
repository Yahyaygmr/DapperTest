using Microsoft.AspNetCore.Mvc;

namespace DapperTest.Controllers
{
    public class EstateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail()
        {
            return View();
        }
    }
}
