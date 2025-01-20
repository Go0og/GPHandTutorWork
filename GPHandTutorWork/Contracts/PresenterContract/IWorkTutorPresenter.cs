using Contracts.SearchModel;
using Contracts.ViewContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.PresenterContract
{
	public interface IWorkTutorPresenter
	{
		public WorkTutorViewModel MakeWorkTutorPresenter(WorkTutorSearchModel search_model);
		public List<WorkTutorViewModel> MakeWorkTutorListPresenter(WorkTutorSearchModel? search_model);
	}
}
