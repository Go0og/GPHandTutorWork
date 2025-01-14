using Contracts.BindingModel;
using Contracts.InteractorContract;
using Contracts.SearchModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactors
{
	public class UniversiteEmployeeLogic : IUniversityEmployeeLogic
	{
		public void CheckModel(UniversityEmployeeBindingModel bindingModel, bool obDel, bool onUp)
		{
			throw new NotImplementedException();
		}

		public bool CreateUniversityEmployee(UniversityEmployeeBindingModel BindingModel)
		{
			throw new NotImplementedException();
		}

		public bool DeleteUniversityEmployee(UniversityEmployeeBindingModel BindingModel)
		{
			throw new NotImplementedException();
		}

		public List<UniversityEmployeeBindingModel> GetFullList(UniversityEmployeeSearchModel? searchModel)
		{
			throw new NotImplementedException();
		}

		public UniversityEmployeeBindingModel? GetUniversityEmployee(UniversityEmployeeSearchModel SearchModel)
		{
			throw new NotImplementedException();
		}

		public bool UpdateUniversityEmployee(UniversityEmployeeBindingModel BindingModel)
		{
			throw new NotImplementedException();
		}
	}
}
