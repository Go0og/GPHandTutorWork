using Contracts.BindingModel;
using DataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.StorageContract.dbModels
{
	public class OfficialNote : IOfficialNote
	{
		public int Id {get; set;}
		public int TutorId {get; set;}
		public Tutor? Tutor {get; set;}

		public string Comment { get; set;} = string.Empty;
		public static OfficialNote? Create(OfficialNoteBindingModel Model)
		{
			if (Model == null)
			{
				return null;
			}
			return new OfficialNote()
			{
				Id = Model.Id,
				TutorId = Model.TutorId,
				Comment = Model.Comment
			};
		}
		public void Update(OfficialNoteBindingModel Model)
		{
			if (Model == null)
			{
				return;
			}
			Id = Model.Id;
			TutorId = Model.TutorId;
			Comment = Model.Comment;
		}
	}
}
