using Contracts.BindingModel;
using Contracts.SearchModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InteractorContract
{
	public interface IUniversityEmployeeLogic
	{
		public List<UniversityEmployeeBindingModel> GetFullList(UniversityEmployeeSearchModel? searchModel);
		public UniversityEmployeeBindingModel? GetUniversityEmployee(UniversityEmployeeSearchModel SearchModel);
		public bool CreateUniversityEmployee(UniversityEmployeeBindingModel BindingModel);
		public bool UpdateUniversityEmployee(UniversityEmployeeBindingModel BindingModel);
		public bool DeleteUniversityEmployee(UniversityEmployeeBindingModel BindingModel);
		public void CheckModel(UniversityEmployeeBindingModel bindingModel, bool obDel, bool onUp);
	}
}
