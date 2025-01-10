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
	public class GroupStorage : IGroupStorage
	{
		public List<Group> GetFillteredList(GroupSearchModel SearchModel)
		{
			using var context = new DataBaseImplement();
			if (SearchModel.TutorId.HasValue)
			{
				return context.Groups
					.Where(x => x.TutorId == SearchModel.TutorId)
					.Include(x => x.Id)
					.Include(x=> x.Tutor)
					.Include(x=> x.Name)
					.ToList();
			}
			return new();
		}

		public List<Group> GetFullList()
		{
			using var context = new DataBaseImplement();
			return context.Groups
				.Include(x => x.Name)
				.Include(x => x.Tutor)
				.ToList();
		}

		public Group? GetGroup(GroupSearchModel SearchModel)
		{
			using var context = new DataBaseImplement();
			if (SearchModel.Id.HasValue)
			{
				return context.Groups
					.Include(x => x.Name)
					.Include(x => x.Tutor)
					.FirstOrDefault(x => x.Id == SearchModel.Id);
			}
			return null;
		}
	}
}
