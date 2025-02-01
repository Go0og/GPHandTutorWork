using Contracts.BindingModel;
using Contracts.InteractorContract;
using Contracts.SearchModel;
using Contracts.StorageContract;
using Contracts.StorageContract.dbModels;
using DataModel.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactors
{
	public class ProgressControlLogic : IProgressControlLogic
	{
		private readonly IProgressControlStorage _storage;
		private readonly IWorkTutorLogic _workTutorLogic;
		public ProgressControlLogic (IProgressControlStorage storage, IWorkTutorLogic workTutorLogic)
		{
			_storage = storage;
			_workTutorLogic = workTutorLogic;
		}
		public List<ProgressControlBindingModel> GetFullList()
		{
			var models = _storage.GetFullList();
			if (models.Count == 0)
			{
				return new();
			}
			List<ProgressControlBindingModel> bindingModels = new();
			foreach (var model in models)
			{
				bindingModels.Add(getBindingModel(model));
			}
			return bindingModels;
		}

		public List<ProgressControlBindingModel> GetFillteredList(ProgressControlSearchModel SearchModel)
		{
			var models = SearchModel == null ? _storage.GetFullList() : _storage.GetFillteredList(SearchModel);
			if (models.Count == 0)
			{
				return new();
			}
			List<ProgressControlBindingModel> bindingModels = new();
			foreach (var model in models)
			{
				bindingModels.Add(getBindingModel(model));
			}

			return bindingModels;
		}
		public ProgressControlBindingModel? GetProgressControl(ProgressControlSearchModel SearchModel)
		{
			{
				if (SearchModel == null)
				{
					throw new ArgumentNullException(nameof(SearchModel));
				}
				var model = _storage.GetProgressControl(SearchModel);
				if (model == null)
				{
					return null;
				}
				return getBindingModel(model);
			}
		}
		public ProgressControlBindingModel getBindingModel(ProgressControl model)
		{
			return new()
			{
				Id = model.Id,
				CurriculumId = model.CurriculumId,
				StudentId = model.StudentId,
				TeacherId = model.TeacherId,
				DateGrade = model.DateGrade,
				Grade = model.Grade
			};
		}

	}
}
