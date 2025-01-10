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
	public class ProgressControlStorage : IProgressControlStorage
	{
		public List<ProgressControl> GetFillteredList(ProgressControlSearchModel SearchModel)
		{
			using var context = new DataBaseImplement();
			if (SearchModel.StudentId.HasValue)
			{
				return context.ProgressControls
					.Where(x=> x.StudentId==SearchModel.StudentId)
					.Include(x => x.Student)
					.Include(x => x.Curriculum)
					.ToList();
			}
			return new();
		}

		public List<ProgressControl> GetFullList()
		{
			using var context = new DataBaseImplement();
			return context.ProgressControls.ToList();
		}

		public ProgressControl? GetProgressControl(ProgressControlSearchModel SearchModel)
		{
			using var context = new DataBaseImplement();
			if (SearchModel.Id.HasValue)
			{
				return context.ProgressControls
					.Include(x => x.Student)
					.Include(x => x.Curriculum)
					.FirstOrDefault(x => x.Id == SearchModel.Id);
			}
			return null;
		}
	}
}
