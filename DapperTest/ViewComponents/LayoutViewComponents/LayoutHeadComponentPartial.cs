using Microsoft.AspNetCore.Mvc;

namespace DapperTest.ViewComponents.LayoutViewComponents
{
    public class LayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
