using Contracts.InteractorContract;
using Contracts.PresenterContract;
using Contracts.SearchModel;
using Contracts.StorageContract;
using Contracts.ViewContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenters
{
	public class CurriculumPresenter : ICurriculumPresenter
	{
		private readonly ICurriculumLogic _logic;
		private readonly IGroupStorage _groupStorage;
		public CurriculumPresenter (ICurriculumLogic logic, IGroupStorage groupStorage)
		{
			_logic = logic;
			_groupStorage = groupStorage;
		}

		public List<GroupViewModel> groupViewModels(CurriculumSearchModel search_model)
		{
			var subjects = _logic.GetFillteredList(search_model);
			var ListGroups = _groupStorage.GetFullList();
			List<GroupViewModel> Result = new();
			foreach (var subject in subjects)
			{
				var group = _groupStorage.GetGroup(new GroupSearchModel { Id = subject.GroupId });
				if (group != null) 
				{
					Result.Add(new GroupViewModel
					{
						Id = group.Id,
						Name = group.Name,
						TutorId = group.TutorId,
					});
				}
			}
			return Result;
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
