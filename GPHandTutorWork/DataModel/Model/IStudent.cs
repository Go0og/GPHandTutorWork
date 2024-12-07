using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
	public interface IStudent : Iid
	{
		string FIO { get; }
		int GroupID { get; }
	}
}
