using Contracts.SearchModel;
using Contracts.ViewContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.PresenterContract
{
	public interface ICurriculumPresenter
	{
		public CurriculumViewModel MakeCurriculumPresenter (CurriculumSearchModel search_model);

		public List<GroupViewModel> groupViewModels(CurriculumSearchModel search_model);
		public List<CurriculumViewModel> MakeCurriculumListPresenter();
	}
}
