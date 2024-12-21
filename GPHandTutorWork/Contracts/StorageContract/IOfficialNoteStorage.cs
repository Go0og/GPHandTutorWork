using Contracts.SearchModel;
using Contracts.StorageContract.dbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.StorageContract
{
	public interface IOfficialNoteStorage
	{
		public List<OfficialNote> GetFullList();
		public List<OfficialNote> GetFillteredList(OfficialNoteSearchModel SearchModel);
		public OfficialNote? GetOfficialNote(OfficialNoteSearchModel SearchModel);
	}
}
