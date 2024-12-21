using Contracts.SearchModel;
using Contracts.StorageContract.dbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.StorageContract
{
	public interface ITeacherStorage
	{
		public List<Teacher> GetFullList();
		public List<Teacher> GetFillteredList(TeacherSearchModel SearchModel);
		public Teacher? GetTeacher(TeacherSearchModel SearchModel);
	}
}
