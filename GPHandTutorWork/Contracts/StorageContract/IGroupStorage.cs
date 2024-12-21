using Contracts.SearchModel;
using Contracts.StorageContract.dbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.StorageContract
{
	public interface IGroupStorage
	{
		public List<Group> GetFullList(); 
		public List<Group> GetFillteredList(GroupSearchModel SearchModel);
		public Group? GetGroup(GroupSearchModel SearchModel);
	}
}
