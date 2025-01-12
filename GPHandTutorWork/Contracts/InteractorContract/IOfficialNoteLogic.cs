using Contracts.BindingModel;
using Contracts.SearchModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InteractorContract
{
	public interface IOfficialNoteLogic
	{
		public List<OfficialNoteBindingModel> GetFullList(OfficialNoteSearchModel? searchModel);
		public OfficialNoteBindingModel? GetOfficialNote(OfficialNoteSearchModel searchModel);
		public bool CreateOfficialNote(OfficialNoteBindingModel BindingModel);
		public bool UpdateOfficialNote(OfficialNoteBindingModel BindingModel);
		public bool DeleteOfficialNote(OfficialNoteBindingModel BindingModel);
		public void CheckModel(OfficialNoteBindingModel BindingModel, bool obDel, bool onUp);
	}
}
