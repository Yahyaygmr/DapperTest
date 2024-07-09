using DapperTest.Services.Abstracts.TagCloud;
using Microsoft.AspNetCore.Mvc;

namespace DapperTest.ViewComponents.DetailViewComponents
{
    public class DetailTagColudsComponentPartial : ViewComponent
    {
        private readonly ITagCloudService _tagCloudService;

        public DetailTagColudsComponentPartial(ITagCloudService tagCloudService)
        {
            _tagCloudService = tagCloudService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var values = await _tagCloudService.GetAllTagsByEstateId(id);
            return View(values);
        }
    }
}
