using Contracts.SearchModel;
using Contracts.StorageContract.dbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.StorageContract
{
	public interface IWorkTutorStorage
	{
		public List<WorkTutor> GetFullList();
		public List<WorkTutor> GetFillteredList(WorkTutorSearchModel SearchModel);
		public WorkTutor? GetWorkTutor(WorkTutorSearchModel SearchModel);
	}
}
