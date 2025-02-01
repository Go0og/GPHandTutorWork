using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.SearchModel
{
	public class TeacherSearchModel
	{
		public int? Id { get; set; }
		public string? FIO { get; set; }

		public DateTime? DateOfBirth { get; set; }

		public string? PassportSerialAndNumber { get; set; }

		public string? ContactPhoneNumber { get; set; }

		public string? INN { get; set; }

		public string? InsuranceNumber { get; set; }

		public string? CardDetails { get; set; }
	}
}
