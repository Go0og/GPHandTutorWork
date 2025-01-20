using Contracts.SearchModel;
using Contracts.ViewContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.PresenterContract
{
	public interface ITutorPresenter
	{
		public TutorViewModel MakeTutorPresenter(TutorSearchModel search_model);
		public List<TutorViewModel> MakeTutorListPresenter(TutorSearchModel? search_model);
	}
}
