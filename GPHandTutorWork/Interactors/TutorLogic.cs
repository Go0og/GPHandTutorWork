using Contracts.BindingModel;
using Contracts.InteractorContract;
using Contracts.SearchModel;
using Contracts.StorageContract.dbModels;
using DataBaseImplement.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactors
{
	public class TutorLogic : ITutorLogic
	{
		private readonly TutorStorage _storage;
		public TutorLogic (TutorStorage storage)
		{
			_storage = storage;
		}
		public void CheckModel(TutorBindingModel bindingModel, bool obDel = false, bool onUp = false)
		{
			if (string.IsNullOrEmpty(bindingModel.Id.ToString()))
			{
				throw new ArgumentNullException("Id is missing", nameof(bindingModel.Id));
			}
			if (obDel)
			{
				return;
			}
			if (string.IsNullOrEmpty(bindingModel.FIO))
			{
				throw new ArgumentNullException("FIO is missing", nameof(bindingModel.FIO));
			}
			if (string.IsNullOrEmpty(bindingModel.Login))
			{
				throw new ArgumentNullException("Login is missing", nameof(bindingModel.Login));
			}
			if (string.IsNullOrEmpty(bindingModel.Password))
			{
				throw new ArgumentNullException("Login is missing", nameof(bindingModel.Password));
			}
		}

		public bool CreateTutor(TutorBindingModel BindingModel)
		{
			if (_storage.CreateTutor(BindingModel) == false)
			{
				throw new Exception("insert operation failed");
			}
			return true;
		}

		public bool UpdateTutor(TutorBindingModel BindingModel)
		{
			CheckModel(BindingModel);
			if (_storage.UpdateTutor(BindingModel) == false)
			{
				throw new Exception("Update operation failed");
			}
			return true;
		}
		public bool DeleteTutor(TutorBindingModel BindingModel)
		{
			CheckModel(BindingModel, true);
			if (_storage.DeleteTutor(BindingModel) == false)
			{
				throw new Exception("Delete operation failed");
			}
			return true;
		}

		public List<TutorBindingModel> GetFullList(TutorSearchModel? searchModel)
		{
			var models = searchModel == null ? _storage.GetFullList() : _storage.GetFillteredList(searchModel);
			if (models.Count == 0)
			{
				return new();
			}
			List<TutorBindingModel> bindingModels = new();
			foreach (var model in models)
			{
				bindingModels.Add(getBindingModel(model));
			}
			return bindingModels;
		}

		public TutorBindingModel? GetTutor(TutorSearchModel SearchModel)
		{
			if (SearchModel == null)
			{
				throw new ArgumentNullException(nameof(SearchModel));
			}
			var model = _storage.GetTutor(SearchModel);
			if (model == null)
			{
				return null;
			}
			return getBindingModel(model);
		}

		public TutorBindingModel getBindingModel(Tutor model)
		{
			return new()
			{
				Id = model.Id,
				FIO = model.FIO,
				Login = model.Login,
				Password = model.Password
			};
		}
	}
}
