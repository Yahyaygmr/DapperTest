using DapperTest.Dtos.LocationDtos;
using DapperTest.Services.Abstracts.Location;
using Microsoft.AspNetCore.Mvc;

namespace DapperTest.Controllers
{
    public class AdminLocationController : Controller
    {
        private readonly ILocationService _locationService;

        public AdminLocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public async Task<IActionResult> LocationList()
        {
            var values = await _locationService.GetAllLocationAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateLocation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationDto dto)
        {
            await _locationService.CreateLocationAsync(dto);
            return RedirectToAction("LocationList");
        }
        public async Task<IActionResult> DeleteLocation(int id)
        {
            await _locationService.DeleteLocationAsync(id);
            return RedirectToAction("LocationList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateLocation(int id)
        {
            var values = await _locationService.GetLocationAsync(id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateLocation(UpdateLocationDto dto)
        {
            await _locationService.UpdateLocationAsync(dto);
            return RedirectToAction("LocationList");
        }
    }
}
