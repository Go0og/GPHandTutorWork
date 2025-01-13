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
	public interface ITutorStorage
	{
		public List<Tutor> GetFullList();
		public List<Tutor> GetFillteredList(TutorSearchModel searchModel);
		public Tutor? GetTutor(TutorSearchModel SearchModel);
		public bool CreateTutor(TutorBindingModel tutorBindingModel);
		public bool UpdateTutor(TutorBindingModel tutorBindingModel);
		public bool DeleteTutor(TutorBindingModel tutorBindingModel);
	}
}
