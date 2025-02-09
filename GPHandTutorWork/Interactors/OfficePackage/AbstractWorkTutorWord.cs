using DataModel.Enum;
using Interactors.OfficePackage.HelperEnums;
using Interactors.OfficePackage.Helpermodels;


namespace Interactors.OfficePackage
{
	public abstract class AbstractWorkTutorWord
	{
		public Dictionary<TypeWork, int> WorkDict = new Dictionary<TypeWork, int>()
	{
		{ TypeWork.СоставлениеСлужебнойЗаписки, 3 },
		{ TypeWork.КонтрольПосещаимости, 2 },
		{ TypeWork.НазначениеСтарост, 1 },
	};

		public byte[]? CreateDoc(WordWork info)
		{
			// Создаем документ
			CreateWord(info);

			// Добавляем заголовок
			CreateParagraph(new WordParagraph
			{
				Texts = new List<(string, WordTextProperties)>
			{
				(info.Title, new WordTextProperties { Bold = true, Size = "24" })
			},
				TextProperties = new WordTextProperties
				{
					Size = "24",
					JustificationType = WordJustificationType.Right
				}
			});

			// Создаем таблицу
			CreateTable(info);

			// Добавляем итоговую строку
			CreateParagraph(new WordParagraph
			{
				Texts = new List<(string, WordTextProperties)>
			{
				($"Итого: {CalculateTotal(info)}", new WordTextProperties { Bold = true, Size = "24" })
			},
				TextProperties = new WordTextProperties
				{
					Size = "24",
					JustificationType = WordJustificationType.Right
				}
			});

			// Сохраняем документ
			return SaveWord(info);
		}

		private int CalculateTotal(WordWork info)
		{
			int sum = 0;
			foreach (var work in info.ListWork)
			{
				sum += WorkDict[work.TypeWork];
			}
			return sum;
		}

		protected abstract void CreateWord(WordWork info);

		protected abstract void CreateParagraph(WordParagraph paragraph);

		protected abstract void CreateTable(WordWork info);

		protected abstract byte[]? SaveWord(WordWork info);
	}
}