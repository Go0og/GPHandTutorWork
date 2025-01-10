using Contracts.BindingModel;
using DataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.StorageContract.dbModels
{
	public class AppointmentHeadman : IAppointmentHeadman
	{
		public int Id { get; set; }
		public int TutorId { get; set; }
		public Tutor? Tutor { get; set; }
		public int StudentId { get; set; }
		public Student? Student { get; set; }
		public static AppointmentHeadman? Create(AppointmentHeadmanBindingModel Model)
		{
			if (Model == null)
			{
				return null;
			}
			return new AppointmentHeadman()
			{
				Id = Model.Id,
				TutorId = Model.TutorId,
				StudentId = Model.StudentId
			};
		}
		public void update(AppointmentHeadmanBindingModel model)
		{
			if (model == null)
			{
				return;
			}
			TutorId = model.TutorId;
			StudentId = model.StudentId;
		}
	}
}
