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
	public class TutorStorage : ITutorStorage
	{
		public bool CreateTutor(TutorBindingModel Model)
		{
			var NewTutor = Tutor.Create(Model);
			if (NewTutor == null)
			{
				return false;
			}
			using var context = new DataBaseImplement();
			context.Tutors.Add(NewTutor);
			context.SaveChanges();
			return true;
		}

		public bool UpdateTutor(TutorBindingModel Model)
		{
			using var context = new DataBaseImplement();
			var UpdateTutor = context.Tutors.FirstOrDefault(x => x.Id == Model.Id);
			if (UpdateTutor == null)
			{
				return false;
			}
			UpdateTutor.update(Model);
			context.SaveChanges();
			return true;
		}

		public bool DeleteTutor(TutorBindingModel Model)
		{
			using var context = new DataBaseImplement();
			var DelTutor = context.Tutors.FirstOrDefault(x=> x.Id == Model.Id);
			if(DelTutor == null)
			{
				return false;
			}
			context.Tutors.Remove(DelTutor);
			context.SaveChanges();
			return true;
		}

		public List<Tutor> GetFullList()
		{
			using var context = new DataBaseImplement();
			return context.Tutors.ToList();
		}

		public Tutor? GetTutor(TutorSearchModel SearchModel)
		{
			using var context = new DataBaseImplement();
			if (SearchModel.Id.HasValue)
			{
				return context.Tutors
					.Include(x => x.FIO)
					.Include(x => x.Login)
					.Include(x => x.Password)
					.FirstOrDefault(x => x.Id == SearchModel.Id);
			}
			if (!string.IsNullOrEmpty(SearchModel.FIO))
			{
				return context.Tutors
					.Include(x => x.FIO)
					.Include(x => x.Login)
					.Include(x => x.Password)
					.FirstOrDefault(x => x.FIO == SearchModel.FIO);
			}
			return null;
		}

		public List<Tutor> GetFillteredList(TutorSearchModel searchModel)
		{
			using var context = new DataBaseImplement();
			if (searchModel.Id.HasValue) 
			{ 
				return context.Tutors
					.Where(x => x.Id == searchModel.Id)
					.ToList();
			}
			return new();
		}
	}
}
