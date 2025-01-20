using Contracts.SearchModel;
using Contracts.ViewContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.PresenterContract
{
	public interface ITeacherPresenter
	{
		public TeacherViewModel MakeTeacherPresenter(TeacherSearchModel search_model);
		public List<TeacherViewModel> MakeTeacherListPresenter(TeacherSearchModel? search_model);
	}
}
