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
	public class UniversityEmployeePresenter : IUniversityEmployeePresenter
	{
		private readonly IUniversityEmployeeLogic _logic;
		public UniversityEmployeePresenter(IUniversityEmployeeLogic logic)
		{
			_logic = logic;
		}
		public List<UniversityEmployeeViewModel> MakeUniversityEmployeeListPresenter(UniversityEmployeeSearchModel? search_model)
		{
			var models = _logic.GetFullList(search_model);
			List<UniversityEmployeeViewModel> newViewModels = new();

			foreach (var model in models)
			{
				newViewModels.Add(new UniversityEmployeeViewModel
				{
					Id = model.Id,
					FIO = model.FIO,
					Login = model.Login,
					Password = model.Password,
				});
			}
			return newViewModels;
		}

		public UniversityEmployeeViewModel MakeUniversityEmployeePresenter(UniversityEmployeeSearchModel search_model)
		{
			var model = _logic.GetUniversityEmployee(search_model);
			var newViewModel = new UniversityEmployeeViewModel
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
