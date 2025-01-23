using Contracts.InteractorContract;
using Contracts.PresenterContract;
using Contracts.SearchModel;
using Contracts.StorageContract;
using Contracts.ViewContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
	public class GPHAgreementHeadmanPresent : IGPHAgreementPresenter
	{
		private readonly IGPHAgreementLogic _logic;
		public GPHAgreementHeadmanPresent(IGPHAgreementLogic logic)
		{
			_logic = logic;
		}

		public List<GPHAgreementViewModel> MakeAppoinmeanHeadmanListPresenter(GPHAgreementSearchModel? search_model)
		{
			var models = _logic.GetFillteredList(search_model);
			List<GPHAgreementViewModel> newViewModels = new();

			foreach (var model in models)
			{
				newViewModels.Add(new GPHAgreementViewModel
				{
					Id = model.Id,
					DataEnd = model.DataEnd,
					DateOfConclusion = model.DateOfConclusion,
					UniversityEmployeeId = model.UniversityEmployeeId,
					TeacherId = model.TeacherId,
					CurriculumList = model.CurriculumList,
					Bet = model.Bet,
				});
			}
			return newViewModels;
		}

		public GPHAgreementViewModel MakeAppointmeanHeadmenPresenter(GPHAgreementSearchModel search_model)
		{
			var model = _logic.GetGPHAgreement(search_model);
			var newViewModel = new GPHAgreementViewModel
			{
				Id = model.Id,
				DataEnd = model.DataEnd,
				DateOfConclusion = model.DateOfConclusion,
				UniversityEmployeeId = model.UniversityEmployeeId,
				TeacherId = model.TeacherId,
				CurriculumList = model.CurriculumList,
				Bet = model.Bet,
			};
			return newViewModel;
		}
	}
}
