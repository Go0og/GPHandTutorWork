using DataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ViewContract
{
	public class UniversiryEmployeeViewModel 
	{
		public int Id { get; set; }
		public string FIO { get; set; } = string.Empty;

		public string Login { get; set; } = string.Empty;

		public string Password { get; set; } = string.Empty;
	}
}
