using DataModel.Enum;
using Interactors.OfficePackage.HelperEnums;
using Interactors.OfficePackage.Helpermodels;


namespace Interactors.OfficePackage
{
	public abstract class AbstractEmployeeGPHWord
	{
		public Dictionary<TypeWork, int> WorkDict = new Dictionary<TypeWork, int>()
	{
		{ TypeWork.СоставлениеСлужебнойЗаписки, 3 },
		{ TypeWork.КонтрольПосещаимости, 2 },
		{ TypeWork.НазначениеСтарост, 1 },
	};

		public byte[]? CreateDoc(WordEmployeeGPH info)
		{
			// Создаем документ
			CreateWord(info);

			// Добавляем заголовок
			CreateParagraph(new WordParagraph
			{
				Texts = new List<(string, WordTextProperties)>
			{
				($"Список заключённых ГПХ ", new WordTextProperties { Bold = true, Size = "24" })
			},
				TextProperties = new WordTextProperties
				{
					Size = "24",
					JustificationType = WordJustificationType.Right
				}
			});

			// Создаем таблицу
			CreateTable(info);


			// Сохраняем документ
			return SaveWord(info);
		}


		protected abstract void CreateWord(WordEmployeeGPH info);

		protected abstract void CreateParagraph(WordParagraph paragraph);

		protected abstract void CreateTable(WordEmployeeGPH info);

		protected abstract byte[]? SaveWord(WordEmployeeGPH info);
	}
}