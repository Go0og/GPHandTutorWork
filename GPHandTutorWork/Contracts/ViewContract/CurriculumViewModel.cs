using DataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ViewContract
{
	public class CurriculumViewModel 
	{
		public int Id { get; set; }
		public string Subject { get; set; } = string.Empty;

		public string AttestationForm { get; set; } = string.Empty;

		public double TheoreticalHours { get; set; }

		public double PracticalHours { get; set; }

		public double Exam { get; set; }

		public double ConsultationExam { get; set; }

		public int Term { get; set; }
		public int GroupID { get; set; }


	}
}
