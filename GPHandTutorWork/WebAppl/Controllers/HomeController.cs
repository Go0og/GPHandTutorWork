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
			else
			{
				ViewBag.ErrorMessage = "Чтобы скачать или удалить записку, сначала её надо сохранить";
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
			if(id==0 || comment == null)
			{
				ViewBag.ErrorMessage = "Для скачивания отчёта он должен быть предварительно сохранён";
				ViewBag.Role=Role;
				Response.Redirect("OfficialNote");
				return View();
			}
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
		public IActionResult AgreementGPH_Create(int GPH_Id)
		{
			if (APIclient.UniversityEmployee == null)
			{
				ViewBag.Role = Role;
				Response.Redirect("Enter");
				return View();
			}
			ViewBag.Role = Role;

			var gph_data = APIclient.GetRequest<GPHAgreementViewModel>($"api/main/get_gph?gphid={GPH_Id}");

			ViewBag.gph_data = gph_data;

			ViewBag.subject = APIclient.GetRequest<List<CurriculumViewModel>>("api/main/get_unique_subject")
				.Select(s => s.Subject)
				.Distinct()
				.ToList();

			ViewBag.teachers = APIclient.GetRequest<List<TeacherViewModel>>("api/main/get_teachers");

			var curricula = APIclient.GetRequest<List<CurriculumViewModel>>("api/main/get_all_curricula");

			var curriculumNames = new Dictionary<int, string>();
			foreach (var curriculum in curricula)
			{
				curriculumNames[curriculum.Id] = curriculum.Subject;
				if (gph_data != null && curriculum.Id == gph_data.CurriculumId)
				{
					ViewBag.SelectedGroup = curriculum.GroupId;
					ViewBag.SelectedTerm = curriculum.Term;
				}
			}

			ViewBag.CurriculumNames = curriculumNames;

			if (gph_data != null)
			{
				ViewBag.SelectedTeacher = gph_data.TeacherId;
				ViewBag.DateStart = gph_data.DateOfConclusion.ToString("yyyy-MM-dd"); 
				ViewBag.DateEnd = gph_data.DataEnd.ToString("yyyy-MM-dd"); 
				ViewBag.Bet = gph_data.Bet;
			}

			return View();
		}


		[HttpGet]
		public IActionResult GetGroupNameById(int groupId)
		{
			var group = APIclient.GetRequest<GroupViewModel>($"api/main/get_group?id={groupId}");
			return Json(group?.Name); // Возвращаем название группы
		}

		[HttpGet]
		public IActionResult GetTermNameById(int termId)
		{
			return Json(termId); // Возвращаем название семестра
		}

		[HttpGet]
		public IActionResult GetTeacherNameById(int teacherId)
		{
			var teacher = APIclient.GetRequest<TeacherViewModel>($"api/main/get_teacher?id={teacherId}");
			return Json(teacher?.FIO); // Возвращаем ФИО преподавателя
		}






		[HttpGet]
		public IActionResult GetGroupsBySubject(string subject)
		{
			if (string.IsNullOrEmpty(subject))
			{
				ViewBag.Role = Role;
				return Json(new List<GroupViewModel>());
			}
			ViewBag.Role = Role;
			var groups = APIclient.GetRequest<List<GroupViewModel>>($"api/main/get_groups_by_subject?subject={subject}");
			return Json(groups);
		}
		[HttpGet]
		public IActionResult GetTermsByGroupAndSubject(int groupId, string subject)
		{
			if (groupId == 0 || string.IsNullOrEmpty(subject))
			{
				return Json(new List<int>());
			}

			var terms = APIclient.GetRequest<List<int>>($"api/main/get_terms_by_group_and_subject?groupId={groupId}&subject={subject}");
			return Json(terms);
		}

		[HttpPost]
		public IActionResult AgreementGPH_Create(string subject, int group,int teacher,string datestart, string dateend,int bet, int term)
		{
			if (APIclient.UniversityEmployee == null)
			{
				ViewBag.Role = Role;
				Response.Redirect("Enter");
				return View();
			}
			if (Convert.ToDateTime(datestart) < Convert.ToDateTime("01.01.2000") || Convert.ToDateTime(dateend) < Convert.ToDateTime("01.01.2000")
				|| Convert.ToDateTime(datestart) > Convert.ToDateTime("01.01.3000") || Convert.ToDateTime(dateend) > Convert.ToDateTime("01.01.3000"))
			{
				ViewBag.ErrorMessage = "Введите корректно даты для выборки";
				ViewBag.Role = Role;
				ViewBag.subject = APIclient.GetRequest<List<CurriculumViewModel>>("api/main/get_unique_subject").Select(s => s.Subject).Distinct().ToList();
				return View();
			}
			if(bet<0 || bet > 10000)
			{
				ViewBag.ErrorMessage = "Введите корректно оплату за час";
				ViewBag.Role = Role;
				ViewBag.subject = APIclient.GetRequest<List<CurriculumViewModel>>("api/main/get_unique_subject").Select(s => s.Subject).Distinct().ToList();
				return View();
			}
			if(string.IsNullOrEmpty(Convert.ToString(group)) || string.IsNullOrEmpty(Convert.ToString(subject)) || string.IsNullOrEmpty(Convert.ToString(teacher)))
			{
				ViewBag.ErrorMessage = "Введите корректно группу или предмет или преподавателя";
				ViewBag.Role = Role;
				ViewBag.subject = APIclient.GetRequest<List<CurriculumViewModel>>("api/main/get_unique_subject").Select(s => s.Subject).Distinct().ToList();
				return View();
			}
			var Subject = APIclient.GetRequest<CurriculumViewModel>($"api/main/get_curriculum?subject={subject}&group={group}&term={term}");
			APIclient.PostRequest("api/main/create_gph", new GPHAgreementBindingModel
			{
				TeacherId = teacher,
				UniversityEmployeeId = APIclient.UniversityEmployee.Id,
				DateOfConclusion = Convert.ToDateTime(datestart),
				DataEnd = Convert.ToDateTime(dateend),
				Bet = bet,
				CurriculumId = Subject.Id,
				IsActive = true,
			});

			ViewBag.Role = Role;
			return View("Index");
		}

		[HttpGet]
		public IActionResult AgreementGPH()
		{
			if (APIclient.UniversityEmployee == null)
			{
				return Redirect("~/Home/Enter");
			}

			// names subjects in web
			var curricula = APIclient.GetRequest<List<CurriculumViewModel>>("api/main/get_all_curricula");

			var curriculumNames = new Dictionary<int, string>();
			foreach (var curriculum in curricula)
			{
				curriculumNames[curriculum.Id] = curriculum.Subject;
			}

			ViewBag.CurriculumNames = curriculumNames;

			// names teachers in web 
			var teachers = APIclient.GetRequest<List<TeacherViewModel>>("api/main/get_full_teachers");
			
			var teachersNames = new Dictionary<int, string>();
			foreach (var teacher in teachers)
			{
				teachersNames[teacher.Id] = teacher.FIO;
			}
			ViewBag.Teachers = teachersNames;

			ViewBag.Role = Role;
			return View(APIclient.GetRequest<List<GPHAgreementViewModel>>($"api/main/get_gphs?employee={APIclient.UniversityEmployee.Id}"));
		}
	}
}
