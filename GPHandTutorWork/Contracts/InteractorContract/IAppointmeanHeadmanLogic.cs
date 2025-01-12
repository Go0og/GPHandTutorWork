using Contracts.BindingModel;
using Contracts.SearchModel;
using Contracts.StorageContract.dbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InteractorContract
{
	public interface IAppointmeanHeadmanLogic
	{
		public List<AppointmentHeadmanBindingModel> GetFullList(AppointmentHeadmanSearchModel? searchModel);
		public AppointmentHeadmanBindingModel? GetAppointmentHeadman(AppointmentHeadmanSearchModel searchModel);
		public bool CreateAppointmentHeadman(AppointmentHeadmanBindingModel BindingModel);
		public bool UpdateAppointmentHeadman(AppointmentHeadmanBindingModel BindingModel);
		public bool DeleteAppointmentHeadman(AppointmentHeadmanBindingModel BindingModel);
		public void CheckModel(AppointmentHeadmanBindingModel BindingModel, bool obDel, bool onUp);
	}
}
