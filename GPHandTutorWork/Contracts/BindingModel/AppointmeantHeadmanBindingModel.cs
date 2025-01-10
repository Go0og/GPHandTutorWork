using DataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.BindingModel
{
	public class AppointmentHeadmanBindingModel : IAppointmentHeadman
	{
		public int Id { get; set; }

		public int TutorId { get; set; }

		public int StudentId { get; set; }
	}
}
