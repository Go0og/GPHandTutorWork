using Contracts.BindingModel;
using Contracts.SearchModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InteractorContract
{
	public interface IWorkTutorLogic
	{
		public List<WorkTutorBindingModel> GetFullList(WorkTutorSearchModel? searchModel);
		public WorkTutorBindingModel? GetWorkTutor(WorkTutorSearchModel SearchModel);
		public bool CreateWorkTutor(WorkTutorBindingModel BindingModel);
		public bool UpdateWorkTutor(WorkTutorBindingModel BindingModel);
		public bool DeleteWorkTutor(WorkTutorBindingModel BindingModel);
		public void CheckModel(WorkTutorBindingModel bindingModel, bool obDel, bool onUp);
	}
}
