using Contracts.BindingModel;
using Contracts.InteractorContract;
using Contracts.PresenterContract;
using Contracts.SearchModel;
using Contracts.StorageContract.dbModels;
using Contracts.ViewContract;
using DataModel.Enum;
using DocumentFormat.OpenXml.Office2010.Excel;
using Interactors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;


namespace WebRestAPI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class MainController : ControllerBase
	{
		private readonly IAppointmeanHeadmanPresenter _AppointmeanPresent;
		private readonly IAppointmeanHeadmanLogic _AppointmeanHeadmanLogic;
		private readonly ICurriculumPresenter _CurriculumPresent;
		private readonly IGPHAgreementPresenter _GPHAgreementPresenter;
		private readonly IGPHAgreementLogic _GPHAgreementLogic;
		private readonly IGroupPresenter _GroupPresenter;
		private readonly IOfficialNotePresenter _OfficialNotePresenter;
		private readonly IOfficialNoteLogic _OfficialNoteLogic;
		private readonly IProgressControlPrestnter _ProgressControlPresenter;
		private readonly IProgressControlLogic _progressControlLogic;
		private readonly IStudentPrestnter _StudentPresenter;
		private readonly ITeacherPresenter _TeacherPresenter;
		private readonly ITutorPresenter _TutorPresenter;
		private readonly IUniversityEmployeePresenter _UniversityEmployeePresenter;
		private readonly IWorkTutorPresenter _WorkTutorPresenter;
		private readonly IWorkTutorLogic _WorkTutorLogic;
		private readonly IReportTutorLogic _ReportTutorLogic;

		public MainController(IAppointmeanHeadmanPresenter appointmeanHeadmanPresenter, ICurriculumPresenter curriculumPresenter,
			IGPHAgreementPresenter GPHAgreementPresenter, IGroupPresenter groupPresenter, IOfficialNotePresenter officialNotePresenter, IProgressControlPrestnter progressControlPrestnter,
			IStudentPrestnter studentPrestnter, ITeacherPresenter teacherPresenter, ITutorPresenter tutorPresenter, IUniversityEmployeePresenter universityEmployeePresenter, IWorkTutorPresenter workTutorPresenter,
			IAppointmeanHeadmanLogic appointmeanHeadmanLogic, IOfficialNoteLogic officialNoteLogic, IProgressControlLogic progressControlLogic, IWorkTutorLogic workTutorLogic, IReportTutorLogic reportTutorLogic, IGPHAgreementLogic gPHAgreementLogic)
		{
			_AppointmeanPresent = appointmeanHeadmanPresenter;
			_CurriculumPresent = curriculumPresenter;
			_GPHAgreementPresenter = GPHAgreementPresenter;
			_GroupPresenter = groupPresenter;
			_TeacherPresenter = teacherPresenter;
			_OfficialNotePresenter = officialNotePresenter;
			_ProgressControlPresenter = progressControlPrestnter;
			_StudentPresenter = studentPrestnter;
			_TeacherPresenter = teacherPresenter;
			_TutorPresenter = tutorPresenter;
			_UniversityEmployeePresenter = universityEmployeePresenter;
			_WorkTutorPresenter = workTutorPresenter;

			_AppointmeanHeadmanLogic = appointmeanHeadmanLogic;
			_OfficialNoteLogic = officialNoteLogic;
			_progressControlLogic = progressControlLogic;
			_WorkTutorLogic = workTutorLogic;
			_ReportTutorLogic = reportTutorLogic;
			_GPHAgreementLogic = gPHAgreementLogic;
		}
		[HttpGet]
		public GroupViewModel get_group(int id)
		{
			try
			{
				return _GroupPresenter.MakeGroupPresenter(new GroupSearchModel
				{
					Id = id,
				});

			}
			catch (Exception ex)
			{
				throw;
			}
		}
		[HttpGet]
		public List<GroupViewModel> get_group_list(int TutorID)
		{
			try
			{
				return _GroupPresenter.MakeGroupListPresenter(new GroupSearchModel
				{
					TutorId = TutorID
				});

			}
			catch (Exception ex)
			{
				throw;
			}
		}
		[HttpGet]
		public List<StudentViewModel> get_student_list(int GroupID)
		{
			try
			{
				return _StudentPresenter.MakeStudentListPresenter(new StudentSearchModel
				{
					GroupId = GroupID
				});

			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[HttpPost]
		public void add_appointmean_headman(AppointmentHeadmanBindingModel model)
		{
			try
			{
				_AppointmeanHeadmanLogic.CreateAppointmentHeadman(model);
			}
			catch (Exception ex)
			{
				throw;
			}
		}
		[HttpGet]
		public List<OfficialNoteViewModel> get_notes(int TutorID)
		{
			try
			{
				return _OfficialNotePresenter.MakeOfficialNoteListPresenter(new OfficialNoteSearchModel
				{
					TutorId = TutorID
				});

			}
			catch (Exception ex)
			{
				throw;
			}
		}
		[HttpGet]
		public OfficialNoteViewModel get_note(int TutorID, int Note_id)
		{
			try
			{
				return _OfficialNotePresenter.MakeOfficialNotePresenter(new OfficialNoteSearchModel
				{
					Id = Note_id,
				});

			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[HttpPost]
		public void add_official_note(OfficialNoteBindingModel model)
		{
			try
			{
				_OfficialNoteLogic.CreateOfficialNote(model);
			}
			catch (Exception ex)
			{
				throw;
			}
		}
		[HttpPost]
		public void update_official_note(OfficialNoteBindingModel model)
		{
			try
			{
				_OfficialNoteLogic.UpdateOfficialNote(model);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[HttpPost]
		public void delete_official_note(OfficialNoteBindingModel model)
		{
			try
			{
				_OfficialNoteLogic.DeleteOfficialNote(model);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[HttpGet]
		public List<ProgressControlViewModel> get_progress_student(int StudentID, int TutorId)
		{
			try
			{
				_WorkTutorLogic.CreateWorkTutor(new WorkTutorBindingModel
				{
					TutorId = TutorId,
					DateWork = DateTime.Now,
					TypeWork = TypeWork.КонтрольПосещаимости
				});
				return _ProgressControlPresenter.MakeProgressControlListPresenter(new ProgressControlSearchModel
				{
					StudentId = StudentID
				});

			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[HttpGet]
		public List<CurriculumViewModel> get_all_curricula()
		{
			try
			{
				return _CurriculumPresent.MakeCurriculumIdPresenter();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[HttpGet]
		public byte[]? create_report_note(int id, int tutorid, string comment)
		{
			try
			{
				return _ReportTutorLogic.SaveNoteToWordFile(new OfficialNoteViewModel
				{
					Id = id,
					TutorId = tutorid,
					Comment = comment
				});
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[HttpGet]
		public List<WorkTutorViewModel> get_work(int tutorid)
		{
			try
			{
				return _WorkTutorPresenter.MakeWorkTutorListPresenter(new WorkTutorSearchModel
				{
					TutorId = tutorid
				});
			}
			catch (Exception ex)
			{
				throw;
			}
		}
		[HttpGet]
		public List<WorkTutorViewModel> get_work_filltered(int tutorid, string datestart, string dateend)
		{
			try
			{
				return _WorkTutorPresenter.MakeWorkTutorListPresenter(new WorkTutorSearchModel
				{
					TutorId = tutorid,
					DateStart = Convert.ToDateTime(datestart),
					DateEnd = Convert.ToDateTime(dateend)
				});
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[HttpGet]
		public byte[]? create_report_work(DateTime datestart, DateTime dateend)
		{
			try
			{
				return _ReportTutorLogic.SaveWorkToWordFile(new WorkTutorSearchModel
				{
					DateStart = datestart,
					DateEnd = dateend
				});
			}
			catch (Exception ex)
			{
				throw;
			}
		}


		[HttpGet]
		public List<CurriculumViewModel> get_unique_subject()
		{
			try
			{
				return _CurriculumPresent.MakeCurriculumIdPresenter();
			}
			catch (Exception ex)
			{
				throw;
			}
		}


		[HttpGet]
		public List<GroupViewModel> get_groups_by_subject(string subject)
		{
			try
			{
				return _CurriculumPresent.groupViewModels(new CurriculumSearchModel
				{
					Subject = subject
				});
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[HttpGet]
		public List<int> get_terms_by_group_and_subject(int groupid,string subject)
		{
			try
			{
				return _CurriculumPresent.GetTermsByGroupAndSubject(new CurriculumSearchModel
				{
					Subject = subject,
					GroupId = groupid
					
				});
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[HttpGet]
		public List<TeacherViewModel> get_teachers()
		{
			try
			{
				return _TeacherPresenter.MakeTeacherListPresenter(null);
			}
			catch (Exception ex)
			{
				throw;
			}
		}


		[HttpGet]
		public CurriculumViewModel get_curriculum(string subject,int group, int term)
		{
			try
			{
				return  _CurriculumPresent.MakeCurriculumPresenter(new CurriculumSearchModel
				{
					Subject = subject,
					GroupId=group,
					Term = term
				});
			}
			catch (Exception ex)
			{
				throw;
			}
		}
		[HttpPost]
		public void create_gph(GPHAgreementBindingModel model)
		{
			try
			{
				_GPHAgreementLogic.CreateGPHAgreement(model);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[HttpGet]
		public List<GPHAgreementViewModel> get_gphs(int employee)
		{
			try
			{
				return _GPHAgreementPresenter.MakeAppoinmeanHeadmanListPresenter(new GPHAgreementSearchModel
				{
					UniversityEmployeeId = employee,
				});

			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[HttpGet]
		public GPHAgreementViewModel get_gph(int gphid)
		{
			try
			{
				return _GPHAgreementPresenter.MakeAppointmeanHeadmenPresenter(new GPHAgreementSearchModel
				{
					Id= gphid,
				});

			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[HttpGet]
		public List<TeacherViewModel> get_full_teachers()
		{
			try
			{
				return _TeacherPresenter.MakeTeacherListPresenter(null);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[HttpGet]
		public TeacherViewModel get_teacher(int id)
		{
			try
			{
				return _TeacherPresenter.MakeTeacherPresenter(new TeacherSearchModel
				{
					Id = id,
				});
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[HttpPost]
		public void update_gph(GPHAgreementBindingModel model)
		{
			try
			{
				_GPHAgreementLogic.UpdateGPHAgreement(model);
			}
			catch (Exception ex)
			{
				throw;
			}
		}
		[HttpPost]
		public void delete_gph(GPHAgreementBindingModel model)
		{
			try
			{
				_GPHAgreementLogic.DeleteGPHAgreement(model);
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}
