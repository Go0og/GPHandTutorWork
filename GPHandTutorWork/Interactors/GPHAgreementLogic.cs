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
	public class GPHAgreementLogic : IGPHAgreementLogic
	{
		private readonly IGPHAgreementStorage _storage;

		public GPHAgreementLogic(IGPHAgreementStorage storage)
		{
			_storage = storage;
		}

		public void CheckModel(GPHAgreementBindingModel bindingModel, bool obDel = false, bool onUp = false)
		{
			if (string.IsNullOrEmpty(bindingModel.Id.ToString()))
			{
				throw new ArgumentNullException("GPH id is missing", nameof(bindingModel.Id));
			}
			if (obDel)
			{
				return;
			}
			if (string.IsNullOrEmpty(bindingModel.DateOfConclusion.ToString()) )
			{
				throw new ArgumentNullException("Проверьте дату заключения", nameof(bindingModel.DateOfConclusion));
			}
			if (string.IsNullOrEmpty(bindingModel.DataEnd.ToString()) || bindingModel.DateOfConclusion > bindingModel.DataEnd)
			{
				throw new ArgumentNullException("Проверьте дату окончания", nameof(bindingModel.DataEnd));
			}
			if (string.IsNullOrEmpty(bindingModel.UniversityEmployeeId.ToString()))
			{
				throw new ArgumentNullException("Проверьте сотрудника университета", nameof(bindingModel.UniversityEmployeeId));
			}
			if (string.IsNullOrEmpty(bindingModel.TeacherId.ToString()))
			{
				throw new ArgumentNullException("Проверьте преподавателя", nameof(bindingModel.TeacherId));
			}
			if (string.IsNullOrEmpty(bindingModel.CurriculumId.ToString()))
			{
				throw new ArgumentNullException("Проверьте учебный план", nameof(bindingModel.CurriculumId));
			}
			if (bindingModel.Bet < 0)
			{
				throw new ArgumentNullException("Проверьте ставку", nameof(bindingModel.Bet));
			}
			if (onUp)
			{
				return;
			}
		}

		public bool CreateGPHAgreement(GPHAgreementBindingModel BindingModel)
		{
			CheckModel(BindingModel);
			if (_storage.CreateGPHAgreement(BindingModel) == false)
			{
				throw new Exception("insert operation failed");
			}
			return true;
		}
		public bool UpdateGPHAgreement(GPHAgreementBindingModel BindingModel)
		{
			CheckModel(BindingModel);
			if (_storage.UpdateGPHAgreement(BindingModel) == false)
			{
				throw new Exception("Update operation failed");
			}
			return true;
		}

		public bool DeleteGPHAgreement(GPHAgreementBindingModel BindingModel)
		{
			CheckModel(BindingModel, true);
			if (_storage.DeleteGPHAgreement(BindingModel) == false)
			{
				throw new Exception("Delete operation failed");
			}
			return true;
		}

		public List<GPHAgreementBindingModel> GetFillteredList(GPHAgreementSearchModel? searchModel)
		{
			var models = searchModel == null ? _storage.GetFullList() : _storage.GetFillteredList(searchModel);
			if (models.Count == 0)
			{
				return new();
			}
			List<GPHAgreementBindingModel> bindingModels = new();
			foreach (var model in models)
			{
				bindingModels.Add(getBindingModel(model));
			}
			return bindingModels;
		}

		public GPHAgreementBindingModel? GetGPHAgreement(GPHAgreementSearchModel SearchModel)
		{
			if (SearchModel == null)
			{
				throw new ArgumentNullException(nameof(SearchModel));
			}
			var model = _storage.GetGPHAgreement(SearchModel);
			if (model == null)
			{
				return null;
			}
			return getBindingModel(model);
		}
		public GPHAgreementBindingModel getBindingModel(GPHAgreement model)
		{
			return new()
			{
				Id = model.Id,
				DateOfConclusion = model.DateOfConclusion,
				DataEnd = model.DataEnd,
				CurriculumId = model.CurriculumId,
				TeacherId = model.TeacherId,
				UniversityEmployeeId = model.UniversityEmployeeId,
				Bet = model.Bet,
				IsActive = model.IsActive,

			};
		}
	}
}
