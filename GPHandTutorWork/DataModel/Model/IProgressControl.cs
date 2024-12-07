using DataModel.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataModel.Model
{
	public interface IProgressControl : Iid
	{
		int CurriculumID { get; }
		int StudentID { get; }
		int TeacherID { get; }
		DateTime DateGrade { get; }
		int LessonNumber { get; }
		Grade Grade { get; }
	}
}