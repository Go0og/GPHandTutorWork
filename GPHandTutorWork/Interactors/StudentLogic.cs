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
	public class StudentLogic : IStudentLogic
	{
		private readonly IStudentStorage _storage;
		public StudentLogic(IStudentStorage storage)
		{
			_storage = storage;
		}

		public List<StudentBindingModel> GetFullList(StudentSearchModel? SearchModel)
		{
			var models = _storage.GetFillteredList(SearchModel);
			if (models == null)
			{
				return new();
			}
			List<StudentBindingModel> bindingModel = new();
			foreach (var model in models)
			{
				bindingModel.Add(getBindingModel(model));
			}
			return bindingModel;
		}

		public StudentBindingModel GetStudent(StudentSearchModel SearchModel)
		{
			if (SearchModel == null)
			{
				throw new ArgumentNullException(nameof(SearchModel));
			}
			var model = _storage.GetStudent(SearchModel);
			if (model == null)
			{
				return null;
			}
			return getBindingModel(model);
		}
		public StudentBindingModel getBindingModel(Student model)
		{
			return new()
			{
				Id = model.Id,
				FIO = model.FIO,
				GroupId = model.GroupId
			};
		}
	}
}
