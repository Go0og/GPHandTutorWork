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
		public Teacher? Teacher { get; set; }
		public List<Curriculum>? CurriculumList { get; set; } = new();
		public List<GPHAgreement>? GPHAgreement { get; set; }
	}
}
