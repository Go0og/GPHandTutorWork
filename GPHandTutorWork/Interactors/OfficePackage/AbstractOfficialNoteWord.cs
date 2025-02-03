using Contracts.StorageContract.dbModels;
using Interactors.OfficePackage.HelperEnums;
using Interactors.OfficePackage.Helpermodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace Interactors.OfficePackage
{
	public abstract class AbstractOfficialNoteWord
	{
		public byte[]? CreateDoc(WordNote info)
		{
			CreateWord(info);

			CreateParagraph(new WordParagraph
			{
				Texts = new List<(string, WordTextProperties)> { (info.Title, new WordTextProperties { Bold = false, Size = "24", }) },
				TextProperties = new WordTextProperties
				{
					Size = "24",
					JustificationType = WordJustificationType.Both
				}

			});

			CreateParagraph(new WordParagraph
			{
				Texts = new List<(string, WordTextProperties)> { ("Записка Куратора", new WordTextProperties { Bold = true, Size = "32", }) },
				TextProperties = new WordTextProperties
				{
					Size = "32",
					JustificationType = WordJustificationType.Center
				}
			});

			CreateParagraph(new WordParagraph
			{
				Texts = new List<(string, WordTextProperties)> { (info.Comments, new WordTextProperties { Bold = false, Size = "24", }) },
				TextProperties = new WordTextProperties
				{
					Size = "24",
					JustificationType = WordJustificationType.Center,
				}
			});

			var document = SaveWord(info);
			return document;
		}

		// Создание doc-файла
		protected abstract void CreateWord(WordNote info);

		// Создание абзаца с текстом
		protected abstract void CreateParagraph(WordParagraph paragraph);

		// Сохранение файла
		protected abstract byte[]? SaveWord(WordNote info);
	}
}
