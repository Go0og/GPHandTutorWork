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
	public class OfficialNoteStorage : IOfficialNoteStorage
	{
		public bool CreateOfficialNote(OfficialNoteBindingModel Model)
		{
			using var context = new DataBaseImplement();
			var NewNote = OfficialNote.Create(Model);
			if (NewNote == null)
			{
				return false;
			}
			context.OfficialNotes.Add(NewNote);
			context.SaveChanges();
			return true;
		}

		public bool UpdateOfficialNote(OfficialNoteBindingModel Model)
		{
			using var context = new DataBaseImplement();
			var UpdateNote = context.OfficialNotes.FirstOrDefault(x=>x.Id == Model.Id);
			if (UpdateNote == null)
			{
				return false;
			}
			UpdateNote.Update(Model);
			context.SaveChanges();
			return true;
		}

		public bool DeleteOfficialNote(OfficialNoteBindingModel Model)
		{
			using var context = new DataBaseImplement();
			var DelNote = context.OfficialNotes.FirstOrDefault(x=>x.Id==Model.Id);
			if(DelNote == null)
			{
				return false;
			}
			context.OfficialNotes.Remove(DelNote);
			context.SaveChanges();
			return true;
		}

		public List<OfficialNote> GetFillteredList(OfficialNoteSearchModel SearchModel)
		{
			using var context = new DataBaseImplement();
			if (SearchModel.TutorId.HasValue)
			{
				return context.OfficialNotes
					.Where(x => x.TutorId == SearchModel.TutorId)
					.Include(x => x.Tutor)
					.ToList();
			}
			return new();
		}

		public List<OfficialNote> GetFullList()
		{
			using var context = new DataBaseImplement();
			return context.OfficialNotes
				.Include (x => x.Tutor)
				.ToList();
		}

		public OfficialNote? GetOfficialNote(OfficialNoteSearchModel SearchModel)
		{
			using var context = new DataBaseImplement();
			if (SearchModel.Id.HasValue) { 
				return context.OfficialNotes
					.Include (x => x.Tutor)
					.FirstOrDefault(x => x.Id == SearchModel.Id);
			}
			return null;
		}

	}
}
