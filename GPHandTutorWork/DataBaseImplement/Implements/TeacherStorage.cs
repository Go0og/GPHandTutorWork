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
	public class TeacherStorage : ITeacherStorage
	{
		public List<Teacher> GetFillteredList(TeacherSearchModel SearchModel)
		{
			using var context = new DataBaseImplement();
			if (SearchModel.Id.HasValue)
			{
				return context.Teachers
					.Where(x => x.Id == SearchModel.Id)
					.Include(x => x.FIO)
					.Include(x => x.DateOfBirth)
					.Include(x => x.PassportSerialAndNumber)
					.Include(x => x.ContactPhoneNumber)
					.Include(x => x.INN)
					.Include(x => x.InsuranceNumber)
					.Include(x => x.CardDetails)
					.ToList();
			}
			return new();
		}

		public List<Teacher> GetFullList()
		{
			using var context = new DataBaseImplement();
			return context.Teachers.ToList();
		}

		public Teacher? GetTeacher(TeacherSearchModel SearchModel)
		{
			using var context = new DataBaseImplement();
			if (SearchModel.Id.HasValue)
			{
				return context.Teachers
					.FirstOrDefault(x => x.Id == SearchModel.Id);
			}
			return null;
		}
	}
}
