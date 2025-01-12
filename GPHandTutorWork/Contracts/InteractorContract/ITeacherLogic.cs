using Contracts.BindingModel;
using Contracts.SearchModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InteractorContract
{
	public interface ITeacherLogic
	{
		public List<TeacherBindingModel> GetFullList(TeacherSearchModel? SearchModel);
		public TeacherBindingModel? GetTeacher(TeacherSearchModel SearchModel);
	}
}
