using DataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.StorageContract.dbModels
{
	public class AppointmeantHeadman : IAppointmentHeadman
	{
		public int Id { get; set; }
		public int TutorId { get; set; }
		public Tutor? Tutor { get; set; }

		public int StudentId { get; set; }
		public Student? Student { get; set; }

	}
}
