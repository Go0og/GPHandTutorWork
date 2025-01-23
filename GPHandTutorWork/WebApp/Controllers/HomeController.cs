using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
	[ApiController]
	[Route("[controller]")]
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

		[HttpGet]
		public IActionResult Template()
		{
			if (APIclient.Tutor == null)
			{
				return Redirect("~/Home/Enter");
			}

			return View();
		}

		[HttpGet]
		public IActionResult TemplateCreate()
		{
			if (APIclient.Tutor == null)
			{
				return Redirect("~/Home/Enter");
			}

			return View(APIclient.Tutor);
		}



	}
}
