using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.BindingModel
{
	public class ReportBindingModel
	{
		public DateTime DateFrom { get; set; }
		public DateTime DateTo { get; set; }

		public int NoteId { get; set; }
	}
}
