using Contracts.SearchModel;
using Contracts.ViewContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.PresenterContract
{
	public interface IAppointmeanHeadmanPresenter
	{
		public AppointmentHeadmanViewModel MakeAppointmeanHeadmenPresenter(AppointmentHeadmanSearchModel search_model);
		public List<AppointmentHeadmanViewModel> MakeAppointmeanHeadmanListPresenter(AppointmentHeadmanSearchModel? search_model);
	}
}
