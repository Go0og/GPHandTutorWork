using DataModel.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.SearchModel
{
	public class WorkTutorSearchModel
	{
		public int? Id { get; set; }
		public int? TutorID { get; set; }

		public TypeWork? TypeWork { get; set; }

		public DateTime? DateWork { get; set; }
	}
}
