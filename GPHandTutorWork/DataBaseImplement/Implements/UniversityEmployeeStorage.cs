using Contracts.BindingModel;
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
	public class UniversityEmployeeStorage : IUniversityEmployeeStorage
	{
		public bool CreateUniversityEmployee(UniversityEmployeeBindingModel Model)
		{
			var NewUniversityEmployee = UniversityEmployee.Create(Model);
			if (NewUniversityEmployee == null)
			{
				return false;
			}
			using var context = new DataBaseImplement();
			context.UniversityEmployees.Add(NewUniversityEmployee);
			context.SaveChanges();
			return true;
		}

		public bool UpdateUniversityEmployee(UniversityEmployeeBindingModel Model)
		{
			using var context = new DataBaseImplement();
			var UpdateUniversityEmployee = context.UniversityEmployees.FirstOrDefault(x => x.Id == Model.Id);
			if (UpdateUniversityEmployee == null)
			{
				return false;
			}
			UpdateUniversityEmployee.update(Model);
			context.SaveChanges();
			return true;
		}

		public bool DeleteUniversityEmployee(UniversityEmployeeBindingModel Model)
		{
			using var context = new DataBaseImplement();
			var DelUniversityEmployee = context.UniversityEmployees.FirstOrDefault(x => x.Id == Model.Id);
			if (DelUniversityEmployee == null)
			{
				return false;
			}
			context.UniversityEmployees.Remove(DelUniversityEmployee);
			context.SaveChanges();
			return true;
		}

		public List<UniversityEmployee> GetFullList()
		{
			using var context = new DataBaseImplement();
			return context.UniversityEmployees.ToList();
		}

		public UniversityEmployee? GetUniversityEmployee(UniversityEmployeeSearchModel SearchModel)
		{
			using var context = new DataBaseImplement();
			if (SearchModel.Id.HasValue)
			{
				return context.UniversityEmployees
					.FirstOrDefault(x => x.Id == SearchModel.Id);
			}
			if (!string.IsNullOrEmpty(SearchModel.FIO))
			{
				return context.UniversityEmployees
					.FirstOrDefault(x => x.FIO == SearchModel.FIO);
			}
			if (!string.IsNullOrEmpty(SearchModel.Login) && !string.IsNullOrEmpty(SearchModel.Password))
			{
				return context.UniversityEmployees
					.FirstOrDefault(x => x.Login == SearchModel.Login && x.Password == SearchModel.Password);
			}
			return null;

		}
	}
}
