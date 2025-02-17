using Contracts.SearchModel;
using Contracts.ViewContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InteractorContract
{
	public interface IReportEmployeeLogic
	{

		byte[]? SaveGPHToWordFile(List<GPHAgreementViewModel> model);

	}
}
