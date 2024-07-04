using Microsoft.AspNetCore.Mvc;

namespace DapperTest.ViewComponents.HomeViewComponents
{
    public class HomeShowcaseComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
