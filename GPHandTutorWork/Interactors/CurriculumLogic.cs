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
	public class CurriculumLogic : ICurriculumLogic
	{
		private readonly ICurriculumStorage _storage;
		public CurriculumLogic (ICurriculumStorage storage)
		{
			_storage = storage;
		}

		public CurriculumBindingModel? GetCurriculum(CurriculumSearchModel SearchModel)
		{
			if (SearchModel == null)
			{
				throw new ArgumentNullException(nameof(SearchModel));
			}
			var model = _storage.GetCurriculum(SearchModel);
			if (model == null)
			{
				return null;
			}
			return getBindingModel(model);
		}

		public List<CurriculumBindingModel> GetFullList()
		{
			var models = _storage.GetFullList();
			if (models.Count == 0)
			{
				return new();
			}
			List<CurriculumBindingModel> bindingModels = new();
			foreach (var model in models)
			{
				bindingModels.Add(getBindingModel(model));
			}
			return bindingModels;
		}
		public CurriculumBindingModel getBindingModel(Curriculum model)
		{
			return new()
			{
				Id = model.Id,
				Subject = model.Subject,
				AttestationForm = model.AttestationForm,
				TheoreticalHours = model.TheoreticalHours,
				PracticalHours = model.PracticalHours,
				Exam = model.Exam,
				ConsultationExam = model.ConsultationExam,
				Term = model.Term,
				GroupId = model.GroupId
			};
		}
	}
}
