using DataModel.Enum;
using DataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ViewContract
{
	public class WorkTutorViewModel  
	{
		public int Id { get; set; }
		public int TutorID { get; set; }

		public TypeWork TypeWork { get; set; }

		public DateTime DateWork { get; set; } = DateTime.Now;

	}
}
