using DapperTest.Dtos.SliderDtos;
using DapperTest.Services.Abstracts.Slider;
using Microsoft.AspNetCore.Mvc;

namespace DapperTest.Controllers
{
    public class AdminSliderController : Controller
    {
        private readonly ISliderService _sliderService;

        public AdminSliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public async Task<IActionResult> SliderList()
        {
            var values = await _sliderService.GetAllSliderAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateSlider()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSlider(CreateSliderDto dto)
        {
            await _sliderService.CreateSliderAsync(dto);
            return RedirectToAction("SliderList");
        }
        public async Task<IActionResult> DeleteSlider(int id)
        {
            await _sliderService.DeleteSliderAsync(id);
            return RedirectToAction("SliderList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateSlider(int id)
        {
            var values = await _sliderService.GetSliderAsync(id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSlider(UpdateSliderDto dto)
        {
            await _sliderService.UpdateSliderAsync(dto);
            return RedirectToAction("SliderList");
        }
    }
}
