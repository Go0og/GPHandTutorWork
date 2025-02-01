using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
	public interface ITeacher : IId
	{
		string FIO { get; }
		DateTime DateOfBirth { get; }
		string PassportSerialAndNumber { get; }
		string ContactPhoneNumber { get; }
		string INN { get; }
		string InsuranceNumber { get; }//Стразование
		string CardDetails { get; }
	}
}
