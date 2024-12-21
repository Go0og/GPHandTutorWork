using DataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.StorageContract.dbModels
{
	public class GPHAgreement : IGPHAgreement
	{
		public int Id {get; set;}
		public DateTime DateOfConclusion {get; set;}

		public DateTime DataEnd {get; set;}

		public int UniversityEmployeeId {get; set;}
		public UniversityEmployee? UniversityEmployee {get; set;}

		public int TeacherId {get; set;}
		public Teacher? Teacher {get; set;}

		public int CurriculumId {get; set;}
		public Curriculum? Curriculum {get; set;} 

		public double Bet {get; set;}

	}
}
