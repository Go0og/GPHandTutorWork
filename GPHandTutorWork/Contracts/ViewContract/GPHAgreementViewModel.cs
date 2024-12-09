using DataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ViewContract
{
	public class GPHAgreementViewModel  
	{
		public int Id { get; set; }
		public DateTime DateOfConclusion { get; set; }

		public DateTime DataEnd { get; set; }

		public int UniversityEmployeeID { get; set; }

		public int TeacherID { get; set; }

		public int CurriculumID { get; set; }

		public double Bet { get; set; }

	}
}
