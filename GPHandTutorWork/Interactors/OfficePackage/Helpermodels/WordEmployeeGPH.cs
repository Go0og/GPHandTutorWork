using Contracts.StorageContract.dbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactors.OfficePackage.Helpermodels
{
	public class WordEmployeeGPH
	{
		public string Title { get; set; } = string.Empty;
		public List<Teacher>? Teacher { get; set; } = new();
		public List<Curriculum>? CurriculumList { get; set; } = new();

		public List<GPHAgreement>? GPH { get; set; } = new();

	}
}
