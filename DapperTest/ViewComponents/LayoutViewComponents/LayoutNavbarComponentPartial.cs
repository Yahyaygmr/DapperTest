using Microsoft.AspNetCore.Mvc;

namespace DapperTest.ViewComponents.LayoutViewComponents
{
	public class LayoutNavbarComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
