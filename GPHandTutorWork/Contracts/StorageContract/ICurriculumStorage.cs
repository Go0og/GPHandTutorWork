using Contracts.SearchModel;
using Contracts.StorageContract.dbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.StorageContract
{
	public interface ICurriculumStorage
	{
		public List<Curriculum> GetFullList();
		public List<Curriculum> GetFillteredList(CurriculumSearchModel SearchModel);
		public Curriculum? GetCurriculum(CurriculumSearchModel SearchModel);
	}
}
