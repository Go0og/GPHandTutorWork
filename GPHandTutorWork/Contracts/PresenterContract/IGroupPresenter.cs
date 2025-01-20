using Contracts.SearchModel;
using Contracts.ViewContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.PresenterContract
{
	public interface IGroupPresenter
	{
		public GroupViewModel MakeGroupPresenter(GroupSearchModel search_model);
		public List<GroupViewModel> MakeGroupListPresenter(GroupSearchModel? search_model);
	}
}
