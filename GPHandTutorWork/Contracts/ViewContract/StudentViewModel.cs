using DataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ViewContract
{
	public class StudentViewModel 
	{
		public int Id { get; set; }
		public string FIO { get; set; } = string.Empty;

		public int GroupID { get; set; }

	}
}
