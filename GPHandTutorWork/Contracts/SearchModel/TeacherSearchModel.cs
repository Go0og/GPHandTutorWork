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

		public int? PassportSerialAndNumber { get; set; }

		public int? ContactPhoneNumber { get; set; }

		public int? INN { get; set; }

		public int? InsuranceNumber { get; set; }

		public int? CardDetails { get; set; }
	}
}
