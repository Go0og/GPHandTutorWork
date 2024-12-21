using DataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.BindingModel
{
	public class GPHAgreementBindingModel : IGPHAgreement
	{
		public int Id { get; set; }
		public DateTime DateOfConclusion { get; set; }

		public DateTime DataEnd { get; set; }

		public int UniversityEmployeeId { get; set; }

		public int TeacherId { get; set; }

		public int CurriculumId { get; set; }

		public double Bet { get; set; }

	}
}
