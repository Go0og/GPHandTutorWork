using Contracts.SearchModel;
using Contracts.ViewContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.PresenterContract
{
	public interface IStudentPrestnter
	{
		public StudentViewModel MakeStudentPresenter(StudentSearchModel search_model);

		public List<StudentViewModel> MakeStudentListPresenter(StudentSearchModel? search_model);
	}
}
