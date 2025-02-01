using DataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ViewContract
{
	public class TeacherViewModel  
	{
		public int Id { get; set; }
		public string FIO { get; set; } = string.Empty;

		public DateTime DateOfBirth { get; set; }

		public string PassportSerialAndNumber { get; set; } = string.Empty;

		public string ContactPhoneNumber { get; set; } = string.Empty;

		public string INN { get; set; } = string.Empty;

		public string InsuranceNumber { get; set; } = string.Empty;

		public string CardDetails { get; set; } = string.Empty;
	}
}
