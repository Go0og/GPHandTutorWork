using Contracts.ViewContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InteractorContract
{
	public interface IReportTutorLogic
	{

		byte[]? SaveNoteToWordFile(OfficialNoteViewModel model);
	}
}
