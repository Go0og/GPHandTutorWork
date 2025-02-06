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
	public abstract class AbstractWorkTutorWord
	{
		public byte[]? CreateDoc(WordWork info)
		{
			CreateWord(info);

			CreateParagraph(new WordParagraph
			{
				Texts = new List<(string, WordTextProperties)> { (info.Title, new WordTextProperties { Bold = false, Size = "24", }) },
				TextProperties = new WordTextProperties
				{
					Size = "24",
					JustificationType = WordJustificationType.Right,
				}

			});



			var document = SaveWord(info);
			return document;
		}

		protected abstract void CreateWord(WordWork info);

		protected abstract void CreateParagraph(WordParagraph paragraph);

		protected abstract byte[]? SaveWord(WordWork info);
	}
}
