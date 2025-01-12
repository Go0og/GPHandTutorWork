using Contracts.BindingModel;
using Contracts.SearchModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InteractorContract
{
	public interface ITutorLogic
	{
		public List<TutorBindingModel> GetFullList(TutorSearchModel? searchModel);
		public TutorBindingModel? GetTutor(TutorSearchModel SearchModel);
		public bool CreateTutor(TutorBindingModel TutorBindingModel);
		public bool UpdateTutor(TutorBindingModel TutorBindingModel);
		public bool DeleteTutor(TutorBindingModel TutorBindingModel);
		public void CheckModel(TutorBindingModel bindingModel, bool obDel, bool onUp);
	}
}
