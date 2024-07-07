using DapperTest.Dtos.EstateDtos;
using DapperTest.Services.Abstracts.Category;
using DapperTest.Services.Abstracts.Estate;
using DapperTest.Services.Abstracts.Location;
using Microsoft.AspNetCore.Mvc;

namespace DapperTest.Controllers
{
    public class AdminEstateController : Controller
    {
        private readonly IEstateService _estateService;
        private readonly ICategoryService _categoryService;
        private readonly ILocationService _locationService;

        public AdminEstateController(IEstateService estateService, ICategoryService categoryService, ILocationService locationService)
        {
            _estateService = estateService;
            _categoryService = categoryService;
            _locationService = locationService;
        }

        public async Task<IActionResult> EstateList()
        {
            var estates = await _estateService.GetAllEstateAsync();
            return View(estates);
        }
        [HttpGet]
        public async Task<IActionResult> CreateEstate()
        {
            ViewBag.categories = await _categoryService.GetAllCategoryAsync();
            ViewBag.locations = await _locationService.GetAllLocationAsync();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEstate(CreateEstateDto dto)
        {
            if (ModelState.IsValid)
            {
                await _estateService.CreateEstateAsync(dto);
                return RedirectToAction("EstateList");
            }
            return View();
        }
        public async Task<IActionResult> DeleteEstate(int id)
        {
            await _estateService.DeleteEstateAsync(id);
            return RedirectToAction("EstateList");
        }
        [HttpGet]
        public async Task<ActionResult> UpdateEstate(int id)
        {
            ViewBag.categories = await _categoryService.GetAllCategoryAsync();
            ViewBag.locations = await _locationService.GetAllLocationAsync();
            var values = await _estateService.GetEstateAsync(id);
            return View(values);
        }
        [HttpPost]
        public async Task<ActionResult> UpdateEstate(UpdateEstateDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.categories = await _categoryService.GetAllCategoryAsync();
                ViewBag.locations = await _locationService.GetAllLocationAsync();
                return View(dto);
            }
            await _estateService.UpdateEstateAsync(dto);
            return RedirectToAction("EstateList");
        }
    }
}
