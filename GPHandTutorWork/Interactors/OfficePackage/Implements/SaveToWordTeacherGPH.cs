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
using Contracts.StorageContract.dbModels;

namespace Interactors.OfficePackage.Implements
{
	public class SaveToWordTeacherGPH : AbstractWordTeacherGPH
	{
		private WordprocessingDocument? _wordDocument;
		private Body? _docBody;
		private MemoryStream _mem = new MemoryStream();

		protected override void CreateWord(WordTeacherGPH info)
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

		protected override void CreateTable(WordTeacherGPH info)
		{
			if (_docBody == null)
			{
				return;
			}

			var table = new Table();


			var tableProperties = new TableProperties(
				new TableWidth { Width = "5000", Type = TableWidthUnitValues.Pct }, 
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


			var tableGrid = new TableGrid();
			tableGrid.AppendChild(new GridColumn { Width = "3000" });
			tableGrid.AppendChild(new GridColumn { Width = "666" }); 
			tableGrid.AppendChild(new GridColumn { Width = "666" });
			tableGrid.AppendChild(new GridColumn { Width = "666" });
			table.AppendChild(tableGrid);


			var headerRow = new TableRow();
			headerRow.AppendChild(CreateTableCell("Вид услуги", true));
			headerRow.AppendChild(CreateTableCell("Количество часов", true));
			headerRow.AppendChild(CreateTableCell("Стоимость 1 часа, руб.", true));
			headerRow.AppendChild(CreateTableCell("Сумма, руб.", true));
			table.AppendChild(headerRow);

			foreach (var subject in info.CurriculumList)
			{
				var row = new TableRow();
				row.AppendChild(CreateTableCell(subject.Subject));
				row.AppendChild(CreateTableCell(CalculateHoursInSubject(subject)));
				row.AppendChild(CreateTableCell(info.GPHAgreement.FirstOrDefault(x => x.CurriculumId == subject.Id).Bet.ToString()));
				row.AppendChild(CreateTableCell(CalculateMoneyInSubject(info.GPHAgreement.FirstOrDefault(x => x.CurriculumId == subject.Id))));
				table.AppendChild(row);
			}
			var ro = new TableRow();
			ro.AppendChild(CreateTableCell("Итого"));
			ro.AppendChild(CreateTableCell(SumHoursGlobal.ToString()));
			ro.AppendChild(CreateTableCell(""));
			ro.AppendChild(CreateTableCell(SumMoneyGlobal.ToString()));
			table.AppendChild(ro);
			_docBody.AppendChild(table);
		}
		private double SumHours = 0;
		private double SumHoursGlobal = 0;
		private double SumMoneyGlobal = 0;
		private string CalculateHoursInSubject(Curriculum data)
		{
			double sum = 0;
			sum += data.TheoreticalHours;
			sum += data.PracticalHours;
			sum += data.ConsultationExam;
			sum += data.Exam;
			SumHours = sum;
			SumHoursGlobal += sum;
			return sum.ToString();
		}
		private string CalculateMoneyInSubject(GPHAgreement data)
		{
			double sum = 0;
			sum = SumHours * data.Bet;
			SumMoneyGlobal += sum;
			return sum.ToString();
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

		protected override byte[]? SaveWord(WordTeacherGPH info)
		{
			if (_docBody == null || _wordDocument == null)
			{
				return null;
			}

			_docBody.AppendChild(CreateSectionProperties());

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
