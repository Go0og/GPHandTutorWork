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
	public class OfficialNoteLogic : IOfficialNoteLogic
	{
		private readonly IOfficialNoteStorage _storage;
		public OfficialNoteLogic (IOfficialNoteStorage storage)
		{
			_storage = storage;
		}
		public void CheckModel(OfficialNoteBindingModel BindingModel, bool obDel = false, bool onUp = false)
		{
			if (string.IsNullOrEmpty(BindingModel.Id.ToString()))
			{
				throw new ArgumentNullException("user id is missing", nameof(BindingModel.Id));
			}
			if (obDel)
			{
				return;
			}
			if (string.IsNullOrEmpty(BindingModel.TutorId.ToString()))
			{
				throw new ArgumentNullException("Tutor id is missing", nameof(BindingModel.TutorId));
			}
			if (string.IsNullOrEmpty(BindingModel.Comment))
			{
				throw new ArgumentNullException("Comment is missing", nameof(BindingModel.Comment));
			}
		}

		public bool CreateOfficialNote(OfficialNoteBindingModel BindingModel)
		{
			CheckModel(BindingModel);
			if (_storage.CreateOfficialNote(BindingModel))
			{
				throw new Exception("insert operation failed");
			}
			return true;
		}
		public bool UpdateOfficialNote(OfficialNoteBindingModel BindingModel)
		{
			CheckModel(BindingModel);
			if (_storage.UpdateOfficialNote(BindingModel))
			{
				throw new Exception("insert operation failed");
			}
			return true;
		}

		public bool DeleteOfficialNote(OfficialNoteBindingModel BindingModel)
		{
			CheckModel(BindingModel);
			if (_storage.DeleteOfficialNote(BindingModel))
			{
				throw new Exception("insert operation failed");
			}
			return true;
		}

		public List<OfficialNoteBindingModel> GetFullList(OfficialNoteSearchModel? searchModel)
		{
			var models = searchModel == null ? _storage.GetFullList() : _storage.GetFillteredList(searchModel);
			if (models.Count == 0)
			{
				return new();
			}
			List<OfficialNoteBindingModel> bindingModels = new();
			foreach (var model in models)
			{
				bindingModels.Add(getBindingModel(model));
			}
			return bindingModels;
		}

		public OfficialNoteBindingModel? GetOfficialNote(OfficialNoteSearchModel searchModel)
		{
			if (searchModel == null)
			{
				throw new ArgumentNullException(nameof(searchModel));
			}

			var model = _storage.GetOfficialNote(searchModel);
			if (model == null)
			{
				return null;
			}
			return getBindingModel(model);
		}
		public OfficialNoteBindingModel getBindingModel(OfficialNote model)
		{
			return new()
			{
				Id = model.Id,
				TutorId = model.TutorId,
				Comment = model.Comment
			};
		}
	}
}
