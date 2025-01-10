using DataModel.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.StorageContract.dbModels
{
	public class Group : IGroup
	{
		public int Id {get; set;}
		[Required]
		public string Name {get; set;} = string.Empty;
		public int TutorId {get; set;}
		public Tutor? Tutor {get; set;}

	}
}
