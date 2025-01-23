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
	public class ProgressControlPresenter : IProgressControlPrestnter
	{
		private readonly IProgressControlLogic _logic;
		public ProgressControlPresenter(IProgressControlLogic logic)
		{
			_logic = logic;
		}

		public List<ProgressControlViewModel> MakeProgressControlListPresenter(ProgressControlSearchModel? search_model)
		{
			var models = _logic.GetFullList(search_model);
			List<ProgressControlViewModel> newViewModels = new();

			foreach (var model in models)
			{
				newViewModels.Add(new ProgressControlViewModel
				{
					Id = model.Id,
					CurriculumList = model.CurriculumList,
					StudentId = model.StudentId,
					TeacherId = model.TeacherId,
					DateGrade = model.DateGrade,
					LessonNumber = model.LessonNumber,
					Grade = model.Grade,
				});
			}
			return newViewModels;
		}

		public ProgressControlViewModel MakeProgressControlPresenter(ProgressControlSearchModel search_model)
		{
			var model = _logic.GetProgressControl(search_model);
			var newViewModel = new ProgressControlViewModel
			{
				Id = model.Id,
				CurriculumList = model.CurriculumList,
				StudentId = model.StudentId,
				TeacherId = model.TeacherId,
				DateGrade = model.DateGrade,
				LessonNumber = model.LessonNumber,
				Grade = model.Grade
			};
			return newViewModel;
		}
	}
}
