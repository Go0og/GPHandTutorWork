using Contracts.InteractorContract;
using Contracts.PresenterContract;
using Contracts.SearchModel;
using Contracts.ViewContract;
using DataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
	public class StudentPresenter : IStudentPrestnter
	{
		private readonly IStudentLogic _logic;
		public StudentPresenter (IStudentLogic logic)
		{
			_logic = logic;
		}
		public List<StudentViewModel> MakeStudentListPresenter(StudentSearchModel? search_model)
		{
			var models = _logic.GetFullList(search_model);
			List<StudentViewModel> newViewModels = new();

			foreach (var model in models)
			{
				newViewModels.Add(new StudentViewModel
				{
					Id = model.Id,
					FIO = model.FIO,
					GroupId = model.GroupId,
				});
			}
			return newViewModels;
		}

		public StudentViewModel MakeStudentPresenter(StudentSearchModel search_model)
		{
			var model = _logic.GetStudent(search_model);
			var newViewModel = new StudentViewModel
			{
				Id = model.Id,
				FIO = model.FIO,
				GroupId = model.GroupId,
			};
			return newViewModel;
		}
	}
}
