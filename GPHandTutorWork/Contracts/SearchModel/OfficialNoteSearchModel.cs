using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.SearchModel
{
	public class OfficialNoteSearchModel
	{
		public int? Id { get; set; }
		public int? TutorID { get; set; }

		public string? Comment { get; set; } 
	}
}
