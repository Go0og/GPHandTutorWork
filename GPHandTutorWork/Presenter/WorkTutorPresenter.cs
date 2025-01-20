using Contracts.InteractorContract;
using Contracts.PresenterContract;
using Contracts.SearchModel;
using Contracts.ViewContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
	public class WorkTutorPresenter : IWorkTutorPresenter
	{
		private readonly IWorkTutorLogic _logic;
		public WorkTutorPresenter(IWorkTutorLogic logic)
		{
			_logic = logic;
		}

		public List<WorkTutorViewModel> MakeWorkTutorListPresenter(WorkTutorSearchModel? search_model)
		{
			var models = _logic.GetFillteredList(search_model);
			List<WorkTutorViewModel> newViewModels = new();

			foreach (var model in models)
			{
				newViewModels.Add(new WorkTutorViewModel
				{
					Id = model.Id,
					TutorId = model.TutorId,
					TypeWork = model.TypeWork.ToString(),
					DateWork = model.DateWork.ToString(),
				});
			}
			return newViewModels;
		}

		public WorkTutorViewModel MakeWorkTutorPresenter(WorkTutorSearchModel search_model)
		{
			var model = _logic.GetWorkTutor(search_model);
			var newViewModel = new WorkTutorViewModel
			{
				Id = model.Id,
				TutorId = model.TutorId,
				TypeWork = model.TypeWork.ToString(),
				DateWork = model.DateWork.ToString(),
			};
			return newViewModel;
		}
	}
}
