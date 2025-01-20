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
	public class TutorPresenter : ITutorPresenter
	{
		private readonly ITutorLogic _logic;
		public TutorPresenter(ITutorLogic logic)
		{
			_logic = logic;
		}

		public List<TutorViewModel> MakeTutorListPresenter(TutorSearchModel? search_model)
		{
			var models = _logic.GetFullList(search_model);
			List<TutorViewModel> newViewModels = new();

			foreach (var model in models)
			{
				newViewModels.Add(new TutorViewModel
				{
					Id = model.Id,
					FIO = model.FIO,
					Login = model.Login,
					Password = model.Password,
				});
			}
			return newViewModels;
		}

		public TutorViewModel MakeTutorPresenter(TutorSearchModel search_model)
		{
			var model = _logic.GetTutor(search_model);
			var newViewModel = new TutorViewModel
			{
				Id = model.Id,
				FIO = model.FIO,
				Login = model.Login,
				Password = model.Password,
			};
			return newViewModel;
		}
	}
}
