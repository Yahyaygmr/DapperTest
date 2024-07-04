using Microsoft.AspNetCore.Mvc;

namespace DapperTest.ViewComponents.HomeViewComponents
{
    public class HomeStatisticsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
