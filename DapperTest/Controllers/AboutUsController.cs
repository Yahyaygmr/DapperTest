using Microsoft.AspNetCore.Mvc;

namespace DapperTest.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
