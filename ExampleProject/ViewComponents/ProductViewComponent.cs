using Microsoft.AspNetCore.Mvc;

namespace ExampleProject.ViewComponents
{
	public class ProductViewComponent: ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
