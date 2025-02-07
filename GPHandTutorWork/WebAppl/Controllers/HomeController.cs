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
using DataModel.Model;
using DocumentFormat.OpenXml.Office2010.Excel;

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
		public IActionResult Enter(string Login, string password, string role)
		{
			if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(password))
			{
				ViewBag.ErrorMessage = "Заполните все поля (логин и пароль)";
				ViewBag.Role = Role;
				return View(); 
			}

			switch (role)
			{
				case "Куратор":
					APIclient.Tutor = APIclient.GetRequest<TutorViewModel>($"api/user/login_tutor?Login={Login}&password={password}");
					if (APIclient.Tutor == null)
					{
						ViewBag.ErrorMessage = "Неверный логин или пароль";
						ViewBag.Role = Role;
						return View(); 
					}
					break;

				case "Сотрудник кафедры":
					APIclient.UniversityEmployee = APIclient.GetRequest<UniversityEmployeeViewModel>($"api/user/login_employee?Login={Login}&password={password}");
					if (APIclient.UniversityEmployee == null)
					{
						ViewBag.ErrorMessage = "Неверный логин или пароль";
						ViewBag.Role = Role;
						return View(); 
					}
					break;
			}

			ViewBag.Role = Role;
			return RedirectToAction("Index"); 
		}

		[HttpGet]
		public IActionResult Register()
		{
			ViewBag.Role = Role;
			return View();
		}

		[HttpPost]
		public IActionResult Register(string login, string password, string fio, string role)
		{
			if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(fio))
			{
				ViewBag.ErrorMessage = "Заполните все поля (логин, пароль или фио)";
				ViewBag.Role = Role;
				return View();
			}
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
			return RedirectToAction("Enter");
		}

		[HttpPost]
		public void AppointmeanHeadman(string student)
		{
			if(APIclient.Tutor == null)
			{
				Response.Redirect("Enter");
			}
			if(student == null)
			{
				ViewBag.Role = Role;
				Response.Redirect("AppointmeanHeadman");
				return;
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


		[HttpGet]
		public IActionResult ProgressControll()
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
		public IActionResult ProgressControllStudent(int StudentID)
		{
			if (APIclient.Tutor == null)
			{
				Response.Redirect("Enter");
				return View();
			}

			var progressData = APIclient.GetRequest<List<ProgressControlViewModel>>($"api/main/get_progress_student?StudentID={StudentID}&TutorId={APIclient.Tutor.Id}");


			var curricula = APIclient.GetRequest<List<CurriculumViewModel>>("api/main/get_all_curricula");

			var curriculumNames = new Dictionary<int, string>();
			foreach (var curriculum in curricula)
			{
				curriculumNames[curriculum.Id] = curriculum.Subject;
			}

			ViewBag.CurriculumNames = curriculumNames;

			ViewBag.Role = Role;
			return View(progressData);
		}



		[HttpGet] 
		public IActionResult CreateWordReport(string comment, int id)
		{
			var fileMemStream = APIclient.GetRequest<byte[]>($"api/main/create_report_note?id={id}&comment={comment}&tutorId={APIclient.Tutor.Id}");

			if (fileMemStream == null)
			{
				throw new Exception("Ошибка создания отчета");
			}

			return File(fileMemStream, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "Report.docx");
		}


		[HttpGet]
		public IActionResult WorkTutor()
		{
			if (APIclient.Tutor == null)
			{
				Response.Redirect("Enter");
				return View();
			}
			ViewBag.Role = Role;
			return View(APIclient.GetRequest<List<WorkTutorViewModel>>($"api/main/get_work?tutorid={APIclient.Tutor.Id}"));
		}

		[HttpPost]
		public IActionResult WorkTutor(string datestart, string dateend, string action)
		{
			if (APIclient.Tutor == null)
			{
				Response.Redirect("Enter");
				return View();
			}

			if (Convert.ToDateTime(datestart) < Convert.ToDateTime("01.01.2000") || Convert.ToDateTime(dateend) < Convert.ToDateTime("01.01.2000")
				|| Convert.ToDateTime(datestart) > Convert.ToDateTime("01.01.3000") || Convert.ToDateTime(dateend) > Convert.ToDateTime("01.01.3000"))
			{
				ViewBag.ErrorMessage = "Введите корректно даты для выборки";
				ViewBag.Role = Role;
				return View(APIclient.GetRequest<List<WorkTutorViewModel>>($"api/main/get_work?tutorid={APIclient.Tutor.Id}"));
			}

			if (action == "Фильтровать")
			{
				var filteredData = APIclient.GetRequest<List<WorkTutorViewModel>>($"api/main/get_work_filltered?tutorid={APIclient.Tutor.Id}&datestart={datestart}&dateend={dateend}");
				ViewBag.DateStart = Convert.ToDateTime(datestart);
				ViewBag.DateEnd = Convert.ToDateTime(dateend);
				ViewBag.Role = Role;
				return View(filteredData);
			}

			if (action == "Скачать")
			{
				var fileMemStream = APIclient.GetRequest<byte[]>($"api/main/create_report_work?datestart={datestart}&dateend={dateend}");
				if (fileMemStream == null)
				{
					throw new Exception("Ошибка создания отчета");
				}
				ViewBag.Role = Role;
				return File(fileMemStream, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "Report.docx");
			}
			ViewBag.Role = Role;
			return View(APIclient.GetRequest<List<WorkTutorViewModel>>($"api/main/get_work?tutorid={APIclient.Tutor.Id}"));
		}
		[HttpGet]
		public IActionResult AgreementGPH()
		{
			if (APIclient.UniversityEmployee == null)
			{
				Response.Redirect("Enter");
				return View();
			}
			ViewBag.Subject = APIclient.GetRequest<List<CurriculumViewModel>>("");
			return View();
		}

	}
}
