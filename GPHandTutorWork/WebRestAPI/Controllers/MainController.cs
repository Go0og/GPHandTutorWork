using Contracts.BindingModel;
using Contracts.InteractorContract;
using Contracts.PresenterContract;
using Contracts.SearchModel;
using Contracts.StorageContract.dbModels;
using Contracts.ViewContract;
using Interactors;
using Microsoft.AspNetCore.Mvc;


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

		public MainController(IAppointmeanHeadmanPresenter appointmeanHeadmanPresenter, ICurriculumPresenter curriculumPresenter,
			IGPHAgreementPresenter GPHAgreementPresenter, IGroupPresenter groupPresenter, IOfficialNotePresenter officialNotePresenter, IProgressControlPrestnter progressControlPrestnter,
			IStudentPrestnter studentPrestnter, ITeacherPresenter teacherPresenter, ITutorPresenter tutorPresenter, IUniversityEmployeePresenter universityEmployeePresenter, IWorkTutorPresenter workTutorPresenter,
			IAppointmeanHeadmanLogic appointmeanHeadmanLogic, IOfficialNoteLogic officialNoteLogic, IProgressControlLogic progressControlLogic)
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
					TutorId= TutorID
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
		public List<ProgressControlViewModel> get_progress_student(int StudentID)
		{
			try
			{
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




	}
}
