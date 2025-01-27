using Contracts.SearchModel;
using Contracts.StorageContract;
using Contracts.StorageContract.dbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseImplement.Implements
{
	public class StudentStorage : IStudentStorage
	{
		public List<Student> GetFillteredList(StudentSearchModel SearchModel)
		{
			using var context = new DataBaseImplement();
			if (SearchModel.GroupId.HasValue)
			{
				return context.Students
					.Where(x => x.GroupId == SearchModel.GroupId)
					.Include(x => x.Gpoup)
					.ToList();
			}
			return new();
		}

		public List<Student> GetFullList()
		{
			using var context = new DataBaseImplement();
			return context.Students
				.Include(x => x.Gpoup)
				.ToList();
		}

		public Student? GetStudent(StudentSearchModel SearchModel)
		{
			using var context = new DataBaseImplement();
			if (SearchModel.Id.HasValue) 
			{
				return context.Students
					.Include(x => x.Gpoup)
					.Include(x => x.FIO)
					.FirstOrDefault(x=>x.Id==SearchModel.Id);
			}
			return null;
		}
	}
}
