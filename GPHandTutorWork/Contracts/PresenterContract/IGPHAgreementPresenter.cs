using Contracts.SearchModel;
using Contracts.ViewContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.PresenterContract
{
	public interface IGPHAgreementPresenter
	{
		public GPHAgreementViewModel MakeAppointmeanHeadmenPresenter(GPHAgreementSearchModel search_model);
		public List<GPHAgreementViewModel> MakeAppoinmeanHeadmanListPresenter(GPHAgreementSearchModel? search_model);
	}
}
