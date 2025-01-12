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
	public class GroupLogic : IGroupLogic
	{
		private readonly IGroupStorage _storage;
		public GroupLogic (IGroupStorage storage)
		{
			_storage = storage;
		}
		public List<GroupBindingModel> GetFullList()
		{
			var models = _storage.GetFullList();
			if (models == null)
			{
				return new();
			}
			List<GroupBindingModel> bindingModel = new();
			foreach (var model in models)
			{
				bindingModel.Add(getBindingModel(model));
			}
			return bindingModel;
		}

		public GroupBindingModel? GetGroup(GroupSearchModel SearchModel)
		{
			if(SearchModel == null)
			{
				throw new ArgumentNullException(nameof(SearchModel));
			}
			var model = _storage.GetGroup(SearchModel);
			if (model == null)
			{
				return null;
			}
			return getBindingModel(model);
		}
		public GroupBindingModel getBindingModel(Group model)
		{
			return new()
			{
				Id = model.Id,
				Name = model.Name,
				TutorId = model.TutorId
			};
		}
	}
}
