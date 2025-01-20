using Contracts.SearchModel;
using Contracts.ViewContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.PresenterContract
{
	public interface IUniversityEmployeePresenter
	{
		public UniversityEmployeeViewModel MakeUniversityEmployeePresenter(UniversityEmployeeSearchModel search_model);
		public List<UniversityEmployeeViewModel> MakeUniversityEmployeeListPresenter(UniversityEmployeeSearchModel? search_model);
	}
}
