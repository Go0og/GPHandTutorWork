using Contracts.BindingModel;
using Contracts.SearchModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InteractorContract
{
	public interface IStudentLogic
	{
		public List<StudentBindingModel> GetFullList(StudentSearchModel? SearchModel);
		public StudentBindingModel? GetStudent(StudentSearchModel SearchModel);
	}
}
