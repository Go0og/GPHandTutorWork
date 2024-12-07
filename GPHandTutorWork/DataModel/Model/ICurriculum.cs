using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
	public interface ICurriculum : Iid
	{
		string Subject { get; }
		string AttestationForm { get; }
		double TheoreticalHours { get; }
		double PracticalHours { get; }
		double Exam { get; }
		double ConsultationExam { get; }
		int Term { get; }
		int GroupID { get; }
	}
}
