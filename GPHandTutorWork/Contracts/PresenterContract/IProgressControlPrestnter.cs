using Contracts.SearchModel;
using Contracts.ViewContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.PresenterContract
{
	public interface IProgressControlPrestnter
	{
		public ProgressControlViewModel MakeProgressControlPresenter(ProgressControlSearchModel search_model);
		public List<ProgressControlViewModel> MakeProgressControlListPresenter(ProgressControlSearchModel? search_model);
	}
}
