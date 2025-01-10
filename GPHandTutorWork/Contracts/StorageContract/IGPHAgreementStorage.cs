using Contracts.BindingModel;
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
		public List<GPHAgreement> GetFullList();
		public List<GPHAgreement> GetFillteredList(GPHAgreementSearchModel SearchModel);
		public GPHAgreement? GetGPHAgreement(GPHAgreementSearchModel SearchModel);
		public bool CreateGPHAgreement(GPHAgreementBindingModel GPHAgreementBindingModel);
		public bool UpdateGPHAgreement(GPHAgreementBindingModel GPHAgreementBindingModel);
		public bool DeleteGPHAgreement(GPHAgreementBindingModel GPHAgreementBindingModel);
	}
}
