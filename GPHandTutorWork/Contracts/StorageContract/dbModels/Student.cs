using DataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.StorageContract.dbModels
{
	public class Student : IStudent
	{
		public int Id {get; set;}
		public string FIO {get; set;} = string.Empty;

		public int GroupId {get; set;}
		public Group? Gpoup {get; set;} 

	}
}
