using Microsoft.AspNetCore.Mvc;

namespace DapperTest.ViewComponents.LayoutViewComponents
{
    public class LoyoutTopBarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
