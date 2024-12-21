using Contracts.SearchModel;
using Contracts.StorageContract.dbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.StorageContract
{
	public interface IGPHAgreementStorage
	{
		public List<IGPHAgreementStorage> GetFullList();
		public List<IGPHAgreementStorage> GetFillteredList(GPHAgreementSearchModel SearchModel);
		public IGPHAgreementStorage? GetGPHAgreement(GPHAgreementSearchModel SearchModel);
	}
}
