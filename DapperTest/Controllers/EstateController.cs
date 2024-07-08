using DapperTest.Services.Abstracts.Estate;
using Microsoft.AspNetCore.Mvc;

namespace DapperTest.Controllers
{
    public class EstateController : Controller
    {
        private readonly IEstateService _estateService;

        public EstateController(IEstateService estateService)
        {
            _estateService = estateService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _estateService.GetAllEstateWithCategoryAndLocationAsync();
            return View(values);
        }
        public IActionResult Detail(int id)
        {
            ViewBag.id = id;
            return View();
        }
    }
}
