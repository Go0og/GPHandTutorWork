using Contracts.InteractorContract;
using Contracts.PresenterContract;
using Contracts.SearchModel;
using Contracts.ViewContract;
using DataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
	public class TeacherPresenter : ITeacherPresenter
	{
		private readonly ITeacherLogic _logic;
		public TeacherPresenter(ITeacherLogic Logic)
		{
			_logic = Logic;
		}

		public List<TeacherViewModel> MakeTeacherListPresenter(TeacherSearchModel? search_model)
		{
			var models = _logic.GetFullList(search_model);
			List<TeacherViewModel> newViewModels = new();

			foreach (var item in models)
			{
				newViewModels.Add(new TeacherViewModel
				{
					Id = item.Id,
					FIO = item.FIO,
					DateOfBirth = item.DateOfBirth,
					PassportSerialAndNumber = item.PassportSerialAndNumber,
					ContactPhoneNumber = item.ContactPhoneNumber,
					INN = item.INN,
					InsuranceNumber = item.InsuranceNumber,
					CardDetails = item.CardDetails,
				});
			}
			return newViewModels;
		}

		public TeacherViewModel MakeTeacherPresenter(TeacherSearchModel search_model)
		{
			var item = _logic.GetTeacher(search_model);
			var newViewModel = new TeacherViewModel
			{
				Id = item.Id,
				FIO = item.FIO,
				DateOfBirth = item.DateOfBirth,
				PassportSerialAndNumber = item.PassportSerialAndNumber,
				ContactPhoneNumber = item.ContactPhoneNumber,
				INN = item.INN,
				InsuranceNumber = item.InsuranceNumber,
				CardDetails = item.CardDetails,
			};
			return newViewModel;
		}
	}
}
