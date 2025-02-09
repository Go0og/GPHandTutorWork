using Interactors.OfficePackage.HelperEnums;
using Interactors.OfficePackage.Helpermodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Xceed.Document.NET;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using Document = DocumentFormat.OpenXml.Wordprocessing.Document;
using Paragraph = DocumentFormat.OpenXml.Wordprocessing.Paragraph;
using Run = DocumentFormat.OpenXml.Wordprocessing.Run;
using Text = DocumentFormat.OpenXml.Wordprocessing.Text;
using Table = DocumentFormat.OpenXml.Wordprocessing.Table;

namespace Interactors.OfficePackage.Implements
{
	public class SaveToWordWork : AbstractWorkTutorWord
	{
		private WordprocessingDocument? _wordDocument;
		private Body? _docBody;
		private MemoryStream _mem = new MemoryStream();

		protected override void CreateWord(WordWork info)
		{
			_wordDocument = WordprocessingDocument.Create(_mem, WordprocessingDocumentType.Document);
			MainDocumentPart mainPart = _wordDocument.AddMainDocumentPart();
			mainPart.Document = new Document();
			_docBody = mainPart.Document.AppendChild(new Body());
		}

		protected override void CreateParagraph(WordParagraph paragraph)
		{
			if (_docBody == null || paragraph == null)
			{
				return;
			}

			var docParagraph = new Paragraph();

			docParagraph.AppendChild(CreateParagraphProperties(paragraph.TextProperties));

			foreach (var run in paragraph.Texts)
			{
				var docRun = new Run();

				var properties = new RunProperties();
				properties.AppendChild(new FontSize { Val = run.Item2.Size });
				if (run.Item2.Bold)
				{
					properties.AppendChild(new Bold());
				}
				docRun.AppendChild(properties);

				docRun.AppendChild(new Text { Text = run.Item1, Space = SpaceProcessingModeValues.Preserve });

				docParagraph.AppendChild(docRun);
			}

			_docBody.AppendChild(docParagraph);
		}

		protected override void CreateTable(WordWork info)
		{
			if (_docBody == null)
			{
				return;
			}

			// Создаем таблицу
			var table = new Table();

			// Добавляем стили таблицы
			var tableProperties = new TableProperties(
				new TableBorders(
					new TopBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 },
					new BottomBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 },
					new LeftBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 },
					new RightBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 },
					new InsideHorizontalBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 },
					new InsideVerticalBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 }
				)
			);
			table.AppendChild(tableProperties);

			// Создаем строку с заголовками
			var headerRow = new TableRow();
			headerRow.AppendChild(CreateTableCell("ID", true));
			headerRow.AppendChild(CreateTableCell("Вид деятельности", true));
			headerRow.AppendChild(CreateTableCell("Баллы", true));
			table.AppendChild(headerRow);

			// Заполняем таблицу данными
			foreach (var work in info.ListWork)
			{
				var row = new TableRow();
				row.AppendChild(CreateTableCell(work.Id.ToString()));
				row.AppendChild(CreateTableCell(work.TypeWork.ToString()));
				row.AppendChild(CreateTableCell(WorkDict[work.TypeWork].ToString()));
				table.AppendChild(row);
			}

			_docBody.AppendChild(table);
		}

		private TableCell CreateTableCell(string text, bool isHeader = false)
		{
			var cell = new TableCell();
			var paragraph = new Paragraph();
			var run = new Run();
			var runProperties = new RunProperties();

			if (isHeader)
			{
				runProperties.AppendChild(new Bold());
			}

			run.AppendChild(runProperties);
			run.AppendChild(new Text(text));
			paragraph.AppendChild(run);
			cell.AppendChild(paragraph);

			return cell;
		}

		protected override byte[]? SaveWord(WordWork info)
		{
			if (_docBody == null || _wordDocument == null)
			{
				return null;
			}

			// Добавляем настройки страницы
			_docBody.AppendChild(CreateSectionProperties());

			// Сохраняем документ
			_wordDocument.MainDocumentPart!.Document.Save();
			_wordDocument.Dispose();

			return _mem.ToArray();
		}

		private static SectionProperties CreateSectionProperties()
		{
			var properties = new SectionProperties();
			var pageSize = new PageSize { Orient = PageOrientationValues.Portrait };
			properties.AppendChild(pageSize);
			return properties;
		}

		private static ParagraphProperties? CreateParagraphProperties(WordTextProperties? paragraphProperties)
		{
			if (paragraphProperties == null)
			{
				return null;
			}

			var properties = new ParagraphProperties();
			properties.AppendChild(new Justification
			{
				Val = GetJustificationValues(paragraphProperties.JustificationType)
			});

			var paragraphMarkRunProperties = new ParagraphMarkRunProperties();
			if (!string.IsNullOrEmpty(paragraphProperties.Size))
			{
				paragraphMarkRunProperties.AppendChild(new FontSize { Val = paragraphProperties.Size });
			}
			properties.AppendChild(paragraphMarkRunProperties);

			return properties;
		}

		private static JustificationValues GetJustificationValues(WordJustificationType type)
		{
			return type switch
			{
				WordJustificationType.Both => JustificationValues.Both,
				WordJustificationType.Center => JustificationValues.Center,
				WordJustificationType.Right => JustificationValues.Right,
				_ => JustificationValues.Left,
			};
		}
	}
}
