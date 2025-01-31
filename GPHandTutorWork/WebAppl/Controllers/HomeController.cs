using Contracts.BindingModel;
using Contracts.ViewContract;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using WebAppL;
using WebAppl.Models;
using AspNetCoreGeneratedDocument;
using Contracts.SearchModel;
using Contracts.StorageContract.dbModels;

namespace WebAppl.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		public string Role { get; set; } = string.Empty;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
			if (APIclient.Tutor != null)
			{
				Role = "Куратор";
			}
			else if(APIclient.UniversityEmployee != null)
			{
				Role = "Сотрудник";
			}
		}

		public IActionResult Index()
		{
			if (Role == string.Empty)
			{
				return Redirect("~/Home/Enter");
			}
			ViewBag.Role = Role;
			return View();
		}

		public IActionResult Privacy()
		{
			ViewBag.Role = Role;
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
			ViewBag.Role = Role;
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
			ViewBag.Role = Role;
			Response.Redirect("Index");
		}

		[HttpGet]
		public IActionResult Register()
		{
			ViewBag.Role = Role;
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
			ViewBag.Role = Role;
			Response.Redirect("Enter");
		}

		[HttpPost]
		public void AppointmeanHeadman(string student)
		{
			if(APIclient.Tutor == null)
			{
				Response.Redirect("Enter");
			}
			APIclient.PostRequest("api/main/add_appointmean_headman", new AppointmentHeadmanBindingModel
			{
				StudentId = Convert.ToInt32(student),
				TutorId = APIclient.Tutor.Id
			});
			ViewBag.Role = Role;
			Response.Redirect("Index");
		}



		[HttpGet]
		public IActionResult AppointmeanHeadman()
		{
			if (APIclient.Tutor == null)
			{
				return Redirect("~/Home/Enter");
			}

			ViewBag.Groups = APIclient.GetRequest<List<GroupViewModel>>($"api/main/get_group_list?TutorID={APIclient.Tutor.Id}");
			ViewBag.StudentS = new List<StudentViewModel>();
			ViewBag.Role = Role;
			return View();
		}

		[HttpGet]
		public List<StudentViewModel> Get_Students_groups(int group)
		{
			ViewBag.Role = Role;
			return APIclient.GetRequest<List<StudentViewModel>>($"api/main/get_student_list?GroupID={group}");
		}

		[HttpGet]
		public IActionResult OfficialNote()
		{
			if (APIclient.Tutor == null)
			{
				return Redirect("~/Home/Enter");
			}
			ViewBag.Role = Role;
			return View(APIclient.GetRequest<List<OfficialNoteViewModel>>($"api/main/get_notes?TutorId={APIclient.Tutor.Id}"));
		}

		[HttpGet]
		public IActionResult OfficialNoteCreate(string Note_id)
		{
			ViewBag.Role = Role;
			if(Note_id != null)
			{
				ViewBag.Text=APIclient.GetRequest<OfficialNoteViewModel>($"api/main/get_note?Note_id={Note_id}");
			}
			return View();
		}

		[HttpPost]
		public void OfficialNoteCreate(string comment, int id, string action)
		{
			if (APIclient.Tutor == null)
			{
				Response.Redirect("Enter");
				return;
			}

			switch (action)
			{
				case "save":
					if (id > 0)
					{
						APIclient.PostRequest("api/main/update_official_note", new OfficialNoteBindingModel
						{
							Id = id,
							Comment = comment,
							TutorId = APIclient.Tutor.Id
						});
					}
					else
					{
						APIclient.PostRequest("api/main/add_official_note", new OfficialNoteBindingModel
						{
							Comment = comment,
							TutorId = APIclient.Tutor.Id
						});
					}
					break;

				case "delete":
					if (id > 0)
					{
						APIclient.PostRequest("api/main/delete_official_note", new OfficialNoteBindingModel
						{
							Id = id,
							Comment = comment,
							TutorId = APIclient.Tutor.Id
						});
					}
					break;
			}

			ViewBag.Role = Role;
			Response.Redirect("OfficialNote");
		}
	}
}
