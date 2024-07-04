using Microsoft.AspNetCore.Mvc;

namespace DapperTest.ViewComponents.HomeViewComponents
{
    public class HomeNewsletterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
