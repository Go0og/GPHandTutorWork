using Contracts.InteractorContract;
using Contracts.PresenterContract;
using Contracts.SearchModel;
using Contracts.StorageContract.dbModels;
using Contracts.ViewContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Presenter
{
	public class GroupPresent : IGroupPresenter
	{
		private readonly IGroupLogic _logic;
		public GroupPresent(IGroupLogic logic)
		{
			_logic = logic;
		}

		public List<GroupViewModel> MakeGroupListPresenter(GroupSearchModel search_model)
		{
			var models = _logic.GetFilteredList(search_model);
			List<GroupViewModel> newViewModels = new();

			foreach (var item in models)
			{
				newViewModels.Add(new GroupViewModel
				{
					Id = item.Id,
					Name = item.Name,
					TutorId = item.TutorId
				});
			}
			return newViewModels;
		}

		public GroupViewModel MakeGroupPresenter(GroupSearchModel search_model)
		{
			var model = _logic.GetGroup(search_model);
			var newViewModel = new GroupViewModel
			{ 
				Id = model.Id,
				Name = model.Name,
				TutorId = model.TutorId
			};
			return newViewModel;
		}
	}
}
