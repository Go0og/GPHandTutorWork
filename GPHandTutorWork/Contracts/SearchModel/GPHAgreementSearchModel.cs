using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.SearchModel
{
	public class GPHAgreementSearchModel
	{
		public int? Id { get; set; }
		public DateTime? DateOfConclusion { get; set; }

		public DateTime? DataEnd { get; set; }

		public int? UniversityEmployeeId { get; set; }

		public int? TeacherId { get; set; }

		public int? CurriculumList { get; set; }

		public double? Bet { get; set; }
	}
}
