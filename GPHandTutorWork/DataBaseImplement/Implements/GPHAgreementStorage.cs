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
	public class GPHAgreementStorage : IGPHAgreementStorage
	{
		public bool CreateGPHAgreement(GPHAgreementBindingModel Model)
		{
			using var context = new DataBaseImplement();
			var NewGPH = GPHAgreement.Create(Model);
			if (NewGPH == null) { 
				return false;
			}
			context.GPHAgreements.Add(NewGPH);
			context.SaveChanges();
			return true;
		}
		public bool UpdateGPHAgreement(GPHAgreementBindingModel Model)
		{
			using var context = new DataBaseImplement();
			var UpdateGPH = context.GPHAgreements.FirstOrDefault(x=> x.Id == Model.Id);
			if (UpdateGPH == null) {
				return false; 
			}
			UpdateGPH.Update(Model);
			context.SaveChanges();
			return true;
		}

		public bool DeleteGPHAgreement(GPHAgreementBindingModel Model)
		{
			using var context = new DataBaseImplement();
			var DelGPH = context.GPHAgreements.FirstOrDefault(x=> x.Id == Model.Id);
			if (DelGPH == null)
			{
				return false;
			}
			context.GPHAgreements.Remove(DelGPH);
			context.SaveChanges();
			return true;
		}

		public List<GPHAgreement> GetFillteredList(GPHAgreementSearchModel SearchModel)
		{
			using var context = new DataBaseImplement();
			if (SearchModel.DataEnd.HasValue && SearchModel.DateOfConclusion.HasValue && SearchModel.TeacherId.HasValue)
			{
				return context.GPHAgreements
					.Where(x => x.DataEnd <= SearchModel.DataEnd && x.DateOfConclusion >= SearchModel.DateOfConclusion && x.TeacherId == SearchModel.TeacherId)
					.Include(x => x.Curriculum)
					.Include(x => x.UniversityEmployee)
					.Include(x => x.Teacher)
					.ToList();
			}
			if (SearchModel.DataEnd.HasValue && SearchModel.DateOfConclusion.HasValue && SearchModel.UniversityEmployeeId.HasValue)
			{
				return context.GPHAgreements
					.Where(x => x.DataEnd <= SearchModel.DataEnd && x.DateOfConclusion >= SearchModel.DateOfConclusion && x.UniversityEmployeeId == SearchModel.UniversityEmployeeId)
					.Include(x => x.Curriculum)
					.Include(x => x.UniversityEmployee)
					.Include(x => x.Teacher)
					.ToList();
			}
			if (SearchModel.DataEnd.HasValue && SearchModel.DateOfConclusion.HasValue)
			{
				return context.GPHAgreements
					.Where(x => x.DataEnd == SearchModel.DataEnd && x.DateOfConclusion == SearchModel.DateOfConclusion)
					.Include(x => x.Curriculum)
					.Include(x => x.UniversityEmployee)
					.Include(x => x.Teacher)
					.ToList();
			}
			else if (SearchModel.DataEnd.HasValue)
			{
				return context.GPHAgreements
					.Where(x => x.DataEnd == SearchModel.DataEnd)
					.Include(x => x.Curriculum)
					.Include (x => x.UniversityEmployee)
					.Include(x=>x.Teacher)
					.ToList();
			}
			else if (SearchModel.DateOfConclusion.HasValue)
			{
				return context.GPHAgreements
					.Where(x => x.DateOfConclusion == SearchModel.DateOfConclusion)
					.Include(x => x.Curriculum)
					.Include(x => x.UniversityEmployee)
					.Include(x => x.Teacher)
					.ToList();
			}
			if(SearchModel.UniversityEmployeeId.HasValue)
			{
				return context.GPHAgreements
					.Where(x => x.UniversityEmployeeId == SearchModel.UniversityEmployeeId)
					.Include(x => x.Curriculum)
					.Include(x => x.UniversityEmployee)
					.Include(x => x.Teacher)
					.ToList();
			}
			return new();
		}

		public List<GPHAgreement> GetFullList()
		{
			using var context = new DataBaseImplement();
			return context.GPHAgreements.ToList();
		}

		public GPHAgreement? GetGPHAgreement(GPHAgreementSearchModel SearchModel)
		{
			using var context = new DataBaseImplement();
			if (SearchModel.Id.HasValue)
			{
				return context.GPHAgreements
					.Include(x => x.Curriculum)
					.Include(x => x.UniversityEmployee)
					.Include(x => x.Teacher)
					.FirstOrDefault(x => x.Id == SearchModel.Id);
			}
			return null;
		}
	}
}
