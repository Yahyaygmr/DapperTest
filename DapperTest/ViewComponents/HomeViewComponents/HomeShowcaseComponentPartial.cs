using DapperTest.Services.Abstracts.Estate;
using Microsoft.AspNetCore.Mvc;

namespace DapperTest.ViewComponents.HomeViewComponents
{
    public class HomeShowcaseComponentPartial : ViewComponent
    {
        private readonly IEstateService _estateService;

        public HomeShowcaseComponentPartial(IEstateService estateService)
        {
            _estateService = estateService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _estateService.GetAllEstateByIsFeatureAsync();
            return View(values);
        }
    }
}
