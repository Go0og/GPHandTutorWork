using DataModel.Enum;
using DataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.BindingModel
{
	public class WorkTutorBindingModel : IWorkTutor
	{
		public int Id { get; set; }
		public int TutorID { get; set; }

		public TypeWork TypeWork { get; set; }

		public DateTime DateWork { get; set; } = DateTime.Now;

	}
}
