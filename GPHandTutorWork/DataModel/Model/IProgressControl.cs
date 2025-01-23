using DataModel.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataModel.Model
{
	public interface IProgressControl : IId
	{
		int CurriculumList { get; }
		int StudentId { get; }
		int TeacherId { get; }
		DateTime DateGrade { get; }
		int LessonNumber { get; }
		Grade Grade { get; }
	}
}