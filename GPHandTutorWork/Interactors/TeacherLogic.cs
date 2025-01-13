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
	public class TeacherLogic : ITeacherLogic
	{
		private readonly ITeacherStorage _storage;
		public TeacherLogic (ITeacherStorage storage)
		{
			_storage = storage;
		}
		public List<TeacherBindingModel> GetFullList(TeacherSearchModel? SearchModel)
		{
			var models = _storage.GetFullList();
			if (models == null)
			{
				return new();
			}
			List<TeacherBindingModel> bindingModel = new();
			foreach (var model in models)
			{
				bindingModel.Add(getBindingModel(model));
			}
			return bindingModel;
		}

		public TeacherBindingModel? GetTeacher(TeacherSearchModel SearchModel)
		{
			if (SearchModel == null)
			{
				throw new ArgumentNullException(nameof(SearchModel));
			}
			var model = _storage.GetTeacher(SearchModel);
			if (model == null)
			{
				return null;
			}
			return getBindingModel(model);
		}
		public TeacherBindingModel getBindingModel(Teacher model)
		{
			return new()
			{
				Id = model.Id,
				FIO = model.FIO,
				DateOfBirth = model.DateOfBirth,
				PassportSerialAndNumber = model.PassportSerialAndNumber,
				ContactPhoneNumber = model.ContactPhoneNumber,
				INN = model.INN,
				InsuranceNumber = model.InsuranceNumber,
				CardDetails = model.CardDetails
			};
		}
	}
}
