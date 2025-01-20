using Contracts.InteractorContract;
using Contracts.PresenterContract;
using Contracts.SearchModel;
using Contracts.ViewContract;
using System.Reflection;

namespace Presenter
{
	public class AppointmeanHeadmanPresenter : IAppointmeanHeadmanPresenter
	{
		private readonly IAppointmeanHeadmanLogic _logic;
		public AppointmeanHeadmanPresenter(IAppointmeanHeadmanLogic logic)
		{
			_logic = logic;
		}
		public List<AppointmentHeadmanViewModel> MakeAppointmeanHeadmanListPresenter(AppointmentHeadmanSearchModel? search_model)
		{
			var models = _logic.GetFullList(search_model);
			List<AppointmentHeadmanViewModel> newViewModels = new();

			foreach (var item in models)
			{
				newViewModels.Add(new AppointmentHeadmanViewModel
				{
					Id = item.Id,
					TutorId = item.TutorId,
					StudentId = item.StudentId
				});
			}
			return newViewModels;
		}

		public AppointmentHeadmanViewModel MakeAppointmeanHeadmenPresenter(AppointmentHeadmanSearchModel search_model)
		{
			var model = _logic.GetAppointmentHeadman(search_model);
			var newViewModel = new AppointmentHeadmanViewModel
			{
				Id = model.Id,
				TutorId = model.TutorId,
				StudentId = model.StudentId
			};
			return newViewModel;
		}
	}
}
