using Contracts.BindingModel;
using Contracts.ViewContract;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using WebApp;
using WebAppl.Models;

namespace WebAppl.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private string Role = string.Empty;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			if (Role == string.Empty)
			{
				return Redirect("~/Home/Enter");
			}
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
		[HttpGet]
		public IActionResult Enter()
		{
			return View();
		}

		[HttpPost]
		public void Enter(string Login, string password, string role)
		{
			switch (role)
			{
				case ("Куратор"):
					APIclient.Tutor = APIclient.GetRequest<TutorViewModel>($"api/user/login_tutor?Login={Login}&password={password}");
					if (APIclient.Tutor == null)
					{
						throw new Exception("Неверный логин/пароль");
					}
					break;
				case ("Сотрудник кафедры"):
					APIclient.UniversityEmployee = APIclient.GetRequest<UniversityEmployeeViewModel>($"api/user/login_employee?Login={Login}&password={password}");
					if (APIclient.UniversityEmployee == null)
					{
						throw new Exception("Неверный логин/пароль");
					}
					break;
			}
			Role = role;
			Response.Redirect("Index");
		}

		[HttpGet]
		public IActionResult Register()
		{
			//ViewBag.departments = APIclient.GetRequest<List<department_view_model>>("api/main/get_department_list");
			return View();
		}

		[HttpPost]
		public void Register(string login, string password, string fio, string role) 
		{
			switch (role)
			{
				case ("Куратор"):
					APIclient.PostRequest("api/user/register_tutor", new TutorBindingModel
					{
						Login = login,
						Password = password,
						FIO = fio,
					});
					break;
				case ("Сотрудник кафедры"):
					APIclient.PostRequest("api/user/register_employee", new UniversityEmployeeBindingModel
					{
						Login = login,
						Password = password,
						FIO = fio,
					});
					break;
			}
			Response.Redirect("Enter");
		}
	}
}
