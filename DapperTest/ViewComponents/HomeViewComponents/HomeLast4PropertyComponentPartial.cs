using DapperTest.Services.Abstracts.Estate;
using Microsoft.AspNetCore.Mvc;

namespace DapperTest.ViewComponents.HomeViewComponents
{
    public class HomeLast4PropertyComponentPartial : ViewComponent
    {
        private readonly IEstateService _estateService;

        public HomeLast4PropertyComponentPartial(IEstateService estateService)
        {
            _estateService = estateService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _estateService.GetLast4EstateAsync();
            return View(values);
        }
    }
}
