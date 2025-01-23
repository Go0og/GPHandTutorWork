using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
	public class HomeController : Controller
	{

		public IActionResult Index()
		{
			if (APIclient.Tutor == null)
			{
				return Redirect("~/Home/Enter");
			}
			return View();
		}



	}
}
