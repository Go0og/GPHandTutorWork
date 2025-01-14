using Contracts.BindingModel;
using Contracts.SearchModel;
using Contracts.StorageContract.dbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InteractorContract
{
	public interface IGPHAgreementLogic
	{
		public List<GPHAgreementBindingModel> GetFillteredList(GPHAgreementSearchModel? searchModel);
		public GPHAgreementBindingModel? GetGPHAgreement(GPHAgreementSearchModel SearchModel);
		public bool CreateGPHAgreement(GPHAgreementBindingModel BindingModel);
		public bool UpdateGPHAgreement(GPHAgreementBindingModel BindingModel);
		public bool DeleteGPHAgreement(GPHAgreementBindingModel BindingModel);
		public void CheckModel(GPHAgreementBindingModel bindingModel, bool obDel, bool onUp);
	}
}
