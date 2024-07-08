using DapperTest.Services.Abstracts.Estate;
using Microsoft.AspNetCore.Mvc;

namespace DapperTest.ViewComponents.DetailViewComponents
{
    public class DetailEstateDetailComponentPartial : ViewComponent
    {
        private readonly IEstateService _estateService;

        public DetailEstateDetailComponentPartial(IEstateService estateService)
        {
            _estateService = estateService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var values = await _estateService.GetEstateForDetailAsync(id);
            return View(values);
        }
    }
}
