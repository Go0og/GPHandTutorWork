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
		public int TutorId { get; set; }

		public string TypeWork { get; set; } = string.Empty;

		public string DateWork { get; set; } = string.Empty;

	}
}
