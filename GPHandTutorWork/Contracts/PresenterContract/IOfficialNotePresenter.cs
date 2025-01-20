using Contracts.SearchModel;
using Contracts.ViewContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.PresenterContract
{
	public interface IOfficialNotePresenter
	{
		public OfficialNoteViewModel MakeOfficialNotePresenter(OfficialNoteSearchModel search_model);
		public List<OfficialNoteViewModel> MakeOfficialNoteListPresenter(OfficialNoteSearchModel? search_model);
	}
}
