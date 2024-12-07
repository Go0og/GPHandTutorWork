using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
	public interface IGPHAgreement : Iid
	{
		DateTime DateOfConclusion { get; }
		DateTime DataEnd { get; }
		int UniversityEmployeeID { get; }
		int TeacherID { get; }
		int CurriculumID { get; }
		double Bet { get; }
	}
}
