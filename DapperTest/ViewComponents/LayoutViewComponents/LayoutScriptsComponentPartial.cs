using Microsoft.AspNetCore.Mvc;

namespace DapperTest.ViewComponents.LayoutViewComponents
{
	public class LayoutScriptsComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
