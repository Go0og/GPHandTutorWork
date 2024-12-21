using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
	public interface IGroup : IId
	{
		string Name { get; }
		int TutorId { get; }
	}
}
