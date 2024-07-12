using DapperTest.Services.Abstracts.Slider;
using Microsoft.AspNetCore.Mvc;

namespace DapperTest.ViewComponents.HomeViewComponents
{
    public class HomeSliderComponentPartial : ViewComponent
    {
        private readonly ISliderService _sliderService;

        public HomeSliderComponentPartial(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _sliderService.GetAllSliderAsync();
            return View(values);
        }
    }
}
