using Contracts.SearchModel;
using Contracts.StorageContract.dbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.StorageContract
{
	public interface IStudentStorage
	{
		public List<Student> GetFullList();
		public List<Student> GetFillteredList(StudentSearchModel SearchModel);
		public Student? GetStudent(StudentSearchModel SearchModel);
	}
}
