using DataModel.Enum;
using Interactors.OfficePackage.HelperEnums;
using Interactors.OfficePackage.Helpermodels;


namespace Interactors.OfficePackage
{
	public abstract class AbstractWorkTutorWord
	{
		private Dictionary<TypeWork, int> WorkDict = new Dictionary<TypeWork, int>()
		{
			{TypeWork.СоставлениеСлужебнойЗаписки,3},
			{TypeWork.КонтрольПосещаимости,2},
			{TypeWork.НазначениеСтарост,1},
			};
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

			int sum = 0;
			foreach (var work in info.ListWork)
			{
				sum += WorkDict[work.TypeWork];
				CreateParagraph(new WordParagraph
				{
					Texts = new List<(string, WordTextProperties)> { ($"ID :{work.Id.ToString()}/Вид деятельности :{work.TypeWork}/"
			  + $"Баллы :{WorkDict[work.TypeWork]}/", new WordTextProperties { Bold = false, Size = "24", }) },
					TextProperties = new WordTextProperties
					{
						Size = "24",
						JustificationType = WordJustificationType.Both
					}
				});


			}
			CreateParagraph(new WordParagraph
			{
				Texts = new List<(string, WordTextProperties)> { ($"Итого: {sum}\t", new WordTextProperties { Bold = true, Size = "24", }) },
				TextProperties = new WordTextProperties
				{
					Size = "24",
					JustificationType = WordJustificationType.Right
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