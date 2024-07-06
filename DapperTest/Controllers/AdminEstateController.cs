using Microsoft.AspNetCore.Mvc;

namespace DapperTest.Controllers
{
    public class AdminEstateController : Controller
    {
        public IActionResult EstateList()
        {
            return View();
        }
    }
}
