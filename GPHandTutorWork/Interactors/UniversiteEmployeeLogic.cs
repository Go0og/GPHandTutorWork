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
	public class UniversiteEmployeeLogic : IUniversityEmployeeLogic
	{
		private readonly IUniversityEmployeeStorage _storage;
		public UniversiteEmployeeLogic(IUniversityEmployeeStorage storage)
		{
			_storage = storage;
		}

		public void CheckModel(UniversityEmployeeBindingModel bindingModel, bool obDel=false, bool onUp = false)
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

		public bool CreateUniversityEmployee(UniversityEmployeeBindingModel BindingModel)
		{
			CheckModel(BindingModel);
			if (_storage.CreateUniversityEmployee(BindingModel) == false)
			{
				throw new Exception("insert operation failed");
			}
			return true;
		}

		public bool DeleteUniversityEmployee(UniversityEmployeeBindingModel BindingModel)
		{
			CheckModel(BindingModel);
			if (_storage.DeleteUniversityEmployee(BindingModel) == false)
			{
				throw new Exception("Delete operation failed");
			}
			return true;
		}
		public bool UpdateUniversityEmployee(UniversityEmployeeBindingModel BindingModel)
		{

			CheckModel(BindingModel);
			if (_storage.UpdateUniversityEmployee(BindingModel) == false)
			{
				throw new Exception("Update operation failed");
			}
			return true;
		}
		public List<UniversityEmployeeBindingModel> GetFullList(UniversityEmployeeSearchModel? searchModel)
		{
			var models = searchModel == null ? _storage.GetFullList() : _storage.GetFullList();
			if (models.Count == 0)
			{
				return new();
			}
			List<UniversityEmployeeBindingModel> bindingModels = new();
			foreach (var model in models)
			{
				bindingModels.Add(getBindingModel(model));
			}
			return bindingModels;
		}

		public UniversityEmployeeBindingModel? GetUniversityEmployee(UniversityEmployeeSearchModel SearchModel)
		{
			if (SearchModel == null)
			{
				throw new ArgumentNullException(nameof(SearchModel));
			}
			var model = _storage.GetUniversityEmployee(SearchModel);
			if (model == null)
			{
				return null;
			}
			return getBindingModel(model);
		}

		public UniversityEmployeeBindingModel getBindingModel(UniversityEmployee model)
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
