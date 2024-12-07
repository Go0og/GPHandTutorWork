using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Enum
{
	public enum Grade
	{
		НеАттестация = -3,
		НеЗачтено = -2,
		НеУдовлетворительно = -1,
		Неявка = -0,
		Зачтено=1,
		Удовлетворительно = 2,
		Хорошо = 3,
		Отлично = 4
	}
}
