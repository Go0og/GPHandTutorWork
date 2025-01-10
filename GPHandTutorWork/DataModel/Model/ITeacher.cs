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
		int PassportSerialAndNumber { get; }
		int ContactPhoneNumber { get; }
		int INN { get; }
		int InsuranceNumber { get; }//Стразование
		int CardDetails { get; }
	}
}
