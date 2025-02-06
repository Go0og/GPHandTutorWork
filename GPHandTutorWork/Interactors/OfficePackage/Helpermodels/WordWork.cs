using Contracts.StorageContract.dbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactors.OfficePackage.Helpermodels
{
	public class WordWork
	{
		public string Title { get; set; } = string.Empty;

		public List<WorkTutor> ListWork { get; set; } = new();
	}
}
