using Microsoft.AspNetCore.Mvc;

namespace DapperTest.ViewComponents.HomeViewComponents
{
    public class HomeSliderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
