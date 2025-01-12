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
	public class AppointmeanHeadmanLogic : IAppointmeanHeadmanLogic
	{
		private readonly IAppointmentHeadmanStorage _storage;
		public AppointmeanHeadmanLogic(IAppointmentHeadmanStorage storage)
		{
			_storage = storage;
		}

		public void CheckModel(AppointmentHeadmanBindingModel BindingModel, bool obDel = false, bool onUp = false)
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
			if (string.IsNullOrEmpty(BindingModel.StudentId.ToString()))
			{
				throw new ArgumentNullException("Student id is missing", nameof(BindingModel.StudentId));
			}
		}

		public bool CreateAppointmentHeadman(AppointmentHeadmanBindingModel BindingModel)
		{
			CheckModel(BindingModel);
			if (_storage.CreateAppointmentHeadman(BindingModel) == false)
			{
				throw new Exception("insert operation failed");
			}
			return true;
		}
		public bool UpdateAppointmentHeadman(AppointmentHeadmanBindingModel BindingModel)
		{
			CheckModel(BindingModel);
			if (_storage.UpdateAppointmentHeadman(BindingModel) == false)
			{
				throw new Exception("Update operation failed");
			}
			return true;
		}

		public bool DeleteAppointmentHeadman(AppointmentHeadmanBindingModel BindingModel)
		{
			CheckModel(BindingModel);
			if (_storage.DeleteAppointmentHeadman(BindingModel) == false)
			{
				throw new Exception("Update operation failed");
			}
			return true;
		}

		public AppointmentHeadmanBindingModel? GetAppointmentHeadman(AppointmentHeadmanSearchModel searchModel)
		{
			if (searchModel == null)
			{
				throw new ArgumentNullException(nameof(searchModel));
			}
			var model = _storage.GetAppointmentHeadman(searchModel);
			if (model == null)
			{
				return null;
			}
			return getBindingModel(model);
		}

		public List<AppointmentHeadmanBindingModel> GetFullList(AppointmentHeadmanSearchModel? searchModel)
		{
			var models = searchModel == null ? _storage.GetFullList() : _storage.GetFillteredList(searchModel);
			if (models.Count == 0)
			{
				return new();
			}
			List<AppointmentHeadmanBindingModel> bindingModels = new();
			foreach (var model in models)
			{
				bindingModels.Add(getBindingModel(model));
			}
			return bindingModels;
		}

		public AppointmentHeadmanBindingModel getBindingModel(AppointmentHeadman model)
		{
			return new()
			{
				Id = model.Id,
				TutorId = model.TutorId,
				StudentId = model.StudentId
			};
		}
	}
}
