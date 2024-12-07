using DataModel.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
	public interface IWorkTutor : Iid
	{
		int TutorID { get; }
		TypeWork TypeWork { get; }
		DateTime DateWork { get; }
	}
}
