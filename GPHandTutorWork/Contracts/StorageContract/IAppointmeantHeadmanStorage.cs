using Contracts.SearchModel;
using Contracts.StorageContract.dbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.StorageContract
{
	public interface IAppointmeantHeadmanStorage
	{
		public List<AppointmeantHeadman> GetFullList();
		public List<AppointmeantHeadman> GetFillteredList(AppointmeantHeadmanSearchModel SearchModel);
		public AppointmeantHeadman? GetAppointmeantHeadman(AppointmeantHeadmanSearchModel earchModel);

	}
}
