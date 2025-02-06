using Contracts.BindingModel;
using Contracts.InteractorContract;
using Contracts.SearchModel;
using Contracts.StorageContract;
using Contracts.StorageContract.dbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactors
{
	public class WorkTutorLogic : IWorkTutorLogic
	{
		private readonly IWorkTutorStorage _storage;
		public WorkTutorLogic(IWorkTutorStorage storage)
		{
			_storage = storage;
		}

		public void CheckModel(WorkTutorBindingModel bindingModel, bool obDel= false, bool onUp=false)
		{
			if (string.IsNullOrEmpty(bindingModel.Id.ToString()))
			{
				throw new ArgumentNullException("Id is missing", nameof(bindingModel.Id));
			}
			if (obDel)
			{
				return;
			}
			if (string.IsNullOrEmpty(bindingModel.TutorId.ToString()))
			{
				throw new ArgumentNullException("TutorID is missing", nameof(bindingModel.TutorId));
			}
			if (string.IsNullOrEmpty(bindingModel.DateWork.ToString()))
			{
				throw new ArgumentNullException("Date is missing", nameof(bindingModel.DateWork));
			}
			if (string.IsNullOrEmpty(bindingModel.TypeWork.ToString()))
			{
				throw new ArgumentNullException("TypeWork is missing", nameof(bindingModel.TypeWork));
			}
		}

		public bool CreateWorkTutor(WorkTutorBindingModel BindingModel)
		{
			CheckModel(BindingModel);
			if (_storage.CreateWork(BindingModel) == false)
			{
				throw new Exception("insert operation failed");
			}
			return true;
		}

		public List<WorkTutorBindingModel> GetFillteredList(WorkTutorSearchModel? searchModel)
		{
			var models = searchModel == null ? _storage.GetFullList() : _storage.GetFillteredList(searchModel);
			if (models.Count == 0)
			{
				return new();
			}
			List<WorkTutorBindingModel> bindingModels = new();
			foreach (var model in models)
			{
				bindingModels.Add(getBindingModel(model));
			}
			return bindingModels;
		}

		public WorkTutorBindingModel? GetWorkTutor(WorkTutorSearchModel SearchModel)
		{
			if (SearchModel == null)
			{
				throw new ArgumentNullException(nameof(SearchModel));
			}
			var model = _storage.GetWorkTutor(SearchModel);
			if (model == null)
			{
				return null;
			}
			return getBindingModel(model);
		}

		public WorkTutorBindingModel getBindingModel(WorkTutor model)
		{
			return new()
			{
				Id = model.Id,
				TutorId = model.TutorId,
				DateWork = model.DateWork,
				TypeWork = model.TypeWork,
			};
		}
	}
}
