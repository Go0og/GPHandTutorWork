using Contracts.InteractorContract;
using Contracts.SearchModel;
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
		private readonly IWorkTutorStorage _workStorage;
		private readonly AbstractOfficialNoteWord _saveNoteToWord;
		private readonly AbstractWorkTutorWord _saveWorkToWord;

		public ReportTutorLogic(AbstractOfficialNoteWord abstractOfficialNoteWord, IOfficialNoteStorage noteStorage, AbstractWorkTutorWord saveWorkToWord, IWorkTutorStorage workStorage)
		{
			_noteStorage = noteStorage;
			_saveNoteToWord = abstractOfficialNoteWord;
			_saveWorkToWord = saveWorkToWord;
			_workStorage = workStorage;
		}
		public byte[]? SaveNoteToWordFile(OfficialNoteViewModel model)
		{
			var document = _saveNoteToWord.CreateDoc(new WordNote
			{
				Title = "Записка куратора",
				Comments = model.Comment,
			});
			return document;
		}

		public byte[]? SaveWorkToWordFile(WorkTutorSearchModel model) 
		{
			var fillteredList = _workStorage.GetFillteredList(model);


			var document = _saveWorkToWord.CreateDoc(new WordWork
			{
				Title = "Работа куратора",
				ListWork = fillteredList,
			});
			return document;
		}


	}
}
