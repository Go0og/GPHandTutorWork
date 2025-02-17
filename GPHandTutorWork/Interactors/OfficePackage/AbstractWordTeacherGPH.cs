using Interactors.OfficePackage.HelperEnums;
using Interactors.OfficePackage.Helpermodels;


namespace Interactors.OfficePackage
{
	public abstract class AbstractWordTeacherGPH
	{

		public byte[]? CreateDoc(WordTeacherGPH info)
		{
			// Создаем документ
			CreateWord(info);
			// Добавляем заголовок
			CreateParagraph(new WordParagraph
			{
				Texts = new List<(string, WordTextProperties)>
			{
				("ДОГОВОР", new WordTextProperties { Bold = true, Size = "24" })
			},
				TextProperties = new WordTextProperties
				{
					Size = "24",
					JustificationType = WordJustificationType.Center
				}
			});
			CreateParagraph(new WordParagraph
			{
				Texts = new List<(string, WordTextProperties)>
			{
				("ВОЗМЕЗДНОГО ОКАЗАНИЯ УСЛУГ", new WordTextProperties { Bold = true, Size = "24" })
			},
				TextProperties = new WordTextProperties
				{
					Size = "24",
					JustificationType = WordJustificationType.Center
				}
			});

			CreateParagraph(new WordParagraph
			{
				Texts = new List<(string, WordTextProperties)>
			{
				(DateTime.Now.ToString(), new WordTextProperties { Bold = true, Size = "24" })
			},
				TextProperties = new WordTextProperties
				{
					Size = "24",
					JustificationType = WordJustificationType.Right
				}
			});

			//Шапка ГПХ
			CreateParagraph(new WordParagraph
			{
				Texts = new List<(string, WordTextProperties)>
			{
				($"<Крутая организация>,", new WordTextProperties { Bold = true, Size = "24" }),
				($" именуемое в дальнейшем <<Заказчик>>, в лице директора", new WordTextProperties { Bold = false, Size = "24" }),
				($"<Имя Директора>,", new WordTextProperties { Bold = true, Size = "24" }),
				($" действующего на основании устава, с одной стороны, и ", new WordTextProperties { Bold = false, Size = "24" }),
				($"{info.Teacher.FIO},", new WordTextProperties { Bold = true, Size = "24" }),
				($"гражданин РФ, паспорт {info.Teacher.PassportSerialAndNumber}, именуемый в дальнейшем <<Исполнитель>>, с другой стороны, заключили настоящий договор о нижеследующем:", new WordTextProperties { Bold = false, Size = "24" })
			},
				TextProperties = new WordTextProperties
				{
					Size = "24",
					JustificationType = WordJustificationType.Both
				}
			});

			// глава 1 предмет договора
			CreateParagraph(new WordParagraph
			{
				Texts = new List<(string, WordTextProperties)>
			{
				($"1. ПРЕДМЕТ ДОГОВОРА", new WordTextProperties { Bold = true, Size = "24" })
			},
				TextProperties = new WordTextProperties
				{
					Size = "24",
					JustificationType = WordJustificationType.Center
				}
			});
			// Создаем таблицу
			CreateTable(info);

			// ПРАВА И ОБЯЗАННОСТИ СТОРОН
			CreateParagraph(new WordParagraph
			{
				Texts = new List<(string, WordTextProperties)>
			{
				($"2. ПРАВА И ОБЯЗАННОСТИ СТОРОН", new WordTextProperties { Bold = true, Size = "24" })
			},
				TextProperties = new WordTextProperties
				{
					Size = "24",
					JustificationType = WordJustificationType.Center
				}
			});

			//ЦЕНА И ПОРЯДОК РАСЧЁТА 
			CreateParagraph(new WordParagraph
			{
				Texts = new List<(string, WordTextProperties)>
				{
					($"3. ЦЕНА И ПОРЯДОК РАСЧЁТА ", new WordTextProperties { Bold = true, Size = "24" })
				},
				TextProperties = new WordTextProperties
				{
					Size = "24",
					JustificationType = WordJustificationType.Center
				}
			});

			// ОТВЕТСТВЕННОСТЬ СТОРОН
			CreateParagraph(new WordParagraph
			{
				Texts = new List<(string, WordTextProperties)>
				{
					($"4. ЦЕНА И ПОРЯДОК РАСЧЁТА", new WordTextProperties { Bold = true, Size = "24" })
				},
				TextProperties = new WordTextProperties
				{
					Size = "24",
					JustificationType = WordJustificationType.Center
				}
			});

			//ОСОБЫЕ УСЛОВИЯ
			CreateParagraph(new WordParagraph
			{
				Texts = new List<(string, WordTextProperties)>
				{
					($"5. ОСОБЫЕ УСЛОВИЯ", new WordTextProperties { Bold = true, Size = "24" })
				},
				TextProperties = new WordTextProperties
				{
					Size = "24",
					JustificationType = WordJustificationType.Center
				}
			});

			//ЗАКЛЮЧИТЕЛЬНЫЕ ПОЛОЖЕНИЯ 
			CreateParagraph(new WordParagraph
			{
				Texts = new List<(string, WordTextProperties)>
				{
					($"6. ЗАКЛЮЧИТЕЛЬНЫЕ ПОЛОЖЕНИЯ", new WordTextProperties { Bold = true, Size = "24" })
				},
				TextProperties = new WordTextProperties
				{
					Size = "24",
					JustificationType = WordJustificationType.Center
				}
			});


			// АДРЕСА И РЕКВИЗИТЫ СТОРОН
			// заказчик
			CreateParagraph(new WordParagraph
			{
				Texts = new List<(string, WordTextProperties)>
				{
					($"7. АДРЕСА И РЕКВИЗИТЫ СТОРОН", new WordTextProperties { Bold = true, Size = "24" }),
					
				

				
					
				},
				TextProperties = new WordTextProperties
				{
					Size = "24",
					JustificationType = WordJustificationType.Center
				}
			});
			CreateParagraph(new WordParagraph
			{
				Texts = new List<(string, WordTextProperties)>
				{
					($"ЗАКАЗЧИК\n", new WordTextProperties { Bold = true, Size = "24" }),
				},
				TextProperties = new WordTextProperties
				{
					Size = "24",
					JustificationType = WordJustificationType.Center
				}
			});
			CreateParagraph(new WordParagraph
			{
				Texts = new List<(string, WordTextProperties)>
				{
					($"<Крутая организация >\n", new WordTextProperties { Bold = true, Size = "24" }),
				},
				TextProperties = new WordTextProperties
				{
					Size = "24",
					JustificationType = WordJustificationType.Center
				}
			});
			CreateParagraph(new WordParagraph
			{
				Texts = new List<(string, WordTextProperties)>
				{
					($"<<__остальные данные__>>\n", new WordTextProperties { Bold = false, Size = "24" }),
				},
				TextProperties = new WordTextProperties
				{
					Size = "24",
					JustificationType = WordJustificationType.Center
				}
			});
			CreateParagraph(new WordParagraph
			{
				Texts = new List<(string, WordTextProperties)>
				{
						($"Заказчик\n", new WordTextProperties { Bold = false, Size = "24" }),
				},
				TextProperties = new WordTextProperties
				{
					Size = "24",
					JustificationType = WordJustificationType.Center
				}
			});
			CreateParagraph(new WordParagraph
			{
				Texts = new List<(string, WordTextProperties)>
				{
					($"Директор ______________ <<__ фио директора__>>\n\n", new WordTextProperties { Bold = false, Size = "24" }),
				},
				TextProperties = new WordTextProperties
				{
					Size = "24",
					JustificationType = WordJustificationType.Center
				}
			});
			// исполнитель
			CreateParagraph(new WordParagraph
			{
				Texts = new List<(string, WordTextProperties)>
				{
					($"ИСПОЛНИТЕЛЬ\n", new WordTextProperties { Bold = true, Size = "24" }),
				},
				TextProperties = new WordTextProperties
				{
					Size = "24",
					JustificationType = WordJustificationType.Center
				}
			});
			CreateParagraph(new WordParagraph
			{
				Texts = new List<(string, WordTextProperties)>
				{
					($"ФИО {info.Teacher.FIO}\n", new WordTextProperties { Bold = true, Size = "24" }),
				},
				TextProperties = new WordTextProperties
				{
					Size = "24",
					JustificationType = WordJustificationType.Center
				}
			});
			CreateParagraph(new WordParagraph
			{
				Texts = new List<(string, WordTextProperties)>
				{
					($"Паспорт {info.Teacher.PassportSerialAndNumber}\n", new WordTextProperties { Bold = false, Size = "24" }),
				},
				TextProperties = new WordTextProperties
				{
					Size = "24",
					JustificationType = WordJustificationType.Center
				}
			});
			CreateParagraph(new WordParagraph
			{
				Texts = new List<(string, WordTextProperties)>
				{
					($"ИНН {info.Teacher.INN}\n", new WordTextProperties { Bold = false, Size = "24" }),
				},
				TextProperties = new WordTextProperties
				{
					Size = "24",
					JustificationType = WordJustificationType.Center
				}
			});
			CreateParagraph(new WordParagraph
			{
				Texts = new List<(string, WordTextProperties)>
				{
					($"Исполнитель\n", new WordTextProperties { Bold = false, Size = "24" }),
				},
				TextProperties = new WordTextProperties
				{
					Size = "24",
					JustificationType = WordJustificationType.Center
				}
			});
			CreateParagraph(new WordParagraph
			{
				Texts = new List<(string, WordTextProperties)>
				{
					($" ______________ {info.Teacher.FIO}\n", new WordTextProperties { Bold = false, Size = "24" }),
				},
				TextProperties = new WordTextProperties
				{
					Size = "24",
					JustificationType = WordJustificationType.Center
				}
			});
			// Сохраняем документ
			return SaveWord(info);
		}

		protected abstract void CreateWord(WordTeacherGPH info);

		protected abstract void CreateParagraph(WordParagraph paragraph);

		protected abstract void CreateTable(WordTeacherGPH info);

		protected abstract byte[]? SaveWord(WordTeacherGPH info);
	}
}