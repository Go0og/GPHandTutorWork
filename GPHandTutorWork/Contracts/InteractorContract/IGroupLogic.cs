using Contracts.BindingModel;
using Contracts.SearchModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InteractorContract
{
	public interface IGroupLogic
	{
		public List<GroupBindingModel> GetFullList();
		public GroupBindingModel? GetGroup(GroupSearchModel SearchModel);
	}
}
