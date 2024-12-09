using DataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ViewContract
{
	public class AppointmeantHeadmanViewModel 
	{
		public int Id { get; set; }

		public int TutorID { get; set; }

		public int StudentID { get; set; }
	}
}
