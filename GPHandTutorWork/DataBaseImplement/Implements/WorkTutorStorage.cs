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
	public class WorkTutorStorage : IWorkTutorStorage
	{
		public bool CreateWork(WorkTutorBindingModel Model)
		{
			using var context = new DataBaseImplement();
			var NewWork = WorkTutor.Create(Model);
			if (NewWork == null)
			{
				return false;
			}
			context.WorkTutors.Add(NewWork);
			context.SaveChanges();
			return true;
		}

		public List<WorkTutor> GetFillteredList(WorkTutorSearchModel SearchModel)
		{
			using var context = new DataBaseImplement();
			if (SearchModel.TutorId.HasValue)
			{
				return context.WorkTutors
					.Where(x=> x.TutorId == SearchModel.TutorId)
					.Include(x=> x.Tutor)
					.Include (x=> x.TypeWork)
					.Include (x => x.DateWork)
					.ToList();
			}
			return new();
		}

		public List<WorkTutor> GetFullList()
		{
			using var context = new DataBaseImplement();
			return context.WorkTutors.ToList();
		}

		public WorkTutor? GetWorkTutor(WorkTutorSearchModel SearchModel)
		{
			using var context = new DataBaseImplement();
			if (SearchModel.Id.HasValue)
			{
				return context.WorkTutors
					.Include(x => x.Tutor)
					.Include(x => x.TypeWork)
					.Include(x => x.DateWork)
					.FirstOrDefault(x => x.Id == SearchModel.Id);
			}
			return null;
		}
	}
}
