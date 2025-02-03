using Contracts.InteractorContract;
using Contracts.StorageContract;
using Contracts.ViewContract;
using Interactors.OfficePackage;
using Interactors.OfficePackage.Helpermodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactors
{
	public class ReportTutorLogic : IReportTutorLogic
	{
		private readonly IOfficialNoteStorage _noteStorage;
		private readonly AbstractOfficialNoteWord _saveToWord;

		public ReportTutorLogic(AbstractOfficialNoteWord abstractOfficialNoteWord, IOfficialNoteStorage noteStorage)
		{
			_noteStorage = noteStorage;
			_saveToWord = abstractOfficialNoteWord;
		}
		public byte[]? SaveNoteToWordFile(OfficialNoteViewModel model)
		{
			var document = _saveToWord.CreateDoc(new WordNote
			{
				Title = "Список оплат",
				Comments = model.Comment,
			});
			return document;
		}
	}
}
