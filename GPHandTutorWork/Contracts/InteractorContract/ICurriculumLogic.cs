using Contracts.BindingModel;
using Contracts.SearchModel;
using Contracts.StorageContract.dbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InteractorContract
{
	public interface ICurriculumLogic
	{
		public List<CurriculumBindingModel> GetFullList(CurriculumSearchModel? searchModel);
		public CurriculumBindingModel? GetCurriculum(CurriculumSearchModel SearchModel);
	}
}
