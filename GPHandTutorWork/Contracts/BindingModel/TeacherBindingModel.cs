using DataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.BindingModel
{
	public class TeacherBindingModel : ITeacher
	{
		public int Id { get; set; }
		public string FIO { get; set; } = string.Empty;

		public DateTime DateOfBirth { get; set; }

		public int PassportSerialAndNumber { get; set; }

		public int ContactPhoneNumber { get; set; }

		public int INN { get; set; }

		public int InsuranceNumber { get; set; }

		public int CardDetails { get; set; }
	}
}
