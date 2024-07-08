using DapperTest.Services.Abstracts.Image;
using Microsoft.AspNetCore.Mvc;

namespace DapperTest.ViewComponents.DetailViewComponents
{
    public class DetailImagesComponentPartial : ViewComponent
    {
        private readonly IImageService _imageService;

        public DetailImagesComponentPartial(IImageService imageService)
        {
            _imageService = imageService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var values = await _imageService.GetImagesByEstateId(id);
            return View(values);
        }
    }
}
