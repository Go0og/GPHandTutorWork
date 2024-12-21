using Contracts.SearchModel;
using Contracts.StorageContract.dbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.StorageContract
{
	public interface IProgressControlStorage
	{
		public List<ProgressControl> GetFullList();
		public List<ProgressControl> GetFillteredList(ProgressControlSearchModel SearchModel);
		public ProgressControl? GetProgressControl(ProgressControlSearchModel SearchModel);
	}
}
