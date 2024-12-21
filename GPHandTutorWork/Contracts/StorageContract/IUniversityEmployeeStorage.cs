using Contracts.SearchModel;
using Contracts.StorageContract.dbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.StorageContract
{
	public interface IUniversityEmployeeStorage
	{
		public List<UniversityEmployee> GetFullList();
		public List<UniversityEmployee> GetFillteredList(UniversityEmployeeSearchModel SearchModel);
		public UniversityEmployee? GetUniversityEmployee(UniversityEmployeeSearchModel SearchModel);
	}
}
