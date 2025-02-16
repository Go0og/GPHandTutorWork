using Contracts.StorageContract.dbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactors.OfficePackage.Helpermodels
{
	public class WordTeacherGPH
	{
		public string Title { get; set; } = string.Empty;

		public Group? Group { get; set; } 
		public Teacher? Teacher { get; set; }
		public Curriculum? Curriculum { get; set; }
		public GPHAgreement? GHAgreement { get; set; }
	}
}
