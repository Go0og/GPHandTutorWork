using Contracts.BindingModel;
using Contracts.SearchModel;
using Contracts.StorageContract.dbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.StorageContract
{
	public interface IAppointmentHeadmanStorage
	{
		public List<AppointmentHeadman> GetFullList();
		public List<AppointmentHeadman> GetFillteredList(AppointmentHeadmanSearchModel SearchModel);
		public AppointmentHeadman? GetAppointmentHeadman(AppointmentHeadmanSearchModel earchModel);
		public bool CreateAppointmentHeadman(AppointmentHeadmanBindingModel AppointmentHeadmanBindingModel);
		public bool UpdateAppointmentHeadman(AppointmentHeadmanBindingModel AppointmentHeadmanBindingModel);
		public bool DeleteAppointmentHeadman(AppointmentHeadmanBindingModel AppointmentHeadmanBindingModel);

	}
}
