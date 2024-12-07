using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
	public interface OfficialNote : Iid
	{
		int TutorID { get; }
		string Comment { get; }
	}
}
