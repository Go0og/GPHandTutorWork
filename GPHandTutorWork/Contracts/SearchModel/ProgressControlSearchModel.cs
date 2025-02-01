using DataModel.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.SearchModel
{
	public class ProgressControlSearchModel
	{
		public int? Id { get; set; }

		public int? CurriculumId { get; set; }

		public int? StudentId { get; set; }

		public int? TeacherId { get; set; }

		public DateTime? DateGrade { get; set; }

		public int? LessonNumber { get; set; }

		public Grade? Grade { get; set; } 
	}
}
