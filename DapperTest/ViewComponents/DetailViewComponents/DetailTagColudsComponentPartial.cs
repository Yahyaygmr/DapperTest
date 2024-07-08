using Microsoft.AspNetCore.Mvc;

namespace DapperTest.ViewComponents.DetailViewComponents
{
    public class DetailTagColudsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
