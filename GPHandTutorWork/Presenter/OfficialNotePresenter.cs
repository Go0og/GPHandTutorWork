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
	public class OfficialNotePresenter : IOfficialNotePresenter
	{
		private readonly IOfficialNoteLogic _logic;
		public OfficialNotePresenter(IOfficialNoteLogic logic)
		{
			_logic = logic;
		}

		public List<OfficialNoteViewModel> MakeOfficialNoteListPresenter(OfficialNoteSearchModel? search_model)
		{
			var models = _logic.GetFullList(search_model);
			List<OfficialNoteViewModel> newViewModels = new();

			foreach (var model in models)
			{
				newViewModels.Add(new OfficialNoteViewModel
				{
					Id = model.Id,
					TutorId = model.TutorId,
					Comment = model.Comment,
				});
			}
			return newViewModels;
		}

		public OfficialNoteViewModel MakeOfficialNotePresenter(OfficialNoteSearchModel search_model)
		{
			var model = _logic.GetOfficialNote(search_model);
			if (model == null)
			{
				return null;
			}
			var newViewModel = new OfficialNoteViewModel
			{
				Id = model.Id,
				TutorId = model.TutorId,
				Comment = model.Comment,
			};
			return newViewModel;
		}
	}
}
