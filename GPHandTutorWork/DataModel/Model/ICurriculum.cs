using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
	public interface ICurriculum : IId
	{
		string Subject { get; }
		string AttestationForm { get; }
		double TheoreticalHours { get; }
		double PracticalHours { get; }
		double Exam { get; }
		double ConsultationExam { get; }
		int Term { get; }
		int GroupId { get; }
	}
}
