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
		private readonly AbstractWordTeacherGPH _saveGPHToWord;

		public ReportEmployeeLogic(AbstractWordTeacherGPH abstractWordTeacherGPH, IGPHAgreementStorage gPHAgreementStorage, ITeacherStorage teacherStorage, ICurriculumStorage curriumStorage)
		{
			_gphStorage = gPHAgreementStorage;
			_saveGPHToWord = abstractWordTeacherGPH;
			_teacherStorage = teacherStorage;
			_curriumStorage = curriumStorage;
		}

		public byte[]? SaveGPHToWordFile(List<GPHAgreementViewModel> model)
		{
			var teacher =_teacherStorage.GetTeacher(new TeacherSearchModel
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
			var document = _saveGPHToWord.CreateDoc(new WordTeacherGPH
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
