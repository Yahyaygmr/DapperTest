using Microsoft.AspNetCore.Mvc;

namespace DapperTest.ViewComponents.DetailViewComponents
{
    public class DetailCategoriesComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
