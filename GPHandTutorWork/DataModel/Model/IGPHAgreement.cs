using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
	public interface IGPHAgreement : IId
	{
		DateTime DateOfConclusion { get; }
		DateTime DataEnd { get; }
		int UniversityEmployeeId { get; }
		int TeacherId { get; }
		List<int> CurriculumList { get; }
		double Bet { get; }
	}
}
