using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.SearchModel
{
	public class CurriculumSearchModel
	{
		public int? Id { get; set; }
		public string? Subject { get; set; } 

		public string? AttestationForm { get; set; }
		public double? TheoreticalHours { get; set; }

		public double? PracticalHours { get; set; }

		public double? Exam { get; set; }

		public double? ConsultationExam { get; set; }

		public int? Term { get; set; }
		public int? GroupID { get; set; }

	}
}
