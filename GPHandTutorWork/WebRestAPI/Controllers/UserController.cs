using Contracts.BindingModel;
using Contracts.InteractorContract;
using Contracts.PresenterContract;
using Contracts.SearchModel;
using Contracts.ViewContract;
using Microsoft.AspNetCore.Mvc;
using Presenter;

namespace WebRestAPI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class UserController : Controller
	{
		public readonly ITutorLogic _TutorLogic;
		private readonly ITutorPresenter _TutorPresenter;
		private readonly IUniversityEmployeeLogic _UniversityEmployeeLogic;
		private readonly IUniversityEmployeePresenter _UniversityEmployeePresenter;

		public UserController(ITutorLogic TutoLogic, ITutorPresenter TutorPresenter, IUniversityEmployeeLogic universityEmployeeLogic, IUniversityEmployeePresenter universityEmployeePresenter)
		{
			_TutorPresenter = TutorPresenter;
			_TutorLogic = TutoLogic;
			_UniversityEmployeeLogic = universityEmployeeLogic;
			_UniversityEmployeePresenter = universityEmployeePresenter;
		}

		[HttpPost]
		public void register_tutor(TutorBindingModel model)
		{
			try
			{
				_TutorLogic.CreateTutor(model);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[HttpGet]
		public TutorViewModel? login_tutor(string Login, string password)
		{
			try
			{

				return _TutorPresenter.MakeTutorPresenter(new TutorSearchModel
				{
					Login = Login,
					Password = password
				});
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[HttpPost]
		public void edit_tutor(TutorBindingModel model)
		{
			try
			{
				_TutorLogic.UpdateTutor(model);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[HttpPost]
		public void register_employee(UniversityEmployeeBindingModel model)
		{
			try
			{
				_UniversityEmployeeLogic.CreateUniversityEmployee(model);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[HttpGet]
		public UniversityEmployeeViewModel? login_employee(string Login, string password)
		{
			try
			{
				return _UniversityEmployeePresenter.MakeUniversityEmployeePresenter(new UniversityEmployeeSearchModel
				{
					Login = Login,
					Password = password
				});
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[HttpPost]
		public void edit_employee(UniversityEmployeeBindingModel model)
		{
			try
			{
				_UniversityEmployeeLogic.UpdateUniversityEmployee(model);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

	}
}
