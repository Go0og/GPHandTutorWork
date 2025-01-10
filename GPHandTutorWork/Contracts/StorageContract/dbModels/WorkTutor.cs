using Contracts.BindingModel;
using DataModel.Enum;
using DataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.StorageContract.dbModels
{
	public class WorkTutor : IWorkTutor
	{
		public int Id {get; set;}
		public int TutorId {get; set;}
		public Tutor? Tutor {get; set;}

		public TypeWork TypeWork {get; set;}

		public DateTime DateWork {get; set;}

		public static WorkTutor? Create(WorkTutorBindingModel Model)
		{
			if (Model == null)
			{
				return null;
			}
			return new WorkTutor()
			{
				Id = Model.Id,
				TutorId = Model.TutorId,
				TypeWork = Model.TypeWork,
				DateWork = Model.DateWork
			};
		}
	}
}
