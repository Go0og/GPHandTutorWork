using Contracts.InteractorContract;
using Contracts.SearchModel;
using Contracts.StorageContract;
using Contracts.StorageContract.dbModels;
using Contracts.ViewContract;
using Interactors.OfficePackage;
using Interactors.OfficePackage.Helpermodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactors
{
	public class ReportEmployeeLogic : IReportEmployeeLogic
	{
		private readonly ITeacherStorage _teacherStorage;
		private readonly ICurriculumStorage _curriumStorage;
		private readonly IGPHAgreementStorage _gphStorage;
		private readonly AbstractEmployeeGPHWord _saveEmployeeToWord;
		private readonly AbstractWordTeacherGPH _abstractWordTeacherGPH;

		public ReportEmployeeLogic(AbstractEmployeeGPHWord abstractEmployeeGPHWord, ITeacherStorage teacherStorage, ICurriculumStorage curriumStorage, IGPHAgreementStorage agreementStorage, AbstractWordTeacherGPH abstractWordTeacherGPH)
		{
			_saveEmployeeToWord = abstractEmployeeGPHWord;
			_teacherStorage = teacherStorage;
			_curriumStorage = curriumStorage;
			_gphStorage = agreementStorage;
			_abstractWordTeacherGPH = abstractWordTeacherGPH;
		}

		public byte[]? SaveEmployeeWorkToWordFile(List<GPHAgreementViewModel> models)
		{
			List<Curriculum> CurriculumList = new();
			List<Teacher> TeacherList = new();
			List<GPHAgreement> GPHList = new();
			foreach (var data in models)
			{
				CurriculumList.Add(_curriumStorage.GetCurriculum(new CurriculumSearchModel
				{
					Id = data.CurriculumId,
				}));
				GPHList.Add(_gphStorage.GetGPHAgreement(new GPHAgreementSearchModel { Id = data.Id }));
				TeacherList.Add(_teacherStorage.GetTeacher(new TeacherSearchModel { Id = data.TeacherId }));
			}
			var document = _saveEmployeeToWord.CreateDoc(new WordEmployeeGPH
			{
				Title = "ГПХ",
				Teacher = TeacherList,
				CurriculumList = CurriculumList,
				GPH =GPHList,
			});

			return document;
		}

		public byte[]? SaveGPHToWordFile(List<GPHAgreementViewModel> model)
		{
			var teacher = _teacherStorage.GetTeacher(new TeacherSearchModel
			{
				Id = model.First().TeacherId,
			});
			List<Curriculum> CurriculumList = new();
			List<GPHAgreement> GPHAgreementList = new();
			foreach (var data in model)
			{
				CurriculumList.Add(_curriumStorage.GetCurriculum(new CurriculumSearchModel
				{
					Id = data.CurriculumId,
				}));

				GPHAgreementList.Add(_gphStorage.GetGPHAgreement(new GPHAgreementSearchModel
				{
					Id = data.Id,
				}));

			}
			var document = _abstractWordTeacherGPH.CreateDoc(new WordTeacherGPH
			{
				Title = "ГПХ",
				Teacher = teacher,
				CurriculumList = CurriculumList,
				GPHAgreement = GPHAgreementList
			});

			return document;
		}




	}
}
