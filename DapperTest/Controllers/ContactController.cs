using Microsoft.AspNetCore.Mvc;

namespace DapperTest.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
