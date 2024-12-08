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

		public int? CurriculumID { get; set; }

		public int? StudentID { get; set; }

		public int? TeacherID { get; set; }

		public DateTime? DateGrade { get; set; }

		public int? LessonNumber { get; set; }

		public Grade? Grade { get; set; } 
	}
}
