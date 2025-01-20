using Contracts.InteractorContract;
using Contracts.PresenterContract;
using Contracts.SearchModel;
using Contracts.ViewContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
	public class CurriculumPresenter : ICurriculumPresenter
	{
		private readonly ICurriculumLogic _logic;
		public CurriculumPresenter (ICurriculumLogic logic)
		{
			_logic = logic;
		}
		public List<CurriculumViewModel> MakeCurriculumListPresenter()
		{
			var models = _logic.GetFullList();
			List<CurriculumViewModel> newViewModels = new();
			foreach (var model in models)
			{
				newViewModels.Add(new CurriculumViewModel
				{
					Id = model.Id,
					GroupId = model.GroupId,
					Subject = model.Subject,
					AttestationForm = model.AttestationForm,
					TheoreticalHours = model.TheoreticalHours,
					PracticalHours = model.PracticalHours,
					Exam = model.Exam,
					ConsultationExam = model.ConsultationExam,
					Term = model.Term,
				});
			}
			return newViewModels;
		}

		public CurriculumViewModel MakeCurriculumPresenter(CurriculumSearchModel search_model)
		{
			var model = _logic.GetCurriculum(search_model);
			var newViewModel = new CurriculumViewModel
			{
				Id = model.Id,
				GroupId = model.GroupId,
				Subject = model.Subject,
				AttestationForm = model.AttestationForm,
				TheoreticalHours = model.TheoreticalHours,
				PracticalHours = model.PracticalHours,
				Exam = model.Exam,
				ConsultationExam = model.ConsultationExam,
				Term = model.Term,
			};
			return newViewModel;
		}
	}
}
