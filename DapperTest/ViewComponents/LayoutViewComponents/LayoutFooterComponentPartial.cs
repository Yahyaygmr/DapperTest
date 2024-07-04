using Microsoft.AspNetCore.Mvc;

namespace DapperTest.ViewComponents.LayoutViewComponents
{
	public class LayoutFooterComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
